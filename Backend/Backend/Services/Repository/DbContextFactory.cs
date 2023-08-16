namespace Backend.Services.Repository
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbContextFactory(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public EverythingAppDbContext CreateDbContext()
        {
            var scope = _scopeFactory.CreateScope();
            return scope.ServiceProvider.GetRequiredService<EverythingAppDbContext>();
        }
    }
}
