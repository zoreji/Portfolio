// ***********************************************************************************
//  filename    :   Formula.cs
//  purpose     :   used to store results of parsing a chemical formula from a string
//                  using FTM_Regex.cs.  class contains original string, the breakdown
//                  of the string into symbol : count, and the success status of the
//                  FTM_Regex GetFormula method
//
//  written by Jonathan Melcher
//
//  Code Metrics:
//  Maintainability:        88
//  Cyclomatic Complexity:  12
//  Depth of Inheritance:   1
//  Class Coupling:         5
//  Lines of Code:          9  
// ***********************************************************************************


using System.Collections.Generic;
using System.Linq;


namespace FormulaToMass_REGEX
{
    public enum FormulaParseState { Empty, InvalidContents, InvalidBreakdown, Valid }

    public class Formula
    {
        private readonly string _contents;
        private readonly Dictionary<string, int> _breakdown;

        public string Contents => _contents;
        public Dictionary<string, int> Breakdown => _breakdown;
        public FormulaParseState State => Contents == string.Empty
                                        ? FormulaParseState.Empty
                                        : Breakdown.Count == 0
                                        ? FormulaParseState.InvalidContents
                                        : Breakdown.Values.Any(v => v < 0)
                                        ? FormulaParseState.InvalidBreakdown
                                        : FormulaParseState.Valid;

        public Formula(string contents, Dictionary<string, int> breakdown)
        {
            _contents = contents ?? string.Empty;
            _breakdown = breakdown ?? new Dictionary<string, int>();
        }

        public override string ToString()
        {
            return Contents;
        }
    }
}