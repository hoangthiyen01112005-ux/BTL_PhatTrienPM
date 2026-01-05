using BTL_PhatTrienPM.DTOs;

namespace BTL_PhatTrienPM.Services.Interfaces
{
    public interface IGioHangService
    {
        // 1. Xem giỏ hàng của một khách
        List<GioHangOutputDTO> GetGioHangByKhachHang(int maKhachHang);

        // 2. Thêm vé vào giỏ
        void AddToCart(GioHangInputDTO input);

        // 3. Xóa một món khỏi giỏ
        void RemoveFromCart(int maGioHang);
    }
}