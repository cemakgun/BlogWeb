using BlogWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly DatabaseContext _context;

        public PostsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(string? kelime)
        {
            if (kelime != null)
            {
                var aramaSonuclari = await _context.Posts.Where(p => p.Title.Contains(kelime) || p.Description.Contains(kelime)).ToListAsync();
                return View(aramaSonuclari);
            }
            var liste = await _context.Posts.ToListAsync();
            return View(liste);
        }
        public async Task<IActionResult> DetailAsync(int id)
        {
            var kayit = await _context.Posts.FindAsync(id);
            if (kayit == null) return NotFound();
            return View(kayit);
        }
    }
}
