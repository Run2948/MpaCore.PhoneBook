using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MpaCore.PhoneBook.Authorization.Roles;
using MpaCore.PhoneBook.Authorization.Users;
using MpaCore.PhoneBook.MultiTenancy;
using MpaCore.PhoneBook.Persons;
using MpaCore.PhoneBook.PhoneNumbers;

namespace MpaCore.PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber");

            base.OnModelCreating(modelBuilder);
        }
    }
}
