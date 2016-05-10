// ***************************************************************************
//  filename    :   FTM_Regex.cs
//  purpose     :   use regular expressions to parse a chemical formula string
//                  of the form (X+[N]*)* where X is an element abbreviation
//                  (at least one character) and [N] is some number (or none)
//                  examples: CaCaCa123, CaO23H2CC
//
//  written by Jonathan Melcher on 2016-04-01
//  see IRegex.cs for API
//
//  Code Metrics:
//  Maintainability:        74
//  Cyclomatic Complexity:  31
//  Depth of Inheritance:   1
//  Class Coupling:         19
//  Lines of Code:          40  
// ***************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace FormulaToMass_REGEX
{
    public class FTM_Regex : IRegex
    {
        // pattern only matching empty string
        private const string EMPTY_STRING_REGEX = @"(^$)";

        // pattern for any non-alphabet characters or of form a... or A...B
        private const string INVALID_SYMBOL_REGEX = @"[^a-zA-Z]|\A([a-z]|[A-Z][a-z]*[A-Z])";

        // pattern for non-empty consecutive digits
        private const string NONEMPTY_CONSECUTIVE_DIGITS_REGEX = @"\d+";

        // pattern for any number of digits (0-9) (possiby none) in a row
        private const string JOINED_ELEMENT_COUNT_REGEX = @"\d*";

        // pattern for at least 1 non-digit character or JOINED_ELEMENT_COUNT_REGEX pattern
        private const string SPLIT_ELEMENT_COUNT_REGEX = @"\D+|" + JOINED_ELEMENT_COUNT_REGEX;

        private static FTM_Regex _instance = null;
        private List<string> _symbols = new List<string>();
        private string _pattern = EMPTY_STRING_REGEX;

        // constructor - private since class follows singleton pattern
        private FTM_Regex() { }

        // retrieves sole instance of FTM_Regex
        public static FTM_Regex Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FTM_Regex();
                return _instance;
            }
        }

        // sets symbols to be used as elements - each symbol must satisfy the valid symbol pattern
        public List<string> Symbols
        {
            set
            {
                _symbols = AreValidSymbols(value) ? value : new List<string>();

                // this is to always take the largest pattern first
                _symbols.Sort((s, t) => -s.Length.CompareTo(t.Length));

                // generates regex pattern from new collection
                _pattern = GetPattern();
            }
        }

        // checks that a list of symbols follows the correct pattern for element symbols
        public bool AreValidSymbols(List<string> symbols)
        {
            return symbols?.All(s => !(string.IsNullOrWhiteSpace(s) || Regex.IsMatch(s, INVALID_SYMBOL_REGEX))) ?? false;
        }

        // builds an instance of Formula using the constructed regex pattern from symbols
        // Formula stores status of build, the breakdown of symbol : count, and the original string
        public Formula GetFormula(string formula)
        {
            formula = formula?.Trim() ?? string.Empty;

            if (formula == string.Empty
                || !(AreElementCountsValid(formula) && IsValidFormula(formula)))
                return new Formula(formula, null);

            return new Formula(formula, GetSymbolsWithCounts(formula));
        }

        // generates Regex pattern for finding element/count matches
        private string GetPattern()
        {
            if (_symbols.Count == 0)
                return EMPTY_STRING_REGEX;
            return $"({string.Join($"{JOINED_ELEMENT_COUNT_REGEX}|", _symbols)}" + $"{JOINED_ELEMENT_COUNT_REGEX})";
        }

        // checks that string completely follows pattern of a valid chemical
        // formula as per the specifications of this assignment
        private bool IsValidFormula(string formula)
        {
            return Regex.Replace(formula, _pattern, "").Trim().Length == 0;
        }

        // checks that any consecutive digits in the formula parse to an int
        private bool AreElementCountsValid(string formula)
        {
            int parsed;

            foreach (Match m in Regex.Matches(formula, NONEMPTY_CONSECUTIVE_DIGITS_REGEX))
                if (!int.TryParse(m.Value, out parsed))
                    return false;
            return true;
        }

        // produces dictionary of element abbreviations to their counts in a string
        private Dictionary<string, int> GetSymbolsWithCounts(string formula)
        {
            var symbolCounts = new Dictionary<string, int>();
            
            foreach (var symbolCount in GetSymbolCountMatches(formula))
                if (!symbolCounts.ContainsKey(symbolCount.Item1))
                    symbolCounts[symbolCount.Item1] = symbolCount.Item2;
                else
                    symbolCounts[symbolCount.Item1] += symbolCount.Item2;

            return symbolCounts;
        }

        // provides iterator over all element+count matches from formula
        private IEnumerable<Tuple<string, int>> GetSymbolCountMatches(string formula)
        {
            foreach (Match m in Regex.Matches(formula, _pattern))
            {
                var split = Regex.Matches(m.Value, SPLIT_ELEMENT_COUNT_REGEX);
                string count = split[1].Value.Length != 0 ? split[1].Value : 1.ToString();
                yield return Tuple.Create(split[0].Value, int.Parse(count));
            }
        }
    }
}