using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNet.Data;

namespace RazorNet.Pages.Person;

public class Index : PageModel
{
        private readonly ApplicationDbContext _context;

        public Index(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Person> Persons { get; set; } = new List<Models.Person>();

        public void OnGet()
        {
            Persons = _context.Persons.ToList();
        }
    }
