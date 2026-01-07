using System.Collections.Generic;
using BTL_PhatTrienPM.Models;

namespace BLL.Interface
{
    public interface IBLL_DichVu
    {
        // Lấy danh sách toàn bộ dịch vụ
        List<DichVu> GetAll();

        // Lấy chi tiết một dịch vụ theo ID
        DichVu GetById(int id);

        // Tạo mới dịch vụ (trả về bool để xác nhận thành công hay thất bại)
        bool Create(DichVu model);

        // Cập nhật dịch vụ
        bool Update(DichVu model);

        // Xóa dịch vụ
        bool Delete(int id);
    }
}