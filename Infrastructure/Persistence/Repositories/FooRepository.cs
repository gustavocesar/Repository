using Domain.Entities;
using Domain.Repositories.Contracts;
using Infrastructure.Base;
using SharedKernel.Infrastructure.DataContext;

namespace Infrastructure.Persistence.Repositories
{
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public FooRepository(IDataContext context) : base(context)
        {
        }
    }
}
