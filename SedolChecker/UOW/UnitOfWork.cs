using SedolChecker.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using SedolChecker.DAL.dFramedbContext;
using SedolChecker.Factory.Implementation;

namespace SedolChecker.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dFramedbContext _context;

        public UnitOfWork(dFramedbContext context)
        {
            _context = context;
            Weights = new WeightRepository(_context);
        }
        public IWeightRepository Weights { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
