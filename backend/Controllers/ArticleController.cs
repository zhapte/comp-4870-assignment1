
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data;

public class ArticleController : Controller
{
    private readonly ApplicationDbContext _context;

    public ArticleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ARTICLES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Article.ToListAsync());
    }

    // GET: ARTICLES/Details/5
    public async Task<IActionResult> Details(int? articleid)
    {
        if (articleid == null)
        {
            return NotFound();
        }

        var article = await _context.Article
            .FirstOrDefaultAsync(m => m.ArticleId == articleid);
        if (article == null)
        {
            return NotFound();
        }

        return View(article);
    }

    // GET: ARTICLES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ARTICLES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,ReleaseDate,Genre,Price")] Article article)
    {
        if (ModelState.IsValid)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    // GET: ARTICLES/Edit/5
    public async Task<IActionResult> Edit(int? articleid)
    {
        if (articleid == null)
        {
            return NotFound();
        }

        var article = await _context.Article.FindAsync(articleid);
        if (article == null)
        {
            return NotFound();
        }
        return View(article);
    }

    // POST: ARTICLES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? articleid, [Bind("Id,Title,ReleaseDate,Genre,Price")] Article article)
    {
        if (articleid != article.ArticleId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(article);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(article.ArticleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    // GET: ARTICLES/Delete/5
    public async Task<IActionResult> Delete(int? articleid)
    {
        if (articleid == null)
        {
            return NotFound();
        }

        var article = await _context.Article
            .FirstOrDefaultAsync(m => m.ArticleId == articleid);
        if (article == null)
        {
            return NotFound();
        }

        return View(article);
    }

    // POST: ARTICLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? articleid)
    {
        var article = await _context.Article.FindAsync(articleid);
        if (article != null)
        {
            _context.Article.Remove(article);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ArticleExists(int? articleid)
    {
        return _context.Article.Any(e => e.ArticleId == articleid);
    }
}
