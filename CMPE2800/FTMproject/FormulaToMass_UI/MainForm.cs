//*****************************************************************************************
//
//Program:  Formula To Mass Calculator
//
//Purpose: Converts a chemical formula into its chemical division and molar mass
//
//Authors:  Jon Melcher                 - jonathan.melcher@gmail.com
//          Dave Hospedales             - davehospedales@gmail.com
//          Chachatri Chaichanathong    - chanchatri.c@gmail.com
//          Ervin Hernandez             - azncan@gmail.com
//          Fawad Syed                  - fawadsyed1@gmail.com
//
//
//Class:    CMPE 2800
//Instructor:   Herb Vanselow
//StartDate:    April 1, 2016
//*****************************************************************************************


using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormulaToMass_LINQ;
using FormulaToMass_REGEX;
using FormulaToMass_REPO;


namespace FormulaToMass_UI
{
    public partial class UI_F_FTM : Form
    {
        private BindingSource _dataSource = new BindingSource();
        private Dictionary<string, RowElement> _elements;

        public UI_F_FTM()
        {
            InitializeComponent();
        }

        //*********************************************************************************
        //
        //Purpose:  - Grab Atomic Elements form database, create a dictionary<string,row>                 
        //
        //*********************************************************************************
        private void UI_F_FTM_Load(object sender, EventArgs e)
        {
            UI_DGV_Display.DataSource = _dataSource;
            _elements = FTM_Repo.Instance.GetElementData() ?? new Dictionary<string, RowElement>();

            if (_elements.Count == 0)
                MessageBox.Show("Unable to load periodic table from file or database");
            FTM_Regex.Instance.Symbols = _elements?.Select(kvp => kvp.Value.Symbol).ToList();
        }

        //*********************************************************************************
        //
        //Purpose:  - input validation
        //              - Text Box will change to Green if the input is found
        //              - Text Box will change to Yellow if the input can be found
        //              - TExt Box will change to Red if the input can not be found
        //          - Calculate for Molar Mass of the chemical formula
        //
        //*********************************************************************************
        private void UI_TB_FormulaInput_TextChanged(object sender, EventArgs e)
        {
            Formula formula = FTM_Regex.Instance.GetFormula(UI_TB_FormulaInput.Text);

            switch (formula.State)
            {
                case FormulaParseState.Empty:
                    UI_DGV_Display.Rows.Clear();
                    UI_LBL_MolarOutput.Text = string.Empty;
                    UI_TB_FormulaInput.BackColor = Color.White;
                    break;
                case FormulaParseState.InvalidContents:
                    UI_TB_FormulaInput.BackColor = Color.Red;
                    UI_LBL_MolarOutput.ForeColor = Color.Goldenrod;
                    break;
                case FormulaParseState.InvalidBreakdown:
                    UI_TB_FormulaInput.BackColor = Color.Red;
                    break;
                case FormulaParseState.Valid:
                    UI_TB_FormulaInput.BackColor = Color.LightGreen;
                    UI_LBL_MolarOutput.ForeColor = Color.Green;
                    VisualizeFormulaBreakdown(formula.Breakdown);
                    break;
            }
        }

        private void VisualizeFormulaBreakdown(Dictionary<string, int> elementCounts)
        {
            var linq = FTM_Linq.Instance;
            var elementCalculations = linq.Calculate(linq.Intersect(elementCounts, _elements), elementCounts);
            _dataSource.DataSource = elementCalculations;
            UI_LBL_MolarOutput.Text = elementCalculations.Sum(calc => calc.TotalMass).ToString("f4") + " g/mol";
        }


        //*********************************************************************************
        //
        //Purpose: - Populate the table with Atmoic Elements, then Sort
        //              - SortName will Sort elements by name
        //              - SortSymbol will sort elements by their atomic symbol
        //              - SortAtomic will sort elements by their atomic number 
        //
        //*********************************************************************************
        private void UI_BT_SortName_Click(object sender, EventArgs e)
        {
            DGVElementDataDisplay(FTM_Linq.Instance.SortName(_elements));
        }

        private void UI_BT_SortSymbol_Click(object sender, EventArgs e)
        {
            DGVElementDataDisplay(FTM_Linq.Instance.SingleChar(_elements));
        }

        private void UI_BT_SortAtomic_Click(object sender, EventArgs e)
        {
            DGVElementDataDisplay(FTM_Linq.Instance.SortAtomic(_elements));
        }

        private void DGVElementDataDisplay(IEnumerable<RowElement> elementData)
        {
            if (elementData.Count() == 0)
                return;

            _dataSource.DataSource = elementData;
            UI_DGV_Display.Columns[0].HeaderText = "Atomic Number";
            UI_DGV_Display.Columns[3].HeaderText = "Mass (g/mol)";
        }
    }
}