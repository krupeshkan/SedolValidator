using SedolChecker.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Interfaces
{
    public interface ISedolValidator
    {
        public SedolValidationResult ValidateSedol(string input, bool IsValidSedol, bool IsUserDefined);
    }
}
