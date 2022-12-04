using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Class
{
   public class SedolValidationResult
    {
        public string? InputString { get; set; }
        public bool IsValidSedol { get; set; }
        public bool IsUserDefined { get; set; }
        public string ValidationDetails { get; set; }
    }
}
