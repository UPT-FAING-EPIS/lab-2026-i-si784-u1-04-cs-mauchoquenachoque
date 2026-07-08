using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shorten.Areas.Domain;

namespace Shorten.Pages.UrlMapping;

public class IndexModel : PageModel
{
    private readonly ShortenContext _context;

    public IndexModel(ShortenContext context)
    {
        _context = context;
    }

    public IList<Shorten.Areas.Domain.UrlMapping> UrlMappings { get; set; } = default!;

    public async Task OnGetAsync()
    {
        UrlMappings = await _context.UrlMappings.ToListAsync();
    }
}
