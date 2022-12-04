using SedolChecker.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.UOW
{
    public interface IUnitOfWork  : IDisposable
    {
        IWeightRepository Weights { get; }
        int Complete();
    }
}
