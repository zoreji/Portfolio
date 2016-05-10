// ***********************************************************
//  filename    :   IRepo.cs
//  purpose     :   provide an API for FTM_Repo, for use with
//                  FormulaToMass_UI
//
//  written by David Hospedales on 2016-04-01
// ***********************************************************
using System.Collections.Generic;
namespace FormulaToMass_REPO
{
    public interface IRepo
    {
        //Call to receive a dictionary as prototyped below with Chemical symbol as key
        //  and RowElement type as Value. This function will access either a local text file
        //  or attempt to connect to a database to receive the information.
        //Returns null if a dictionary could not be created.
        Dictionary<string, RowElement> GetElementData();
    }
}
