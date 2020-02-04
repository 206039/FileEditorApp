using FileEditorApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileEditorApp.Server.EF
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public AppContext(DbContextOptions<AppContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
