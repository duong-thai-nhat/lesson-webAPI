using WebAPIApp.Models;

namespace WebAPIApp.Services
{
    public class HangHoaService : IHangHoaService
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>() {
            new HangHoa {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = "Laptop Gaming",
                DonGia = 23000000
            },
            new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = "Laptop Gaming",
                DonGia = 23000000
            }
        };

        public List<HangHoa> GetAll()
        {
            return hangHoas;
        }

        public HangHoa GetById(string id)
        {
            // LINQ [Object] Query
            var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
            return hangHoa;
        }

        public HangHoa Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hanghoa);
            return hanghoa;
        }

        public HangHoa Update(string id, HangHoa hangHoaEdit)
        {
            var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
            if (hangHoa == null)
                return null;
            //Update
            hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
            hangHoa.DonGia = hangHoaEdit.DonGia;
            return hangHoa;
        }

        public HangHoa Delete(string id)
        {
            var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
            if (hangHoa == null)
                return null;
            hangHoas.Remove(hangHoa);
            return hangHoa;
        }
    }
}
