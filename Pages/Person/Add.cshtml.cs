using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNet.Data;

namespace RazorNet.Pages.Person;

public class Add : PageModel
{
    private readonly ApplicationDbContext _context;

    public Add(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public Models.Person Person { get; set; } = new Models.Person();

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Persons.Add(Person);
        _context.SaveChanges();
        return RedirectToPage("/Person/Index");
    }
}