using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shorten.Areas.Domain;

namespace Shorten.Pages.UrlMapping;

public class CreateModel : PageModel
{
    private readonly ShortenContext _context;

    public CreateModel(ShortenContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Shorten.Areas.Domain.UrlMapping UrlMapping { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.UrlMappings.Add(UrlMapping);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
