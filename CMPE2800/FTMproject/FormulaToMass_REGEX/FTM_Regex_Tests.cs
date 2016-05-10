// *************************************************
//  filename    :   FTM_Regex_Tests.cs
//  purpose     :   Unit Test Suite for FTM_Regex.cs
//
//  written by Jonathan Melcher 0n 2016-04-01
// *************************************************


using System.Collections.Generic;
using NUnit.Framework;


namespace FormulaToMass_REGEX
{
    [TestFixture]
    public class FTM_Regex_Tests
    {
        FTM_Regex _regex = FTM_Regex.Instance;
        List<string> _empty = new List<string>();
        List<string> _1size = new List<string> { "He" };
        List<string> _nsize = new List<string> { "Ca", "Cd", "C" };
        List<string> _invalid = new List<string> { "CddD", "ddD", "", null, "CD" };

        [Test]
        public void EmptyStringIsInvalid()
        {
            Assert.IsFalse(_regex.IsValidFormula(""));
        }

        [Test]
        public void NullStringIsInvalid()
        {
            Assert.IsFalse(_regex.IsValidFormula(null));
        }

        [Test]
        public void InvalidStringIsInvalid()
        {
            _regex.Symbols = _nsize;
            Assert.IsFalse(_regex.IsValidFormula("CaCdCd123Cah32he"));
        }

        [Test]
        public void ValidStringIsValid()
        {
            _regex.Symbols = _nsize;
            Assert.IsTrue(_regex.IsValidFormula("Cd123CaCdCa145"));
        }

        [Test]
        public void ValidStringYieldsCorrectElementCounts()
        {
            _regex.Symbols = _nsize;
            var elementWeights = _regex.GetElementsWithCounts("Ca");
            Assert.AreEqual(1, elementWeights[_nsize[0]]);
        }

        [Test]
        public void InvalidSymbolsAreInvalid()
        {
            Assert.IsFalse(_regex.AreValidSymbols(_invalid));
        }

        [Test]
        public void ValidSymbolsAreValid()
        {
            Assert.IsTrue(_regex.AreValidSymbols(_nsize));
        }
    }
}