using DvdService.Data.Interfaces;
using DvdService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Data.MemoryRepos
{
    public class InMemoryDvdRepo : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            {DvdId=1, Title="Hot Fuzz", ReleaseYear=2011, Director="Simon Pegg", Rating="R", Notes="This is my favorite movie" },
            new Dvd
            {DvdId=2, Title="Interstellar", ReleaseYear=2012, Director="Chrostopher Nolan", Rating="PG-13", Notes="This is my favorite movie TOO" }
        };

        public Dvd Add(Dvd newDvd)
        {
            if (_dvds.Any())
            {
                newDvd.DvdId = _dvds.Max(m => m.DvdId) + 1;
            }
            else
            {
                newDvd.DvdId = 0;
            }

            _dvds.Add(newDvd);

            return newDvd;
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(m => m.DvdId == id);
        }

        public void Edit(Dvd editedDvd)
        {
            _dvds.RemoveAll(m => m.DvdId == editedDvd.DvdId);
            _dvds.Add(editedDvd);
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public List<Dvd> GetByDirector(string directorName)
        {
            return _dvds.Where(m => m.Director.ToLower() == directorName.ToLower()).ToList();
        }

        public Dvd GetById(int id)
        {
            return _dvds.FirstOrDefault(m => m.DvdId == id);
        }

        public List<Dvd> GetByRating(string rating)
        {
            return _dvds.Where(m => m.Rating.ToLower() == rating.ToLower()).ToList();
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            return _dvds.Where(m => m.ReleaseYear == releaseYear).ToList();
        }

        public List<Dvd> GetByTitle(string title)
        {
            return _dvds.Where(m => m.Title.ToLower() == title.ToLower()).ToList();
        }
    }
}
