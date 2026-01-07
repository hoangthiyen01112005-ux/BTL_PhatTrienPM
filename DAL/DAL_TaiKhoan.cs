using DAL.Interface;
using DAL_DatabaseHelper;
using System;

namespace DAL
{
    public class DAL_TaiKhoan : IDAL_TaiKhoan
    {
        private readonly IDatabaseHelper _db;
        public DAL_TaiKhoan(IDatabaseHelper db)
        {
            _db = db;
        }

        public (string message, bool isSuccess) Create(string username, string password)
        {
            try
            {
                // Logic xử lý database ở đây
                return ("Thành công", true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }
    }
}