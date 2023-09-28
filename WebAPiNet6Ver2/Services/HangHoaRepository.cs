using Microsoft.EntityFrameworkCore;
using WebAPiNet6Ver2.Data;
using WebAPiNet6Ver2.Models;
using HangHoa = WebAPiNet6Ver2.Data.HangHoa;

namespace WebAPiNet6Ver2.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDbContext _dbContext;
        public static int PAGE_SIZE { get; set; } = 2;
        public HangHoaRepository(MyDbContext context) { 
            _dbContext = context;
        }

        public HangHoaVM Add(HangHoaModel model)
        {
            var hanghoa = new HangHoa
            {
                TenHh = model.TenHangHoa,
                DonGia = model.DonGia,
                MoTa = model.Mota,
            };
            _dbContext.Add(hanghoa);
            _dbContext.SaveChanges();
            return new HangHoaVM
            {
                TenHangHoa = model.TenHangHoa,
                DonGia = model.DonGia,
            };
        }

        public List<HangHoaModel> GetAll(string search, double? from, double? to,
            string sortBy, int page)
        {
            var allProducts = _dbContext.hangHoas.Include(h => h.category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(h => h.TenHh.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(h => h.DonGia >= from);
            }
            if(to.HasValue)
            {
                allProducts = allProducts.Where(h => h.DonGia <= to);
            }
            #endregion
            #region Sorting
            //default sort by Name(TenHh)
            allProducts = allProducts.OrderBy(h => h.TenHh);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(
                        h => h.TenHh); break;
                    case "gia_asc": allProducts = allProducts.OrderBy(
                        h => h.DonGia); break;
                    case "gia_desc": allProducts = allProducts.OrderByDescending(
                        h => h.DonGia); break;
                }
            }
            #endregion

            //cách 1
            /*#region Paging
            allProducts = allProducts.Skip((page -1) * PAGE_SIZE).Take(PAGE_SIZE);
            #endregion
            var result = allProducts.Select(h => new HangHoaModel
            {
                MaHangHoa = h.MaHh,
                TenHangHoa = h.TenHh,
                DonGia = h.DonGia,
                TenLoai = h.category.TenLoai,
            });
            return result.ToList();*/

            var result = PaginatedList<HangHoa>.Create(allProducts, page, PAGE_SIZE);

            return result.Select(h => new HangHoaModel
            {
                MaHangHoa = h.MaHh,
                TenHangHoa = h.TenHh,
                DonGia = h.DonGia,
                TenLoai = h.category.TenLoai,
            }).ToList();

            
        }
    }
}
