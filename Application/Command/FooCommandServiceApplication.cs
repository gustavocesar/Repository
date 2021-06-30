using Application.Commands.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.Contracts;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Application.Commands
{
    public class FooCommandServiceApplication : IFooCommandServiceApplication
    {
        private readonly IFooRepository _fooRepository;
        private readonly IBarRepository _barRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FooCommandServiceApplication (
            IUnitOfWork unitOfWork,
            IFooRepository fooRepository,
            IBarRepository barRepository
        )
        {
            _fooRepository = fooRepository;
            _barRepository = barRepository;
            _unitOfWork = unitOfWork;
        }

        public void FooAndBar()
        {
            try
            {
                _unitOfWork.OpenTransaction();

                // var foo = _fooRepository.GetAll().FirstOrDefault();
                // var bar = _barRepository.GetAll().FirstOrDefault();

                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw e;
            }
        }
    }
}
