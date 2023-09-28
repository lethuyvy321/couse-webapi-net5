using WebAPiNet6Ver2.Models;

namespace WebAPiNet6Ver2.Services
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryViewModel> ViewModels = new List<CategoryViewModel>
        {
            new CategoryViewModel{MaLoai = 1, TenLoai = "Tivi"},
            new CategoryViewModel{MaLoai = 2, TenLoai = "Tủ lạnh"},
            new CategoryViewModel{MaLoai = 3, TenLoai = "Điều hòa"},
            new CategoryViewModel{MaLoai = 4, TenLoai = "Máy giặt"},
        };
        public CategoryViewModel Add(CategoryModel model)
        {
            var loai = new CategoryViewModel
            {
                MaLoai = ViewModels.Max(lo => lo.MaLoai) + 1,
                TenLoai = model.TenLoai
            };
            ViewModels.Add(loai);
            return loai;
        }

        public void Delete(int id)
        {
            var loai = ViewModels.SingleOrDefault(lo => lo.MaLoai == id);
            ViewModels.Remove(loai);
        }

        public List<CategoryViewModel> GetAll()
        {
            return ViewModels;
        }

        public CategoryViewModel GetById(int id)
        {
            return ViewModels.SingleOrDefault(lo => lo.MaLoai == id);
        }

        public void Update(CategoryViewModel model)
        {
            var loai =  ViewModels.SingleOrDefault(lo => lo.MaLoai == model.MaLoai);
            if(loai != null)
            {
                loai.TenLoai = model.TenLoai;
            }
        }
    }
}
