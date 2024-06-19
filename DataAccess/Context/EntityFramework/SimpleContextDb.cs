using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-ABR5RK9\\SQLEXPRESS;Database=InspectionDB;Integrated Security=true;TrustServerCertificate = True");
            optionsBuilder.UseSqlServer("Server=inspectiondbcloud.ctmis8maayan.us-east-2.rds.amazonaws.com,1433;Database=inspectiondbcloud;User Id=admin;Password=Juan123#;TrustServerCertificate=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }
		
		public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}
