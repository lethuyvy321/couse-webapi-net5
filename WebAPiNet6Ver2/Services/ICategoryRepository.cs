using WebAPiNet6Ver2.Models;

namespace WebAPiNet6Ver2.Services
{
    public interface ICategoryRepository
    {
        List<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel Add(CategoryModel model);
        void Update(CategoryViewModel model);
        void Delete(int id);

    }
}
