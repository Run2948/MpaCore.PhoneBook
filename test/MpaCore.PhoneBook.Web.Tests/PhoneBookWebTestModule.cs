using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MpaCore.PhoneBook.EntityFrameworkCore;
using MpaCore.PhoneBook.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MpaCore.PhoneBook.Web.Tests
{
    [DependsOn(
        typeof(PhoneBookWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PhoneBookWebTestModule : AbpModule
    {
        public PhoneBookWebTestModule(PhoneBookEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhoneBookWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PhoneBookWebMvcModule).Assembly);
        }
    }
}