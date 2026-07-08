using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shorten.Areas.Domain;

namespace Shorten.Pages.UrlMapping;

public class DetailsModel : PageModel
{
    private readonly ShortenContext _context;

    public DetailsModel(ShortenContext context)
    {
        _context = context;
    }

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
}
