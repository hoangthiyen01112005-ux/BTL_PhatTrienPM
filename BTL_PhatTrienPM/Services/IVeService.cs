using BTL_PhatTrienPM.DTOs;

namespace BTL_PhatTrienPM.Services.Interfaces
{
    public interface IVeService
    {
        List<VeDTO> GetAllVe(string? keyword = null);
        VeDTO GetVeById(int id);
        void AddVe(VeDTO veDto);
        void UpdateVe(int id, VeDTO veDto);
        void DeleteVe(int id);
    }
}