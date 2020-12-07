using Microsoft.EntityFrameworkCore;
using WebApi.Models ;


    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options){ }

        public DbSet<Guest> Guest { get; set; }
    }