using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liked> Likeds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new Initializer());
        }

    }
}
