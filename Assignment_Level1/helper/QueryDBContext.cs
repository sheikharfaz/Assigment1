using Assignment_Level1.Models;
using Microsoft.EntityFrameworkCore;


namespace Assignment_Level1.helper
{
    public class QueryDBContext : DbContext
    {
        public QueryDBContext(DbContextOptions<QueryDBContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        //public DbSet Set(string name)
        //{
        //    // you may need to fill in the namespace of your context
        //    return base.Set(Type.GetType(name));
        //}

        
    }
}
