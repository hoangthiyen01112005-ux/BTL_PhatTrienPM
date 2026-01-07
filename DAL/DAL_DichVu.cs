using DAL.Interface;
using DAL_DatabaseHelper;
using BTL_PhatTrienPM.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DAL_DichVu : IDAL_DichVu
    {
        private readonly IDatabaseHelper _db;

        public DAL_DichVu(IDatabaseHelper db)
        {
            _db = db;
        }

        public List<DichVu> GetAll()
        {
            string sql = "SELECT * FROM DichVu";
            return _db.ExecuteReader<DichVu>(sql, null);
        }

        public DichVu GetById(int id)
        {
            string sql = "SELECT * FROM DichVu WHERE MaDichVu = @id";
            var pars = new Dictionary<string, object> { { "@id", id } };
            return _db.ExecuteReader<DichVu>(sql, pars).FirstOrDefault();
        }

        public int Create(DichVu model)
        {
            string sql = "INSERT INTO DichVu (TenDichVu, LoaiDichVu, GiaNhap) VALUES (@ten, @loai, @gia)";
            var pars = new Dictionary<string, object>
            {
                { "@ten", model.TenDichVu },
                { "@loai", model.LoaiDichVu },
                { "@gia", model.GiaNhap }
            };
            return _db.ExecuteNonQuery(sql, pars);
        }

        public int Update(DichVu model)
        {
            string sql = "UPDATE DichVu SET TenDichVu = @ten WHERE MaDichVu = @id";
            var pars = new Dictionary<string, object> { { "@ten", model.TenDichVu }, { "@id", model.MaDichVu } };
            return _db.ExecuteNonQuery(sql, pars);
        }

        public int Delete(int id)
        {
            string sql = "DELETE FROM DichVu WHERE MaDichVu = @id";
            var pars = new Dictionary<string, object> { { "@id", id } };
            return _db.ExecuteNonQuery(sql, pars);
        }
    }
}