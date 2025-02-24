﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.GeneralSettings
{
    public class DeleteModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GeneralSetting GeneralSetting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalsetting = await _context.GeneralSettings.FirstOrDefaultAsync(m => m.Id == id);

            if (generalsetting == null)
            {
                return NotFound();
            }
            else
            {
                GeneralSetting = generalsetting;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalsetting = await _context.GeneralSettings.FindAsync(id);
            if (generalsetting != null)
            {
                GeneralSetting = generalsetting;
                _context.GeneralSettings.Remove(GeneralSetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
