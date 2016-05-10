using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaToMass_REPO;
namespace FormulaToMass_LINQ
{
    public interface ILinq
    {
        // these can all return IEnumerable<KeyValuePair<string, RowElement>>
        // since they are being used by Toon's Display method which needs only
        // iterate over the keyvaluepairs; saves some time building the dictionaries
        // by only returning the linq result instead - Jon
        IEnumerable<RowElement> SortName(Dictionary<string, RowElement> dicBase);
        IEnumerable<RowElement> SingleChar(Dictionary<string, RowElement> dicBase);
        IEnumerable<RowElement> SortAtomic(Dictionary<string, RowElement> dicBase);
        IEnumerable<RowElement> Intersect(Dictionary<string, int> elementCounts, Dictionary<string, RowElement> elementData);
        IEnumerable<RowElementCalculation> Calculate(IEnumerable<RowElement> eIntersected, Dictionary<string, int> eCounts);
    }
}
