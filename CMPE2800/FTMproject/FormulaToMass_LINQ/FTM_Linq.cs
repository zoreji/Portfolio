using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaToMass_REPO;

namespace FormulaToMass_LINQ
{
    public class FTM_Linq : ILinq
    {

        //Singleton pattern 
        private static FTM_Linq _instance = null;
        public static FTM_Linq Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FTM_Linq();
                return _instance;
            }
        }

        private FTM_Linq()
        {
           
        }
        // dictionary <string, rowelement>

        /// <summary>
        ///     Method:     SortName
        /// 
        ///     Purpose:    To sort the Periodic table of elements from the
        ///                 Repo Database and sort it into Alphabetically by 
        ///                 their elemental names
        /// </summary>
        /// <param name="dicBase">
        ///     dicBase:    The dictionary container that was obtain from
        ///                 the Repo class
        /// </param>
        /// <returns>
        ///     temp:       Returns the sorted result in a dictionary format
        ///                 so the UI is able to apply into the DataGrid
        /// </returns>
        public IEnumerable<RowElement> SortName(Dictionary<string, RowElement> dicBase)
        {
            return from e in dicBase
                   orderby e.Value.Name
                    select e.Value;
        }


        /// <summary>
        ///     Method:     SingleChar
        /// 
        ///     Purpose:    To sort the Periodic table of elements from the Repo Database
        ///                 place them in Alphabetically by their symbol with single characters
        ///                 first then double next
        /// </summary>
        /// <param name="dicBase">
        ///     dicBase:    The dictionary container that was obtain from
        ///                 the Repo class
        /// </param>
        /// <returns>
        ///     temp:       Returns the sorted result in a dictionary format
        ///                 so the UI is able to apply into the DataGrid
        /// </returns>
        public IEnumerable<RowElement> SingleChar(Dictionary<string,RowElement> dicBase)
        {
            return from e in dicBase
                   orderby e.Value.Symbol.Length, e.Value.Symbol
                   select e.Value;
        }
        /// <summary>
        ///     Method:     SortAtomic
        /// 
        ///     Purpose:    To sort the Periodic table of elements from the Repo Database 
        ///                 and place them in numerical order by thier Atomic number
        /// </summary>
        /// <param name="dicBase">
        ///     dicBase:    The dictionary container that was obtain from
        ///                 the Repo class
        /// </param>
        /// <returns>
        ///     temp:       Returns the sorted result in a dictionary format
        ///                 so the UI is able to apply into the DataGrid
        /// </returns>
        public IEnumerable<RowElement> SortAtomic(Dictionary<string,RowElement> dicBase)
        {
            return from e in dicBase
                   orderby e.Value.AtomicNumber
                   select e.Value;
        }

        public IEnumerable<RowElement> Intersect(Dictionary<string, int> elementCounts, Dictionary<string, RowElement> elementData)
        {
            return from element in elementData
                   where elementCounts.Keys.Contains(element.Key)
                   select element.Value;
        }

        public IEnumerable<RowElementCalculation> Calculate(IEnumerable<RowElement> eIntersected, Dictionary<string, int> eCounts)
        {
            return from e in eIntersected
                   select new RowElementCalculation(e, eCounts[e.Symbol]);
        }
    }
}