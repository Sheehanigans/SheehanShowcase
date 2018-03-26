using DvdService.Data.Entities;
using DvdService.Data.Interfaces;
using DvdService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DvdService.Data.Connections;

namespace DvdService.Data.EntityFrameworkRepos
{
    public class EFDvdRepo : IDvdRepository
    {
        private readonly DvdLibraryEntities context;

        public EFDvdRepo(DvdLibraryEntities context)
        {
            this.context = context;
        }

        public Dvd Add(Dvd dvd)
        {
            Dvd newDvd = new Dvd();
            newDvd.DvdId = dvd.DvdId;
            newDvd.Title = dvd.Title;
            newDvd.Director = dvd.Director;
            newDvd.ReleaseYear = dvd.ReleaseYear;
            newDvd.Rating = dvd.Rating;
            newDvd.Notes = dvd.Notes;

            context.Dvds.Add(newDvd);
            context.SaveChanges();

            return dvd;
        }

        public void Delete(int id)
        {
            var dvd = context.Dvds.FirstOrDefault(d => d.DvdId == id);

            if(dvd != null)
            {
                context.Dvds.Remove(dvd);
                context.SaveChanges();
            }
        }

        public void Edit(Dvd dvd)
        {
            Dvd newDvd = new Dvd();
            newDvd.DvdId = dvd.DvdId;
            newDvd.Title = dvd.Title;
            newDvd.Director = dvd.Director;
            newDvd.ReleaseYear = dvd.ReleaseYear;
            newDvd.Rating = dvd.Rating;
            newDvd.Notes = dvd.Notes;

            context.Entry(newDvd).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Dvd> GetAll()
        {
            return context.Dvds.ToList();
        }

        public List<Dvd> GetByDirector(string directorName)
        {
            return context.Dvds.Where(d => d.Director == directorName).ToList();
        }

        public Dvd GetById(int id)
        {
            return context.Dvds.Where(w => w.DvdId == id).FirstOrDefault();
        }

        public List<Dvd> GetByRating(string rating)
        {
            return context.Dvds.Where(r => r.Rating == rating).ToList();
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            return context.Dvds.Where(r => r.ReleaseYear == releaseYear).ToList();
        }

        public List<Dvd> GetByTitle(string title)
        {
            return context.Dvds.Where(t => t.Title == title).ToList();
        }
    }
}
