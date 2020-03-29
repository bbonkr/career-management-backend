using Microsoft.EntityFrameworkCore;

namespace CareerManagement.Data.Configurations
{
    public interface IEntityTypeConfigurationProvider
    {
        void Apply(ModelBuilder modelBuilder);
    }
}
