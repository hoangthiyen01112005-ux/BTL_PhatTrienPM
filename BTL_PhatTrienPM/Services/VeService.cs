using BTL_PhatTrienPM.Models;
using BTL_PhatTrienPM.DTOs;
using BTL_PhatTrienPM.Services.Interfaces;

namespace BTL_PhatTrienPM.Services.Implements
{
    public class VeService : IVeService
    {
        private readonly DaTravelContext _context;

        public VeService(DaTravelContext context)
        {
            _context = context;
        }

        // 1. Lấy danh sách (Có tìm kiếm)
        public List<VeDTO> GetAllVe(string? keyword = null)
        {
            var query = _context.Ves.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(v => v.TenVe.Contains(keyword));
            }

            return query.Select(v => new VeDTO
            {
                MaVe = v.MaVe,
                TenVe = v.TenVe,
                MoTa = v.MoTa,
                GiaBan = v.GiaBan,
                SoChoToiDa = v.SoChoToiDa,
                HinhAnh = v.HinhAnh,
                LinkBanDo = v.LinkBanDo,

                // --- FIX LỖI 1: Xử lý NULL ---
                // Nếu trong DB là null thì lấy giá trị mặc định (DateTime.MinValue hoặc DateTime.Now)
                // Hoặc dùng .GetValueOrDefault()
                NgayKhoiHanh = v.NgayKhoiHanh.GetValueOrDefault(),
                NgayKetThuc = v.NgayKetThuc.GetValueOrDefault(),

                PhienBan = v.PhienBan
            }).ToList();
        }

        // 2. Lấy chi tiết
        public VeDTO GetVeById(int id)
        {
            var v = _context.Ves.Find(id);
            if (v == null) return null;

            return new VeDTO
            {
                MaVe = v.MaVe,
                TenVe = v.TenVe,
                MoTa = v.MoTa,
                GiaBan = v.GiaBan,
                SoChoToiDa = v.SoChoToiDa,
                HinhAnh = v.HinhAnh,
                LinkBanDo = v.LinkBanDo,

                // --- FIX LỖI 1: Xử lý NULL ---
                NgayKhoiHanh = v.NgayKhoiHanh.GetValueOrDefault(),
                NgayKetThuc = v.NgayKetThuc.GetValueOrDefault(),

                PhienBan = v.PhienBan
            };
        }

        // 3. Thêm mới
        public void AddVe(VeDTO veDto)
        {
            // Validate
            if (veDto.NgayKetThuc < veDto.NgayKhoiHanh)
            {
                throw new Exception("Ngày kết thúc không được nhỏ hơn ngày khởi hành");
            }

            var newVe = new Ve
            {
                TenVe = veDto.TenVe,
                MoTa = veDto.MoTa,
                GiaBan = veDto.GiaBan,
                SoChoToiDa = veDto.SoChoToiDa,
                HinhAnh = veDto.HinhAnh,
                LinkBanDo = veDto.LinkBanDo,
                NgayKhoiHanh = veDto.NgayKhoiHanh,
                NgayKetThuc = veDto.NgayKetThuc,

                // --- FIX LỖI 2: Sai kiểu dữ liệu ---
                // Database dùng DateTime, không dùng DateOnly
                // Dùng DateTime.Now để lấy ngày giờ hiện tại
                NgayTao = DateTime.Now
            };
            _context.Ves.Add(newVe);
            _context.SaveChanges();
        }

        // 4. Cập nhật
        public void UpdateVe(int id, VeDTO veDto)
        {
            var ve = _context.Ves.Find(id);
            if (ve != null)
            {
                ve.TenVe = veDto.TenVe;
                ve.MoTa = veDto.MoTa;
                ve.GiaBan = veDto.GiaBan;
                ve.SoChoToiDa = veDto.SoChoToiDa;
                ve.HinhAnh = veDto.HinhAnh;
                ve.LinkBanDo = veDto.LinkBanDo;

                ve.NgayKhoiHanh = veDto.NgayKhoiHanh;
                ve.NgayKetThuc = veDto.NgayKetThuc;

                _context.SaveChanges();
            }
        }

        // 5. Xóa
        public void DeleteVe(int id)
        {
            var ve = _context.Ves.Find(id);
            if (ve != null)
            {
                _context.Ves.Remove(ve);
                _context.SaveChanges();
            }
        }
    }
}