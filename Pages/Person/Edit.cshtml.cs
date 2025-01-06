using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorNet.Pages.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNet.Data;
using RazorNet.Models;
using System.Threading.Tasks;

public class Edit : PageModel
{
    
    private readonly ApplicationDbContext _context;

    public Edit(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Person Person { get; set; }

    public IActionResult OnGet(int id)
    {
        Person = _context.Persons.FirstOrDefault(p => p.Id == id);
        if (Person == null)
        {
            return NotFound();
        }

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        var personInDb = _context.Persons.FirstOrDefault(p => p.Id == id);
        if (personInDb == null)
        {
            return NotFound();
        }

        personInDb.FirstName = Person.FirstName;
        personInDb.LastName = Person.LastName;
        personInDb.Position = Person.Position;
        personInDb.Amount = Person.Amount;

        _context.SaveChanges();

        return RedirectToPage("/Person/Index");
    }
}
