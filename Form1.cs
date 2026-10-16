using Microsoft.EntityFrameworkCore;
using System.Data;

namespace G26W07WFSongList
{
    // 노래 정보 레코드 정의 및 출력 형식 재정의
    public record Song(int Id, string Title, string Artist, int Rating)
    {
        public override string ToString() => $"{Title} - [{Artist}] ({Rating})";
    }

    // SQLite 연동을 위한 EF Core DbContext 클래스
    public class AppDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 실행 폴더 내 songs.db 파일로 저장
            optionsBuilder.UseSqlite("Data Source=songs.db");
        }
    }

    public partial class Form1 : Form
    {
        private List<Song> _songs = [];
        private AppDbContext _db = new AppDbContext();

        public Form1()
        {
            InitializeComponent();
            InitDatabase();
            LoadSongs();
        }

        // DB 초기화 및 최초 더미 데이터 저장
        private void InitDatabase()
        {
            _db.Database.EnsureCreated(); // songs.db 파일 및 테이블 생성

            // DB가 비어있으면 초기 더미 데이터 20개 삽입
            if (!_db.Songs.Any())
            {
                List<Song> initialSongs = [
                    new(1, "Blue Hour", "LUNA8", 5),
                    new(2, "도깨비불 (Ghostfire)", "X-CROSS", 4),
                    new(3, "Spicy Love", "Cherry Bomb", 5),
                    new(4, "신기루 (Mirage)", "ONE-WAY", 3),
                    new(5, "Hypnotized", "NEXUS", 4),
                    new(6, "첫사랑 법칙 (First Love Rule)", "Pureum", 5),
                    new(7, "Black Out", "Viper", 4),
                    new(8, "한여름 밤의 꿈 (Midsummer)", "SOLO", 5),
                    new(9, "Cyberpunk", "GLITCH", 4),
                    new(10, "별자리 (Constellation)", "Aura", 3),
                    new(11, "Bad Boy, Good Girl", "TRIGGER", 5),
                    new(12, "소리쳐 (Shout Out)", "ZEAL", 4),
                    new(13, "Velvet Dress", "Siren", 5),
                    new(14, "그림자놀이 (Shadow)", "ECLIPSE", 4),
                    new(15, "Neon City", "Beat Runners", 3),
                    new(16, "비밀정원 (Secret)", "Fairy Tale", 5),
                    new(17, "Crash Landing", "Sledge", 4),
                    new(18, "눈이 부시게 (Blinding)", "DAWN", 5),
                    new(19, "Wildfire", "ASHE", 4),
                    new(20, "시간을 달려서 (Time Warp)", "Nova", 4)
                ];

                _db.Songs.AddRange(initialSongs);
                _db.SaveChanges();
            }
        }

        // DB에서 전체 목록 불러오기
        private void LoadSongs()
        {
            _songs = _db.Songs.ToList();
            ListSong.DataSource = _songs;
        }

        // 응용 1: 별점 4점 이상 곡만 내림차순 필터링
        private void OnFilterHighRating(object sender, EventArgs e)
        {
            var filteredSongs = _songs
                .Where(s => s.Rating >= 4)
                .OrderByDescending(s => s.Rating)
                .ToList();

            ListSong.DataSource = filteredSongs;
        }

        // 응용 2: 키워드 검색 (제목 또는 가수 이름 포함 여부)
        private void OnSearch(string keyword)
        {
            var searchedSongs = from s in _songs
                                where s.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                   || s.Artist.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                orderby s.Rating descending
                                select s;

            ListSong.DataSource = searchedSongs.ToList();
        }
    }
}