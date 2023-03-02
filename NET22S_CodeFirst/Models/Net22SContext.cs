using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace NET22S_CodeFirst.Models
{
    public class Net22SDbContext : DbContext
    {
        public Net22SDbContext() : base()
        {

        }

        public Net22SDbContext(DbContextOptions<Net22SDbContext> opt)
            : base(opt)
        {
            Console.WriteLine("Checking if tables are ready for use");

            if (!TablesReadyForUse())
            {
                Console.WriteLine("Creating tables");
                var relDatcreator = (RelationalDatabaseCreator)this.Database.GetService<IDatabaseCreator>();
                relDatcreator.CreateTables();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Data Source=localhost,port;Initial Catalog=idk;User Id=sa;Password=your_password;Encrypt=False;TrustServerCertificate=True";
            Console.WriteLine("configuring DB context using connectionstring :" + connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        bool TablesReadyForUse()
        {
            try
            {
                var studentsTable = this.Students;

                var first = this.Students.FirstOrDefault();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("there was ex: " + ex.Message);
                return false;
            }
        }


        //entities
        public DbSet<Student> Students { get; set; }
    }
}