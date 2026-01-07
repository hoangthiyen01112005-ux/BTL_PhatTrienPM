using BTL_PhatTrienPM.Models;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IDAL_DichVu
    {
        List<DichVu> GetAll();
        DichVu GetById(int id);
        int Create(DichVu model); // Trả về số dòng thành công (int)
        int Update(DichVu model);
        int Delete(int id);
    }
}