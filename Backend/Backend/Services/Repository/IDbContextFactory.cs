namespace Backend.Services.Repository
{
    public interface IDbContextFactory
    {
        EverythingAppDbContext CreateDbContext();
    }
}
