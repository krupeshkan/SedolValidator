using SedolChecker.DAL.dFramedbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Factory.Interface
{
    public interface IWeightRepository
    {
        public List<Tbl_WeightFactor> GetWeightingFactor();
    }
}
