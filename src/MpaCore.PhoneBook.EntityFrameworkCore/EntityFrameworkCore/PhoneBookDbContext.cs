using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MpaCore.PhoneBook.Authorization.Roles;
using MpaCore.PhoneBook.Authorization.Users;
using MpaCore.PhoneBook.MultiTenancy;

namespace MpaCore.PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }
    }
}
