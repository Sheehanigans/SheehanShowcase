using CarDealership.Data.ADORepositories;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.RepositoryTests
{
    public class SpecialsRepoTests
    {
        SpecialRepository repo = new SpecialRepository();

        [Test]
        public void GetSpecials()
        {
            List<Special> specials = repo.GetSpecials();
            var check = specials[0];

            Assert.AreEqual(1, check.SpecialId);
            Assert.AreEqual("MEGA SALE ON COOL CARS", check.SpecialTitle);
            Assert.AreEqual("THE COOLEST CARS have some MEGA SaLeS", check.SpecialMessage);
        }

        //save special
        //delete special 

    }
}
