using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace G26W07WFSongList // 프로젝트 네임스페이스는 기존 그대로 유지
{
    public partial class Form1 : Form
    {
        private AppDbContext _db = new AppDbContext();

        public Form1()
        {
            InitializeComponent();

            // cars.db 데이터베이스 및 테이블 생성
            _db.Database.EnsureCreated();

            // Cars 테이블이 비어있으면 초기 자동차 데이터 추가
            if (!_db.Cars.Any())
            {
                List<Car> initialCars = [
                    new("아반떼 (Avante)", "현대 (Hyundai)", 5),
                    new("쏘렌토 (Sorento)", "기아 (Kia)", 5),
                    new("그랜저 (Grandeur)", "현대 (Hyundai)", 4),
                    new("카니발 (Carnival)", "기아 (Kia)", 5),
                    new("G80", "제네시스 (Genesis)", 5),
                    new("GV70", "제네시스 (Genesis)", 4),
                    new("스포티지 (Sportage)", "기아 (Kia)", 4),
                    new("싼타페 (Santa Fe)", "현대 (Hyundai)", 4),
                    new("토레스 (Torres)", "KGM", 3),
                    new("Model Y", "테슬라 (Tesla)", 5),
                    new("5 Series", "BMW", 5),
                    new("E-Class", "벤츠 (Mercedes-Benz)", 5),
                    new("A6", "아우디 (Audi)", 4),
                    new("Golf", "폭스바겐 (Volkswagen)", 3),
                    new("911 Carrera", "포르쉐 (Porsche)", 5),
                    new("XC60", "볼보 (Volvo)", 4),
                    new("Camry", "토요타 (Toyota)", 4),
                    new("ES 300h", "렉서스 (Lexus)", 5),
                    new("Mustang", "포드 (Ford)", 4),
                    new("Wrangler", "지프 (Jeep)", 3)
                ];

                _db.Cars.AddRange(initialCars);
                _db.SaveChanges();
            }

            LoadCars();
        }

        private void OnAdd(object sender, EventArgs e)
        {
            // 기존 텍스트박스 컨트롤 이름(txtTitle, txtArtist, txtRating)을 그대로 활용
            string model = txtTitle.Text.Trim();
            string brand = txtArtist.Text.Trim();

            if (model.Length == 0 || brand.Length == 0)
            {
                MessageBox.Show("모델명과 제조사를 모두 입력하세요.");
                return;
            }

            if (!int.TryParse(txtRating.Text, out int rating) || rating < 1 || rating > 5)
            {
                MessageBox.Show("평점은 1~5 사이의 숫자로 입력하세요.");
                txtRating.SelectAll();
                txtRating.Focus();
                return;
            }

            var car = new Car(model, brand, rating);

            _db.Cars.Add(car);
            _db.SaveChanges();

            LoadCars();

            txtTitle.Clear();
            txtArtist.Clear();
            txtRating.Clear();
            txtTitle.Focus();
        }

        private void LoadCars()
        {
            ListCar.Items.Clear();

            // 검색어도 소문자로 변환해야 대문자 입력 시 정상 검색됨
            string keyword = txtFilter.Text.Trim().ToLower();

            var cars = _db.Cars
                .Where(c => c.Model.ToLower().Contains(keyword) ||
                            c.Brand.ToLower().Contains(keyword))
                .OrderByDescending(c => c.Rating)
                .ToList();

            foreach (var car in cars)
                ListCar.Items.Add(car);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (ListCar.SelectedItem is not Car car)
                return;

            var result = MessageBox.Show(
                $"{car}\n\n이 자동차 정보를 삭제할까요?",
                "삭제 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _db.Cars.Remove(car);
            _db.SaveChanges();

            LoadCars();

            txtSelected.Clear();
            btnAdd.Enabled = false;
        }

        private void OnChanged(object sender, EventArgs e)
        {
            if (ListCar.SelectedItem is not Car car)
            {
                txtSelected.Clear();
                btnAdd.Enabled = false;
                return;
            }

            txtSelected.Text = car.ToString();
            btnAdd.Enabled = true;
        }

        private void OnYoutube(object sender, EventArgs e)
        {
            // 빈 공간 더블클릭 방지
            if (ListCar.SelectedItem is not Car car)
                return;

            // 유튜브에 '자동차 시승기 [제조사] [모델명]'으로 검색
            string query = Uri.EscapeDataString($"자동차 시승기 {car.Brand} {car.Model}");

            Process.Start(new ProcessStartInfo(
                $"https://www.youtube.com/results?search_query={query}")
            {
                UseShellExecute = true
            });
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            LoadCars();
        }
    }

    // 자동차 데이터 레코드 (모델명, 제조사, 평점)
    public record Car(string Model, string Brand, int Rating)
    {
        public int Id { get; init; }

        public override string ToString() => $"{Model} - [{Brand}] (★{Rating})";
    }

    // EF Core 데이터베이스 컨텍스트
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 기존 songs.db와 테이블 구조가 다르므로 cars.db라는 새 파일로 저장
            optionsBuilder.UseSqlite("Data Source=cars.db");
        }
    }
}