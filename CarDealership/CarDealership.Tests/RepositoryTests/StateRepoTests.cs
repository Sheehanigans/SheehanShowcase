using CarDealership.Data.ADORepos;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.RepositoryTests
{
    public class StateRepoTests
    {
        StateRepository repo = new StateRepository();

        [Test]
        public void GetAll()
        {
            List<State> states = repo.GetAll();

            Assert.IsNotNull(states);
            var check = states[0];
            Assert.AreEqual("Alabama", check.StateName);
            Assert.AreEqual("AL", check.StateAbbreviation);
            Assert.AreEqual(1, check.StateId);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void GetState(int stateId)
        {
            State stateToGet = repo.GetState(stateId);

            if (stateToGet != null)
            {
                Assert.AreEqual(1, stateToGet.StateId);
                Assert.AreEqual("Alabama", stateToGet.StateName);
                Assert.AreEqual("AL", stateToGet.StateAbbreviation);
            }
            else
            {
                Assert.IsNull(stateToGet);
            }
        }
    }
}
