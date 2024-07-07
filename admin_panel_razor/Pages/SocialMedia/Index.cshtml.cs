//using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using admin_panel_razor.Data;
using admin_panel_razor.Models;

namespace AdminPanelRazor.Pages
{
    public class SocialMediaModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SocialMediaModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SocialMedia SocialMedia { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            SocialMedia = await _context.SocialMedias.FirstOrDefaultAsync();
            if (SocialMedia == null)
            {
                SocialMedia = new SocialMedia();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingSocialMedia = await _context.SocialMedias.FirstOrDefaultAsync();
            if (existingSocialMedia == null)
            {
                _context.SocialMedias.Add(SocialMedia);
            }
            else
            {
                existingSocialMedia.Facebook = SocialMedia.Facebook;
                existingSocialMedia.Twitter = SocialMedia.Twitter;
                existingSocialMedia.LinkedIn = SocialMedia.LinkedIn;
                existingSocialMedia.Instagram = SocialMedia.Instagram;
                existingSocialMedia.YouTube = SocialMedia.YouTube;
                existingSocialMedia.WhatsApp = SocialMedia.WhatsApp;
                existingSocialMedia.Pinterest = SocialMedia.Pinterest;
                existingSocialMedia.GitHub = SocialMedia.GitHub;

                _context.SocialMedias.Update(existingSocialMedia);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}

