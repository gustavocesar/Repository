using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence.Mappings
{
    public class BarMap : IEntityTypeConfiguration<Bar>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bar> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
