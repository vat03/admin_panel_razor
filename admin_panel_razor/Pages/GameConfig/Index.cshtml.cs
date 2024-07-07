using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Models;
using System.Threading.Tasks;
using admin_panel_razor.Data;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages
{
    public class GameConfigModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public GameConfigModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public admin_panel_razor.Models.GameConfig GameConfig { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            GameConfig = await _context.GameConfigs.FirstOrDefaultAsync();
            if (GameConfig == null)
            {
                GameConfig = new admin_panel_razor.Models.GameConfig();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingConfig = await _context.GameConfigs.FirstOrDefaultAsync();
            if (existingConfig == null)
            {
                _context.GameConfigs.Add(GameConfig);
            }
            else
            {
                existingConfig.AdminCommission = GameConfig.AdminCommission;
                existingConfig.SignupBonus = GameConfig.SignupBonus;
                existingConfig.SupportMail = GameConfig.SupportMail;
                existingConfig.WhatsappLink = GameConfig.WhatsappLink;
                existingConfig.YoutubeLink = GameConfig.YoutubeLink;
                existingConfig.ApiKey = GameConfig.ApiKey;
                existingConfig.SecretKey = GameConfig.SecretKey;

                _context.GameConfigs.Update(existingConfig);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}

