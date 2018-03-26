using DvdService.Data.Entities;
using DvdService.Data.EntityFrameworkRepos;
using DvdService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Tests.DataTests
{
    public class EFRepoTests
    {
        private EFDvdRepo repo = new EFDvdRepo(new DvdLibraryEntities());

        //Dvd Add(Dvd dvd);

        //void Edit(Dvd dvd);

        //void Delete(int id);

        [Test]
        public void GetAll()
        {
            List<Dvd> dvds = repo.GetAll();

            Assert.IsNotNull(dvds);
        }

        [TestCase(1, true)]
        [TestCase(100, false)]
        public void GetById(int id, bool expected)
        {
            Dvd dvdToGet = repo.GetById(id);

            if (dvdToGet != null)
            {
                Assert.AreEqual("Herbie Fully Loaded", dvdToGet.Title);
            }
            else
            {
                Assert.IsNull(dvdToGet);
            }
        }

        [TestCase("Herbie Fully Loaded")]
        [TestCase("Doctor DoLittle 2")]
        public void GetByTitle(string title)
        {
            List<Dvd> titlesToGet = repo.GetByTitle(title);

            if (titlesToGet.Any())
            {
                Dvd check = titlesToGet[0];
                Assert.AreEqual("Herbie Fully Loaded", check.Title);
                Assert.IsNotNull(titlesToGet);
            }
            else
            {
                Assert.IsEmpty(titlesToGet);
            }
        }

        [TestCase(2006)]
        [TestCase(2020)]
        public void GetByReleaseYear(int year)
        {
            List<Dvd> yearsToGet = repo.GetByReleaseYear(year);

            if (yearsToGet.Any())
            {
                Dvd check = yearsToGet[0];
                Assert.AreEqual(2006, check.ReleaseYear);
            }
            else
            {
                Assert.IsEmpty(yearsToGet);
            }
        }

        [TestCase("Lindsay Lohan")]
        [TestCase("Michael Bay")]
        public void GetByDirector(string director)
        {
            List<Dvd> directorsToGet = repo.GetByDirector(director);

            if (directorsToGet.Any())
            {
                Dvd check = directorsToGet[0];
                Assert.AreEqual("Lindsay Lohan", check.Director);
            }
            else
            {
                Assert.IsEmpty(directorsToGet);
            }
        }

        [TestCase("PG")]
        [TestCase("WUT")]
        public void GetByRating(string rating)
        {
            List<Dvd> ratingsToGet = repo.GetByRating(rating);

            if (ratingsToGet.Any())
            {
                Dvd check = ratingsToGet[0];
                Assert.AreEqual("PG", check.Rating);
            }
            else
            {
                Assert.IsEmpty(ratingsToGet);
            }
        }
    }
}
