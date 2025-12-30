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

        // 1. Lấy danh sách
        public List<VeDTO> GetAllVe()
        {
            var listVe = _context.Ves.ToList();
            // Chuyển từ Model sang DTO
            return listVe.Select(v => new VeDTO
            {
                MaVe = v.MaVe,
                TenVe = v.TenVe,
                MoTa = v.MoTa,
                GiaBan = v.GiaBan,
                SoChoToiDa = v.SoChoToiDa,
                HinhAnh = v.HinhAnh,
                LinkBanDo = v.LinkBanDo
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
                LinkBanDo = v.LinkBanDo
            };
        }

        // 3. Thêm mới
        public void AddVe(VeDTO veDto)
        {
            var newVe = new Ve
            {
                TenVe = veDto.TenVe,
                MoTa = veDto.MoTa,
                GiaBan = veDto.GiaBan,
                SoChoToiDa = veDto.SoChoToiDa,
                HinhAnh = veDto.HinhAnh,
                LinkBanDo = veDto.LinkBanDo,
                // Lấy ngày hiện tại
                NgayTao = DateOnly.FromDateTime(DateTime.Now)
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