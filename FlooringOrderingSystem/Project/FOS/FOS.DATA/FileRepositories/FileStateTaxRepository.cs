using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA.FileRepositories
{
    public class FileStateTaxRepository : IStateTaxRepository
    {
        private string _stateTaxFilePath = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\Taxes.txt";

        public FileStateTaxRepository(string stateTaxFilePath)
        {
            _stateTaxFilePath = stateTaxFilePath;
        }

        public StateTax GetState(string stateAbbr)
        {
            List<StateTax> states = new List<StateTax>();

            StateTax stateToReturn = null;

            if (File.Exists(_stateTaxFilePath))
            {
                using (StreamReader sr = new StreamReader(_stateTaxFilePath, true))
                {
                    sr.ReadLine();
                    string line;

                    while((line = sr.ReadLine()) != null)
                    {
                        StateTax stateInFile = new StateTax();

                        string[] columns = line.Split(',');

                        stateInFile.StateAbbreviation = columns[0];
                        stateInFile.StateName = columns[1];
                        stateInFile.TaxRate = decimal.Parse(columns[2]);

                        states.Add(stateInFile);
                    }

                    if (states.Any(a => a.StateAbbreviation == stateAbbr))
                    {
                        stateToReturn = states
                            .Where(w => w.StateAbbreviation == stateAbbr)
                            .First();
                    }
                }
            }

            return stateToReturn;
        }

        public List <StateTax> ListStates()
        {
            List<StateTax> states = new List<StateTax>();

            if (File.Exists(_stateTaxFilePath))
            {
                using (StreamReader sr = new StreamReader(_stateTaxFilePath, true))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        StateTax stateInFile = new StateTax();

                        string[] columns = line.Split(',');

                        stateInFile.StateAbbreviation = columns[0];
                        stateInFile.StateName = columns[1];
                        stateInFile.TaxRate = decimal.Parse(columns[2]);

                        states.Add(stateInFile);
                    }
                }
            }

            return states;

        }
    }
}
