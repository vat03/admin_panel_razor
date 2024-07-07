using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace admin_panel_razor.Pages.GameConfig
{
    public class DeleteModel : PageModel
    {
        private readonly admin_panel_razor.Data.ApplicationDbContext _context;

        public DeleteModel(admin_panel_razor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.GameConfig GameConfig { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameconfig = await _context.GameConfigs.FirstOrDefaultAsync(m => m.Id == id);

            if (gameconfig == null)
            {
                return NotFound();
            }
            else
            {
                GameConfig = gameconfig;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameconfig = await _context.GameConfigs.FindAsync(id);
            if (gameconfig != null)
            {
                GameConfig = gameconfig;
                _context.GameConfigs.Remove(GameConfig);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
