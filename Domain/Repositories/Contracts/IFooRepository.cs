using Domain.Entities;
using SharedKernel.Infrastructure.Repositories;

namespace Domain.Repositories.Contracts
{
    public interface IFooRepository : IRepository<Foo>
    {
    }
}