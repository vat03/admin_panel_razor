using admin_panel_razor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace admin_panel_razor.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<WithdrawRequest> WithdrawRequests { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ShopCoin> ShopCoins { get; set; }
        public DbSet<BidValue> BidValues { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<LogoSetting> LogoSettings { get; set; }
        public DbSet<GameConfig> GameConfigs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<PrivacyPolicy> privacyPolicies { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
    }
}
