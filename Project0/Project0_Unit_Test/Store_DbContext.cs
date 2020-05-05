using Microsoft.EntityFrameworkCore;


namespace Project0_Unit_Test
{
    class Store_DbContext : DbContext
    {
        public Store_DbContext() { }
        public Store_DbContext(DbContextOptions<Store_DbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore");
            }
        }
    }
}
