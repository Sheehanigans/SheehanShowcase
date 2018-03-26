using DvdService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Data.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();

        Dvd GetById(int id);

        List<Dvd> GetByTitle(string title);

        List<Dvd> GetByReleaseYear(int releaseYear);

        List<Dvd> GetByDirector(string directorName);

        List<Dvd> GetByRating(string rating);

        Dvd Add(Dvd dvd);

        void Edit(Dvd dvd);

        void Delete(int id);
    }
}
