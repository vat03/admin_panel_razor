//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using admin_panel_razor.Data;
//using admin_panel_razor.Models;

//namespace admin_panel_razor.Pages.Users
//{
//    public class EditModel : PageModel
//    {
//        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

//        public EditModel(admin_panel_razor.Data.ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public User User { get; set; } = default!;

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var user =  await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            User = user;
//            return Page();
//        }

//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see https://aka.ms/RazorPagesCRUD.
//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(User).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(User.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("./Index");
//        }

//        private bool UserExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }
//    }
//}










//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using admin_panel_razor.Data;
//using admin_panel_razor.Models;

//namespace admin_panel_razor.Pages.Users
//{
//    public class EditModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;

//        public EditModel(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [BindProperty]
//        public User User { get; set; }

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            User = await _context.Users.FindAsync(id);

//            if (User == null)
//            {
//                return NotFound();
//            }
//            return Page();
//        }

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            _context.Attach(User).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(User.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return RedirectToPage("./Index");
//        }

//        private bool UserExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }
//    }
//}





using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}


