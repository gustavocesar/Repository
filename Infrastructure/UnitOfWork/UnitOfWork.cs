using Microsoft.EntityFrameworkCore.Storage;
using Infrastructure.Context;
using SharedKernel.Infrastructure.DataContext;
using SharedKernel.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IDataContext _context;

        protected IDbContextTransaction _transaction;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public virtual void Commit()
        {
            if (_transaction == null)
            {
                return;
            }

            try
            {
                _context.SaveChanges();
                _transaction.Commit();
                _transaction = null;
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public virtual void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void AddContext(IDataContext dataContext)
        {
            _context = dataContext;
        }

        public virtual void OpenTransaction()
        {
            if (_transaction == null)
            {
                _transaction = ((DataContext)_context).Database.BeginTransaction();
            }
        }
    }
}
