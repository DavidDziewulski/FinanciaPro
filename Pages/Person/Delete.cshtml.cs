using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorNet.Data;

namespace RazorNet.Pages.Person;

public class Delete : PageModel
{
    private readonly ApplicationDbContext _context;

    public Delete(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Models.Person Person { get; set; }

    // Wyświetlenie potwierdzenia usunięcia
    public IActionResult OnGet(int id)
    {
        Person = _context.Persons.FirstOrDefault(p => p.Id == id);
        if (Person == null)
        {
            return NotFound();
        }

        return Page();
    }

    // Obsługa usunięcia rekordu
    public IActionResult OnPost(int id)
    {
        var personInDb = _context.Persons.FirstOrDefault(p => p.Id == id);
        if (personInDb == null)
        {
            return NotFound();
        }

        _context.Persons.Remove(personInDb);
        _context.SaveChanges();

        return RedirectToPage("/Person/Index");
    }
}