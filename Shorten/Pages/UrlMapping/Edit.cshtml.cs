using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shorten.Areas.Domain;

namespace Shorten.Pages.UrlMapping;

public class EditModel : PageModel
{
    private readonly ShortenContext _context;

    public EditModel(ShortenContext context)
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

        var urlmapping =  await _context.UrlMappings.FirstOrDefaultAsync(m => m.Id == id);
        if (urlmapping == null)
        {
            return NotFound();
        }
        UrlMapping = urlmapping;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(UrlMapping).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UrlMappingExists(UrlMapping.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool UrlMappingExists(int id)
    {
        return _context.UrlMappings.Any(e => e.Id == id);
    }
}
