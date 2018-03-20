using FOS.BLL.Managers;
using FOS.TESTS.MockRepos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.TESTS.ManagerTests
{
    [TestFixture]
    public class StateTaxManagerTests
    {
        [TestCase("OH",true)]
        [TestCase("MN", false)]
        public static void GetState(string stateAbbreviation, bool expectedResult)
        {
            StateTaxManager manager = new StateTaxManager(new AlwaysReturnsStateTax());

            var test = manager.GetStateTax(stateAbbreviation);

            Assert.IsTrue(test.Success);
            Assert.IsNotNull(test.State);
        }

        [TestCase("WI", false)]
        public static void GetStateNull(string stateAbbreviation, bool expectedResult)
        {
            StateTaxManager manager = new StateTaxManager(new AlwaysReturnsNullStateTax());

            var test = manager.GetStateTax(stateAbbreviation);

            Assert.IsFalse(test.Success);
            Assert.IsNull(test.State);
        }
    }
}
