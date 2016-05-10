// ***********************************************************
//  filename    :   IRegex.cs
//  purpose     :   provide an API for FTM_Regex, for use with
//                  FormulaToMass_UI
//
//  written by Jonathan Melcher on 2016-04-01
// ***********************************************************


using System.Collections.Generic;


namespace FormulaToMass_REGEX
{
    public interface IRegex
    {
        // on program load set this to the list of all element abbreviations
        // will always be at least the empty list {} (not null)
        List<string> Symbols { set; }

        // checks that a list of symbols follows the correct pattern for element symbols
        bool AreValidSymbols(List<string> symbols);

        // parses raw string into Formula depicting state of parseing and the breakdown
        // of elements with their counts
        Formula GetFormula(string contents);
    }
}