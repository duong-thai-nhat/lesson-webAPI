using WebAPIApp.Models;

namespace WebAPIApp.Services
{
    public interface IHangHoaService
    {
        List<HangHoa> GetAll();

        HangHoa GetById(string id);

        HangHoa Create(HangHoaVM hangHoaVM );

        HangHoa Update(string id, HangHoa hangHoaEdit);

        HangHoa Delete(string id);
    }
}
