using WebAPiNet6Ver2.Models;

namespace WebAPiNet6Ver2.Services
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy,int page);
        HangHoaVM Add(HangHoaModel model);
    }
}
