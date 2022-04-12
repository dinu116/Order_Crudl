using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        
            public DbSet<Crud> Cruds { get; set; }
        
    }
}
