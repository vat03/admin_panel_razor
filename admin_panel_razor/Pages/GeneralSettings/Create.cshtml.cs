using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.GeneralSettings
{
    public class CreateModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public CreateModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GeneralSetting GeneralSetting { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GeneralSettings.Add(GeneralSetting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
