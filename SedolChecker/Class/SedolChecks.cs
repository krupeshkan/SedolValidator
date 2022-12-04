using SedolChecker.DAL.dFramedbContext;
using SedolChecker.Interfaces;
using SedolChecker.UOW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SedolChecker.Class
{
    public class SedolChecks : ISedolValidator
    {
        private readonly IUnitOfWork _unitOfWork;
        public SedolChecks(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SedolValidationResult ValidateSedol(string input, bool IsValidSedol , bool IsUserDefined)
        {
            SedolValidationResult _sedolValidationResult = new SedolValidationResult();
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            List<Tbl_WeightFactor> dictWeighting = new List<Tbl_WeightFactor>();
            dictWeighting = _unitOfWork.Weights.GetWeightingFactor();
            _sedolValidationResult.InputString = input;
            _sedolValidationResult.IsUserDefined = IsUserDefined;
            _sedolValidationResult.IsValidSedol = IsValidSedol;
            if (_sedolValidationResult.InputString == null || _sedolValidationResult.InputString == "" || _sedolValidationResult.InputString.Length != 7)
            {
                _sedolValidationResult.ValidationDetails = "Input string was not 7-characters long";
            }
            else if(!regexItem.IsMatch(_sedolValidationResult.InputString))
            {
                _sedolValidationResult.ValidationDetails = "SEDOL contains invalid characters";
            }
            else if(!_sedolValidationResult.IsUserDefined && !_sedolValidationResult.IsValidSedol)
            {
                _sedolValidationResult.ValidationDetails = "Checksum digit does not agree with the rest of the input";
            }
            else if (!_sedolValidationResult.IsUserDefined && _sedolValidationResult.IsValidSedol)
            {
                _sedolValidationResult.ValidationDetails = null;
            }
            else if (_sedolValidationResult.IsUserDefined &&!_sedolValidationResult.IsValidSedol)
            {
                _sedolValidationResult.ValidationDetails = "Checksum digit does not agree with the rest of the input";
            }
            else
            {
                char[] InputValues = _sedolValidationResult.InputString.ToCharArray();
                int Result = 0;
                for (int i = 0; i < InputValues.Length - 1; i++)
                {
                    int Position = dictWeighting.Find(x => x.Position == i + 1).Weight;
                    int weights = Aplhabets(InputValues[i]);
                    Result += weights * Position;
                }
                int FinalResult = (10 - (Result % 10) % 10);
            }    
            return _sedolValidationResult;
        }

        public int Aplhabets(char aplha)
        {
            int value = 0;
            if (!char.IsDigit(aplha))
            {
                char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                value = Array.IndexOf(alphabets, aplha) + 10;
            }
            else
            {
                value = (int)(aplha - '0');
            }
            return value;
        }
    }
}
