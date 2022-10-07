using BlogWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace BlogWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(int id) // id : route dan gelecek kategori id
        {
            //var model = await _context.Categories.FindAsync(id);
            var model = await _context.Categories.Include(p => p.Posts).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }
    }
}
