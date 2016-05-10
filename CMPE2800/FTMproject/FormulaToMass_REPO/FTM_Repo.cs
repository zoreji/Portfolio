// ***************************************************************************
//  filename    :   FTM_Repo.cs
//  purpose     :   Supplies a dictionary containing data for each element 
//                  in the periodic table.
//
//  written by David Hospedales on 2016-04-01
//  see IRepo.cs for API
//
//  Project: FormulaToMass_REPO
//
//  Maintainability Index: 87
//  Cyclomatic Complexity: 36
//  Depth of Inheritance: 1
//  Class Coupling: 35
//  Lines of Code: 49
// ***************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;

namespace FormulaToMass_REPO
{
    public struct RowElement
    {
        public int AtomicNumber { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double MolarMass { get; set; }

        public RowElement(int atomicNumber,string name, string symbol, double mass )
        {
            AtomicNumber = atomicNumber;
            MolarMass = mass;
            Symbol = symbol;
            Name = name;
        }
    }

    public struct RowElementCalculation
    {
        public string Element { get; set; }
        public int Count { get; set; }
        public double Mass { get; set; }
        public double TotalMass { get; set; }

        public RowElementCalculation(RowElement re, int count)
        {
            Element = re.Name;
            Mass = re.MolarMass;
            Count = count;
            TotalMass = Count * Mass;
        }
    }

    public class FTM_Repo : IRepo
    {       
        private const string ELEMENT_DATA_TEXTFILE = "..\\..\\..\\elementData.txt";
        private const string QUERY_GET_ELEMENTS = "SELECT * FROM Element_Info";

        //*******************************************************************************
        //Singleton pattern
        private static FTM_Repo _instance = null;
        public static FTM_Repo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FTM_Repo();
                return _instance;
            }
        }
        private FTM_Repo(){ } //Private constructor to follow the Singleton pattern
        //*******************************************************************************


        //*******************************************************************************
        //GetElementData() - Inherited from IRepo - General structure method to return
        //                   a constructed dictionary to the caller.
        //*******************************************************************************
        public Dictionary<string, RowElement> GetElementData()
        {
            //Attempt to grab data locally
            var elements = GetDataFromFile();

            //Data was unavailable, fetch it from the database
            if (elements == null)
                elements = GetDataFromDataBase();

            return elements;
        }

        //*******************************************************************************
        //GetDataFromFile() - Attempts to get data locally from a txt file. Each line in 
        //                    the text file is considered to be an element.
        //*******************************************************************************
        private Dictionary<string, RowElement> GetDataFromFile()
        {
            var elements = new Dictionary<string, RowElement>();
            StreamReader sr;

            //Attempt to open file containing element data
            try
            {
                sr = new StreamReader(ELEMENT_DATA_TEXTFILE);

                string line = "";
                //Read line by line and add each to the element dictionary
                while ((line = sr.ReadLine()) != null && line != "")
                {
                    RowElement re = ParseElementLine(line);
                    elements.Add(re.Symbol, re);
                }

                sr.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null; //Returning null flags a fetch to the database
            }
            return elements;
        }

        //*******************************************************************************
        //GetDataFromFile() - Attempts to get data locally from a txt file. Each line in 
        //                    the text file is considered to be an element.
        //*******************************************************************************
        private Dictionary<string, RowElement> GetDataFromDataBase()
        {
            var elements = new Dictionary<string, RowElement>();

            try
            {
                //Connect to expected database...
                using (SqlConnection conn = new SqlConnection(DataSource.ConnectionString))
                {
                    //...and attempt to open it.
                    conn.Open();

                    //attempt to execute command - selects all elements from Elements_Info table
                    using (SqlCommand comm = new SqlCommand(QUERY_GET_ELEMENTS, conn))
                    {
                        SqlDataReader sdr = comm.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                elements.Add(sdr["Symbol"].ToString(), 
                                    new RowElement(
                                       int.Parse(sdr["PeriodicNumber"].ToString()),
                                                 sdr["FullName"].ToString(),
                                                 sdr["Symbol"].ToString(),
                                    double.Parse(sdr["MolarMass"].ToString())));
                            }
                        }
                    }
                    conn.Close();
                }
                //Fetching from database triggers writing the file locally
                WriteFileToLocalCopy(elements);
            }
            catch (InvalidOperationException ioe)
            {
                System.Diagnostics.Debug.WriteLine(ioe.Message);
                return null;
            }
            catch (SqlException se) //Database could no be opened
            {
                System.Diagnostics.Debug.WriteLine(se.Message);
                return null;
            }

            return elements;
        }

        //*******************************************************************************
        //ParseElementLine() - Takes a read line from a file and parses it into portions 
        //                     to create a RowElement object. 
        //*******************************************************************************
        private RowElement ParseElementLine(string line)
        {
            string[] parsed = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            //expected length is 4
            if (parsed.Length != 4) return new RowElement();

            return new RowElement(int.Parse(parsed[3]), parsed[1], parsed[2], double.Parse(parsed[0]));
        }

        //*******************************************************************************
        //WriteFileToLocalCopy() - Once the dictionary is created from the database, a
        //                         local copy is made.
        //*******************************************************************************
        private void WriteFileToLocalCopy(Dictionary<string, RowElement> elements)
        {
            StreamWriter sw;

            //Attempt to open file containing element data
            try
            {
                sw = new StreamWriter(ELEMENT_DATA_TEXTFILE);
                foreach (RowElement re in elements.Values)
                {
                    string toWrite = re.MolarMass.ToString() + "\t"
                        + re.Name + "\t"
                        + re.Symbol + "\t"
                        + re.AtomicNumber + "\t";
                    sw.WriteLine(toWrite);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                //File could not be written?
            }
        }
    }

// *********************************************************************
//  filename    :   DataSource.cs
//  purpose     :   provide a common connection string for accessing the
//                  database.  employs the singleton pattern.
//
//  written by Jonathan Melcher 2016-03-29
// *********************************************************************
    internal static class DataSource
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                    _connectionString = GetConnectionString();
                return _connectionString;
            }
        }

        private static string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.UserID = "dhospedales1";                                                                                                                                                                                                                                                                                       builder.Password = "Krkrokit88";
            builder.InitialCatalog = "dhospedales1_ElementsDatabase";
            builder.DataSource = "bender.net.nait.ca,24680";
            builder.ConnectTimeout = 30;
            return builder.ConnectionString;
        }
    }
}
