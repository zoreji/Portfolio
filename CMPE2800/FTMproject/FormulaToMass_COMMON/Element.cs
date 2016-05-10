// *******************************************************************
//  filename    :   Element.cs
//  purpose     :   provide an immutable container for the element
//                  information retrieved from the SQL database
//
//  if required by module add a reference to FormulaToMass_COMMON .dll
//
//  written by Jonathan Melcher on 2016-04-02
// *******************************************************************


namespace FormulaToMass_COMMON
{
    public class Element
    {
        private readonly string _name;
        private readonly string _symbol;
        private readonly int _atomicNumber;
        private readonly float _molarMass;

        public string Name => _name;
        public string Symbol => _symbol;
        public int AtomicNumber => _atomicNumber;
        public float MolarMass => _molarMass;
        
        public Element (string name, string symbol, int atomicNumber, float molarMass)
        {
            _name = name;
            _symbol = symbol;
            _atomicNumber = atomicNumber;
            _molarMass = molarMass;
        }
    }
}