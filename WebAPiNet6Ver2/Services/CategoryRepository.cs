using WebAPiNet6Ver2.Data;
using WebAPiNet6Ver2.Models;

namespace WebAPiNet6Ver2.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _dbContext;
        public CategoryRepository(MyDbContext context) { 
            _dbContext = context;
        }
        public CategoryViewModel Add(CategoryModel model)
        {
            var category = new Category { 
                TenLoai = model.TenLoai,
            };
            _dbContext.Add(category);
            _dbContext.SaveChanges();
            return new CategoryViewModel
            {
                MaLoai = category.MaLoai,
                TenLoai = category.TenLoai,
            };
        }

        public void Delete(int id)
        {
            var loai = _dbContext.Categories.SingleOrDefault(c => c.MaLoai == id);
            if (loai != null)
            {
                _dbContext.Remove(loai);
                _dbContext.SaveChanges();
            }
        }

        public List<CategoryViewModel> GetAll()
        {
            var loais = _dbContext.Categories.Select(c => new CategoryViewModel
            {
                MaLoai = c.MaLoai,
                TenLoai = c.TenLoai,
            });
            return loais.ToList();
        }

        public CategoryViewModel GetById(int id)
        {
            var loai = _dbContext.Categories.SingleOrDefault(c => c.MaLoai == id);
            if (loai != null)
            {
                return new CategoryViewModel
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai,
                };
            }
            else
                return null;
                
        }

        public void Update(CategoryViewModel model)
        {
            var loai = _dbContext.Categories.SingleOrDefault(c => c.MaLoai == model.MaLoai);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _dbContext.SaveChanges();
            }
        }
    }
}
