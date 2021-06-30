using Domain.Entities;
using Domain.Repositories.Contracts;
using Infrastructure.Base;
using SharedKernel.Infrastructure.DataContext;

namespace Infrastructure.Persistence.Repositories
{
    public class BarRepository : Repository<Bar>, IBarRepository
    {
        public BarRepository(IDataContext context) : base(context)
        {
        }
    }
}
