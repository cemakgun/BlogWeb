using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogWeb.Data;
using BlogWeb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PostsController : Controller // S.O.L.I.D Prensipleri
    {
        private readonly DatabaseContext _context; // Burada DatabaseContext i kendimiz new lemek yerine 

        public PostsController(DatabaseContext context) // Dependency Injection : Bağımlılık enjeksiyonu
        {
            _context = context;
        }

        // GET: PostsController
        public async Task<ActionResult> Index()
        {
            var model = await _context.Posts.ToListAsync();

            return View(model);
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostsController/Create
        public async Task<IActionResult> CreateAsync()
        {
            var kategoriler = await _context.Categories.ToListAsync();

            ViewBag.CategoryId = new SelectList(kategoriler, "Id", "Name");

            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                    {
                        string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream = new FileStream(directory, FileMode.Create); // Buradaki using ifadesi stream isimli değişkenin işinin bittikten sonra bellekten atılmasını sağlar
                        await Image.CopyToAsync(stream); // resmi asenkron olarak yükledik
                        post.Image = Image.FileName;
                    }
                    await _context.Posts.AddAsync(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }
            }
            var kategoriler = await _context.Categories.ToListAsync();

            ViewBag.CategoryId = new SelectList(kategoriler, "Id", "Name");

            return View(post);
        }

        // GET: PostsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var kayit = await _context.Posts.FindAsync(id);

            var kategoriler = await _context.Categories.ToListAsync();

            ViewBag.CategoryId = new SelectList(kategoriler, "Id", "Name");

            return View(kayit);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Post post, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null)
                    {
                        string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream = new FileStream(directory, FileMode.Create);
                        await Image.CopyToAsync(stream);
                        post.Image = Image.FileName;
                    }
                    _context.Posts.Update(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }
            }
            var kategoriler = await _context.Categories.ToListAsync();

            ViewBag.CategoryId = new SelectList(kategoriler, "Id", "Name");

            return View(post);
        }

        // GET: PostsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var kayit = await _context.Posts.FindAsync(id);

            return View(kayit);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Post post)
        {
            try
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
