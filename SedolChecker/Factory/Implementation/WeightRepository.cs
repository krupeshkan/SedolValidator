using SedolChecker.DAL.dFramedbContext;
using SedolChecker.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Factory.Implementation
{
    public class WeightRepository : GenericRepository<Tbl_WeightFactor>, IWeightRepository
    {
        public WeightRepository(dFramedbContext context) : base(context)
        {
        }

        public List<Tbl_WeightFactor> GetWeightingFactor()
        {
            List<Tbl_WeightFactor> lstWeightFactor = new List<Tbl_WeightFactor>();
            Tbl_WeightFactor item = new Tbl_WeightFactor();
            item.Position = 1;
            item.Weight = 1;
            lstWeightFactor.Add(item);

            new Tbl_WeightFactor();
            item.Position = 2;
            item.Weight = 3;
            lstWeightFactor.Add(item);

            new Tbl_WeightFactor();
            item.Position = 3;
            item.Weight = 1;
            lstWeightFactor.Add(item);

            new Tbl_WeightFactor();
            item.Position = 4;
            item.Weight = 7;
            lstWeightFactor.Add(item);

            new Tbl_WeightFactor();
            item.Position = 5;
            item.Weight = 3;
            lstWeightFactor.Add(item);

            new Tbl_WeightFactor();
            item.Position = 6;
            item.Weight = 9;
            lstWeightFactor.Add(item);

            new Tbl_WeightFactor();
            item.Position = 7;
            item.Weight = 1;
            lstWeightFactor.Add(item);

            return lstWeightFactor;
        }
    }
}
