using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Moq;
using SedolChecker.Interfaces;
using SedolChecker.Class;
using SedolChecker.UOW;
using System.Collections.Generic;
using SedolChecker.DAL.dFramedbContext;

namespace SedolUnitTestCases
{
    [TestClass]
    public class TestSedolValidator
    {
        private static Mock<ISedolValidator> SedolValidatormock = new Mock<ISedolValidator>();
        private static Mock<IUnitOfWork> unitOfWorkmock = new Mock<IUnitOfWork>(); 

        SedolValidationResult _SedolValidationResult = new SedolValidationResult();
        SedolValidationResult _SedolValidation = new SedolValidationResult();
        SedolChecks _sedolChecks = new SedolChecks(unitOfWorkmock.Object);
        Mock<IUnitOfWork> _unitOfWorkmock = new Mock<IUnitOfWork>();

        
        public List<Tbl_WeightFactor> InitialValues()
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

        [TestMethod]
        public void IsNull_IsEmpty_CheckValidateSedol()
        {
            SedolChecks _sedolChecks = new SedolChecks(unitOfWorkmock.Object);
            Mock<IUnitOfWork> _unitOfWorkmock = new Mock<IUnitOfWork>();

            List<Tbl_WeightFactor> lstWeightFactor  =  InitialValues();

            _SedolValidation.InputString = "";
            _SedolValidation.IsValidSedol = false;
            _SedolValidation.IsUserDefined = false;
            _SedolValidation.ValidationDetails = "Input string was not 7-characters long";


            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);

            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = null;
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = "12";
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = "123456789";
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

        }

        [TestMethod]
        public void Check_Invalid_Checksum_NonUserDefined()
        {
            List<Tbl_WeightFactor> lstWeightFactor = InitialValues();
            _SedolValidation.InputString = "1234567";
            _SedolValidation.IsValidSedol = false;
            _SedolValidation.IsUserDefined = false;
            _SedolValidation.ValidationDetails = "Checksum digit does not agree with the rest of the input";
            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);
        }

        [TestMethod]
        public void Check_Valid_NonUserDefine()
        {
            SedolChecks _sedolChecks = new SedolChecks(unitOfWorkmock.Object);
            Mock<IUnitOfWork> _unitOfWorkmock = new Mock<IUnitOfWork>();

            List<Tbl_WeightFactor> lstWeightFactor = InitialValues();

            _SedolValidation.InputString = "0709954";
            _SedolValidation.IsValidSedol = true;
            _SedolValidation.IsUserDefined = false;
            _SedolValidation.ValidationDetails = null;
            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = "B0YBKJ7";
            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);
        }

        [TestMethod]
        public void Check_InValid_Checksum_UserDefine()
        {
            List<Tbl_WeightFactor> lstWeightFactor = InitialValues();
            _SedolValidation.InputString = "9123451";
            _SedolValidation.IsValidSedol = false;
            _SedolValidation.IsUserDefined = true;
            _SedolValidation.ValidationDetails = "Checksum digit does not agree with the rest of the input";
            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = "9ABCDE8";
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);
        }

        [TestMethod]
        public void Check_InValid_Characters_Found()
        {
            List<Tbl_WeightFactor> lstWeightFactor = InitialValues();
            _SedolValidation.InputString = "9123_51";
            _SedolValidation.IsValidSedol = false;
            _SedolValidation.IsUserDefined = false;
            _SedolValidation.ValidationDetails = "SEDOL contains invalid characters";
            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = "VA.CDE8";
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);
        }

        [TestMethod]
        public void Check_Valid_UserDefine()
        {
            List<Tbl_WeightFactor> lstWeightFactor = InitialValues();
            _SedolValidation.InputString = "9123458";
            _SedolValidation.IsValidSedol = true;
            _SedolValidation.IsUserDefined = true;
            _SedolValidation.ValidationDetails = null;
            unitOfWorkmock.Setup(x => x.Weights.GetWeightingFactor()).Returns(lstWeightFactor);
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

            _SedolValidation.InputString = "9ABCDE1";
            _SedolValidationResult = _sedolChecks.ValidateSedol(_SedolValidation.InputString, _SedolValidation.IsValidSedol, _SedolValidation.IsUserDefined);
            Assert.AreEqual(_SedolValidation.IsValidSedol, _SedolValidationResult.IsValidSedol);
            Assert.AreEqual(_SedolValidation.IsUserDefined, _SedolValidationResult.IsUserDefined);
            Assert.AreEqual(_SedolValidation.ValidationDetails, _SedolValidationResult.ValidationDetails);
            Assert.AreEqual(_SedolValidation.InputString, _SedolValidationResult.InputString);

        }
    }
}
