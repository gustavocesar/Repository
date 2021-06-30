using SharedKernel.Infrastructure.DataContext;

namespace SharedKernel.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        void OpenTransaction();

        void Commit();

        void Rollback();

        void AddContext(IDataContext dataContext);
    }
}
