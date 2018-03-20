using FOS.DATA.FileRepositories;
using FOS.MODELS.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.FileRepos
{
    [TestFixture]
    public class FileStateTaxRepositoryTests
    {
        private const string filePath = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\TestFiles\StateTaxes\TestTaxes.txt";

        [TestCase("OH", "Ohio")]
        public void CanGetStateTaxList(string stateAbbreviation, string expectedValue)
        {
            FileStateTaxRepository repo = new FileStateTaxRepository(filePath);

            StateTax actualValue = repo.GetState(stateAbbreviation);

            Assert.IsNotNull(actualValue);
        }
    }
}
