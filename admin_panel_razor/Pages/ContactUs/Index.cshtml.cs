using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ContactUsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.ContactUs ContactUs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ContactUs = await _context.ContactUs.FirstOrDefaultAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var contactUsFromDb = await _context.ContactUs.FirstOrDefaultAsync();
            if (contactUsFromDb == null)
            {
                _context.ContactUs.Add(ContactUs);
            }
            else
            {
                contactUsFromDb.PrimaryTollFreeNumber = ContactUs.PrimaryTollFreeNumber;
                contactUsFromDb.PrimaryEmail = ContactUs.PrimaryEmail;
                contactUsFromDb.SecondaryTollFreeNumber = ContactUs.SecondaryTollFreeNumber;
                contactUsFromDb.SecondaryEmail = ContactUs.SecondaryEmail;
                contactUsFromDb.Address = ContactUs.Address;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}

