using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTL_PhatTrienPM.Models;

namespace BTL_PhatTrienPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesController : ControllerBase
    {
        private readonly DaTravelContext _context;

        public VesController(DaTravelContext context)
        {
            _context = context;
        }

        // GET: api/Ves (Lấy danh sách)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ve>>> GetVes()
        {
            // Nếu bảng Ve có liên kết với DichVu, dùng Include để lấy luôn tên Dịch vụ
            return await _context.Ves.Include(v => v.MaDichVuNavigation).ToListAsync();
        }

        // GET: api/Ves/5 (Lấy 1 cái)
        [HttpGet("{id}")]
        public async Task<ActionResult<Ve>> GetVe(int id)
        {
            var ve = await _context.Ves.FindAsync(id);

            if (ve == null)
            {
                return NotFound();
            }

            return ve;
        }

        // POST: api/Ves (Thêm mới)
        [HttpPost]
        public async Task<ActionResult<Ve>> PostVe(Ve ve)
        {
            _context.Ves.Add(ve);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVe", new { id = ve.MaVe }, ve);
        }

        // DELETE: api/Ves/5 (Xóa)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVe(int id)
        {
            var ve = await _context.Ves.FindAsync(id);
            if (ve == null)
            {
                return NotFound();
            }

            _context.Ves.Remove(ve);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}