using BTL_PhatTrienPM.DTOs;

namespace BTL_PhatTrienPM.Services.Interfaces
{
    public interface IVeService
    {
        List<VeDTO> GetAllVe();           // Lấy hết
        VeDTO GetVeById(int id);          // Lấy 1 cái
        void AddVe(VeDTO veDto);          // Thêm
        void UpdateVe(int id, VeDTO veDto); // Sửa
        void DeleteVe(int id);            // Xóa
    }
}