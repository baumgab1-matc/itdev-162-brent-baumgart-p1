using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext: DbContext
    {
        public DbSet<Grad> Grads { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "GradBox.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}