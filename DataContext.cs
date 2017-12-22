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
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Pessoa> pessoas { get; set; }

        /* find string connect db */
        //public static string ConnectionString { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source={192.168.1.242};Initial Catalog=TestNetCoreEF;user id={SistemasWeb};password={38ySo54TYpL98y};");
        //}
    }
}
