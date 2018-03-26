using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdService.Data.ADORepos;
using DvdService.Models;
using NUnit;
using NUnit.Framework;

namespace DvdService.Tests.DataTests
{
    [TestFixture]
    public class ADORepoTests
    {
        private ADODvdRepo repo = new ADODvdRepo();

        //Dvd Add(Dvd dvd);

        //void Edit(Dvd dvd);

        //void Delete(int id);

        [Test]
        public void GetAll()
        {
            List<Dvd> dvds = repo.GetAll();

            Assert.IsNotNull(dvds);
        }

        [TestCase(2, true)]
        [TestCase(100, false)]
        public void GetById(int id, bool expected)
        {
            Dvd dvdToGet = repo.GetById(id);

            if (expected == true)
            {
                Assert.AreEqual("Gladiator", dvdToGet.Title);
            }
            else
            {
                Assert.IsNull(dvdToGet);
            }
        }

        [TestCase("Gladiator")]
        [TestCase("Doctor DoLittle 2")]
        public void GetByTitle(string title)
        {
            List<Dvd> titlesToGet = repo.GetByTitle(title);

            if (titlesToGet.Any())
            {
                Dvd check = titlesToGet[0];
                Assert.AreEqual("Gladiator", check.Title);
                Assert.IsNotNull(titlesToGet);
            }
            else
            {
                Assert.IsEmpty(titlesToGet);
            }
        }

        [TestCase(2001)]
        [TestCase(2020)]
        public void GetByReleaseYear(int year)
        {
            List<Dvd> yearsToGet = repo.GetByReleaseYear(year);

            if (yearsToGet.Any())
            {
                Dvd check = yearsToGet[0];
                Assert.AreEqual(2001, check.ReleaseYear);
            }
            else
            {
                Assert.IsEmpty(yearsToGet);
            }
        }

        [TestCase("Ridley Scott")]
        [TestCase("Michael Bay")]
        public void GetByDirector(string director)
        {
            List<Dvd> directorsToGet = repo.GetByDirector(director);

            if (directorsToGet.Any())
            {
                Dvd check = directorsToGet[0];
                Assert.AreEqual("Ridley Scott", check.Director);
            }
            else
            {
                Assert.IsEmpty(directorsToGet);
            }
        }

        [TestCase("PG-13")]
        [TestCase("WUT")]
        public void GetByRating(string rating)
        {
            List<Dvd> ratingsToGet = repo.GetByRating(rating);

            if (ratingsToGet.Any())
            {
                Dvd check = ratingsToGet[0];
                Assert.AreEqual("PG-13", check.Rating);
            }
            else
            {
                Assert.IsEmpty(ratingsToGet);
            }
        }
    }
}
