
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgApp1.Models;
using ProgApp1.Data;

public class StudentResultsController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentResultsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: STUDENTRESULTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.StudentResults.ToListAsync());
    }

    // GET: STUDENTRESULTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentresult = await _context.StudentResults
            .FirstOrDefaultAsync(m => m.ID == id);
        if (studentresult == null)
        {
            return NotFound();
        }

        return View(studentresult);
    }

    // GET: STUDENTRESULTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTRESULTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,StudentID,Subject,Mark,Student")] StudentResult studentresult)
    {
        if (ModelState.IsValid)
        {
            _context.Add(studentresult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(studentresult);
    }

    // GET: STUDENTRESULTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentresult = await _context.StudentResults.FindAsync(id);
        if (studentresult == null)
        {
            return NotFound();
        }
        return View(studentresult);
    }

    // POST: STUDENTRESULTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("ID,StudentID,Subject,Mark,Student")] StudentResult studentresult)
    {
        if (id != studentresult.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(studentresult);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentResultExists(studentresult.ID))
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
        return View(studentresult);
    }

    // GET: STUDENTRESULTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var studentresult = await _context.StudentResults
            .FirstOrDefaultAsync(m => m.ID == id);
        if (studentresult == null)
        {
            return NotFound();
        }

        return View(studentresult);
    }

    // POST: STUDENTRESULTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var studentresult = await _context.StudentResults.FindAsync(id);
        if (studentresult != null)
        {
            _context.StudentResults.Remove(studentresult);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentResultExists(int? id)
    {
        return _context.StudentResults.Any(e => e.ID == id);
    }
}
