using System.Collections.Generic;
using BLL.Interface;
using DAL.Interface;
using BTL_PhatTrienPM.Models;

namespace BLL
{
    public class BLL_DichVu : IBLL_DichVu
    {
        private readonly IDAL_DichVu _dal;

        public BLL_DichVu(IDAL_DichVu dal)
        {
            _dal = dal;
        }

        public List<DichVu> GetAll() => _dal.GetAll();

        public DichVu GetById(int id) => _dal.GetById(id);

        public bool Create(DichVu model) => _dal.Create(model) > 0;

        public bool Update(DichVu model) => _dal.Update(model) > 0;

        public bool Delete(int id) => _dal.Delete(id) > 0;
    }
}