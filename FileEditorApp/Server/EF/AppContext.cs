using FileEditorApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace FileEditorApp.Server.EF
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<DatabaseFile> DatabaseFiles { get; private set; }
        public AppContext(DbContextOptions<AppContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.DatabaseFiles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
