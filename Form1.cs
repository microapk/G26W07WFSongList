using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace G26W07WFSongList
{

    public partial class Form1 : Form
    {
        //private List<Song> _songs = [];
        private AppDbContext _db = new AppDbContext();

        public Form1()
        {
            InitializeComponent();

            _db.Database.EnsureCreated();

            // Songs 테이블이 비어있으면 초기 데이터 추가
            if (!_db.Songs.Any())
            {
                List<Song> initialSongs = [
                    new("Blue Hour", "LUNA8", 5),
                    new("도깨비불 (Ghostfire)", "X-CROSS", 4),
                    new("Spicy Love", "Cherry Bomb", 5),
                    new("신기루 (Mirage)", "ONE-WAY", 3),
                    new("Hypnotized", "NEXUS", 4),
                    new("첫사랑 법칙 (First Love Rule)", "Pureum", 5),
                    new("Black Out", "Viper", 4),
                    new("한여름 밤의 꿈 (Midsummer)", "SOLO", 5),
                    new("Cyberpunk", "GLITCH", 4),
                    new("별자리 (Constellation)", "Aura", 3),
                    new("Bad Boy, Good Girl", "TRIGGER", 5),
                    new("소리쳐 (Shout Out)", "ZEAL", 4),
                    new("Velvet Dress", "Siren", 5),
                    new("그림자놀이 (Shadow)", "ECLIPSE", 4),
                    new("Neon City", "Beat Runners", 3),
                    new("비밀정원 (Secret)", "Fairy Tale", 5),
                    new("Crash Landing", "Sledge", 4),
                    new("눈이 부시게 (Blinding)", "DAWN", 5),
                    new("Wildfire", "ASHE", 4),
                    new("시간을 달려서 (Time Warp)", "Nova", 4)
                ];

                _db.Songs.AddRange(initialSongs);
                _db.SaveChanges();
            }

            //var filteredSongs = _db.Songs
            //    .Where(s => s.Rating >= 4)
            //    .OrderByDescending(s => s.Rating);

            //foreach (var song in filteredSongs) {
            //    listSong.Items.Add(song);
            //}

            LoadSongs();
        }

        private void OnAdd(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string artist = txtArtist.Text.Trim();

            if (title.Length == 0 || artist.Length == 0)
            {
                MessageBox.Show("제목과 가수를 모두 입력하세요.");
                return;
            }

            if (!int.TryParse(txtRating.Text, out int rating) || rating < 1 || rating > 5)
            {
                MessageBox.Show("평점은 1~5 사이의 숫자로 입력하세요.");
                txtRating.SelectAll();
                txtRating.Focus();
                return;
            }

            var song = new Song(title, artist, rating);

            _db.Songs.Add(song);
            _db.SaveChanges();

            LoadSongs();

            txtTitle.Clear();
            txtArtist.Clear();
            txtRating.Clear();
            txtTitle.Focus();
        }

        private void LoadSongs()
        {
            ListSong.Items.Clear();

            var songs = _db.Songs
                //.Where(s => s.Rating >= 4)
                .OrderByDescending(s => s.Rating)
                .ToList();

            foreach (var song in songs)
                ListSong.Items.Add(song);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (ListSong.SelectedItem is not Song song)
                return;

            var result = MessageBox.Show(
                $"{song.ToString()}\n\n노래를 삭제할까요?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _db.Songs.Remove(song);
            _db.SaveChanges();

            LoadSongs();

            txtSelected.Clear();
            btnDelete.Enabled = false;
        }

        private void OnChanged(object sender, EventArgs e)
        {
            if (ListSong.SelectedItem is not Song song)
            {
                txtSelected.Clear();
                btnDelete.Enabled = false;
                return;
            }

            txtSelected.Text = song.ToString();
            btnDelete.Enabled = true;
        }

        private void OnYoutube(object sender, EventArgs e)
        {
            // 혹시 빈 공간 더블클릭할까봐 검사
            if (ListSong.SelectedItem is not Song song)
                return;

            string query = Uri.EscapeDataString($"노래방 {song.Title} {song.Artist}");

            Process.Start(new ProcessStartInfo(
                $"https://www.youtube.com/results?search_query={query}")
            {
                UseShellExecute = true
            });
        }
    }

    public record Song(string Title, string Artist, int Rating)
    {
        public int Id { get; init; }

        public override string ToString() => $"{Title} - [{Artist}] ({Rating})";
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // songs.db 파일로 저장
            optionsBuilder.UseSqlite("Data Source=songs.db");
        }
    }
}
