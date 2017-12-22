using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csharpRest.Entity;
using Microsoft.EntityFrameworkCore;

namespace csharpRest
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {}

        public DbSet<Pessoa> pessoas { get; set; }
    }
}
