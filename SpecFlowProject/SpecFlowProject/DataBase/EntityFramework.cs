using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.DataBase
{
    public class Post
    {
        public int Rollno { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
    class EntityFramework
    {
    }
}
