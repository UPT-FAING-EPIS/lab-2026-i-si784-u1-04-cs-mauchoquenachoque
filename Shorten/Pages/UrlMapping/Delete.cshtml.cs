using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shorten.Areas.Domain;

namespace Shorten.Pages.UrlMapping;

public class DeleteModel : PageModel
{
    private readonly ShortenContext _context;

    public DeleteModel(ShortenContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Shorten.Areas.Domain.UrlMapping UrlMapping { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urlmapping = await _context.UrlMappings.FirstOrDefaultAsync(m => m.Id == id);

        if (urlmapping == null)
        {
            return NotFound();
        }
        else
        {
            UrlMapping = urlmapping;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urlmapping = await _context.UrlMappings.FindAsync(id);
        if (urlmapping != null)
        {
            UrlMapping = urlmapping;
            _context.UrlMappings.Remove(UrlMapping);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
