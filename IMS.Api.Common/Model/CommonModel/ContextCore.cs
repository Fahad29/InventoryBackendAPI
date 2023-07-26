using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace IMS.Api.Common.Model.CommonModel
{
    public class ContextCore : DbContext
    {
        [ExcludeFromCodeCoverage]
        public ContextCore(DbContextOptions<ContextCore> options) : base(options)
        { }

        //public DbSet<User> Users { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<UserRole> UserRoles { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<UserToken> UserTokens { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Templates> Template { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Merchant> Merchants { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<MerchantAccountSetup> MerchantAccountSetups { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<MerchantBankAccount> MerchantBankAccounts { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<MerchantBusiness> MerchantBusiness { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Transaction> Transactions { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Partner> Partner { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Reseller> Reseller { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<PricingPlan> PricingPlans { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<File> Files { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<PLGManager> PLGManager { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Setting> Settings { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<MerchantLocation> MerchantLocations { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<ApiErrorLog> ApiErrorLogs { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<ProcessorConfiguration> ProcessorConfigurations { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<MerchantSetting> MerchantSettings { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<MerchantBoardingLog> MerchantBoardingLogs { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<CustomersVault> CustomerVaults { get; set; }
        //public DbSet<CustomerVault> CustomerVault { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<PricingPlanAssignment> PricingPlanAssignment { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<UserAuthToken> UserAuthTokens { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Fields> Fields { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<RequiredFields> RequiredFields { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<Fraud> Frauds { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<FraudTransaction> FraudTransactions { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<FraudSetting> FraudSettings { get; set; }
        //[ExcludeFromCodeCoverage]
        //public DbSet<VirtualTerminalField> VirtualTerminalFields { get; set; }
    }
}
