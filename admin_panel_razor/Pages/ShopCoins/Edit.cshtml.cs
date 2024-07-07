using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using admin_panel_razor.Data;
using admin_panel_razor.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Pages.ShopCoins
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShopCoin ShopCoin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCoin = await _context.ShopCoins.FindAsync(id);

            if (ShopCoin == null)
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

            var shopCoinToUpdate = await _context.ShopCoins.FindAsync(ShopCoin.Id);

            if (shopCoinToUpdate == null)
            {
                return NotFound();
            }

            shopCoinToUpdate.Value = ShopCoin.Value;

            _context.Attach(shopCoinToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopCoinExists(ShopCoin.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("Index");
        }

        private bool ShopCoinExists(int id)
        {
            return _context.ShopCoins.Any(e => e.Id == id);
        }
    }
}
