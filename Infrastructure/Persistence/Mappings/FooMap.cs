using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence.Mappings
{
    public class FooMap : IEntityTypeConfiguration<Foo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Foo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
