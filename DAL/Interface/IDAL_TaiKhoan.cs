namespace DAL.Interface
{
    public interface IDAL_TaiKhoan
    {
        // Viết hoa chữ đầu theo yêu cầu
        (string message, bool isSuccess) Create(string username, string password);
    }
}