using DvdService.Data.Interfaces;
using DvdService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using DvdService.Data.Connections;

namespace DvdService.Data.ADORepos
{
    public class ADODvdRepo : IDvdRepository
    {
        //add with sproc
        public Dvd Add(Dvd dvd)
        {
            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                connection.Execute(
                    "Add",
                    dvd,
                    commandType: CommandType.StoredProcedure
                    );
            }

            return dvd;
        }

        //delete with sproc
        public void Delete(int id)
        {
            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DvdId", id);

                connection.Execute(
                    "Delete",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        //edit with sproc 
        public void Edit(Dvd dvd)
        {
            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                connection.Execute(
                    "Edit",
                    dvd,
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        //get all Dvds with sproc
        public List<Dvd> GetAll()
        {
            List<Dvd> dvds;

            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                dvds = connection.Query<Dvd>(
                    "GetAll",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return dvds;
        }

        //sproc takes director name, pupulates to list
        public List<Dvd> GetByDirector(string directorName)
        {
            List<Dvd> dvds;

            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Director", directorName);

                dvds = connection.Query<Dvd>(
                    "GetByDirector",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return dvds;
        }

        //sproc takes id, populate to list
        public Dvd GetById(int id)
        {
            Dvd dvdToReturn;

            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DvdId", id);

                dvdToReturn = connection.Query<Dvd>(
                    "GetById",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).SingleOrDefault();
            }

            return dvdToReturn;

        }

        //sproc takes rating, populate to list
        public List<Dvd> GetByRating(string rating)
        {
            List<Dvd> dvds;

            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Rating", rating);

                dvds = connection.Query<Dvd>(
                    "GetByRating",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return dvds;
        }

        //sproc takes year, populate to list
        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            List<Dvd> dvds;

            var parameters = new DynamicParameters();
            parameters.Add("@ReleaseYear", releaseYear);

            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                dvds = connection.Query<Dvd>(
                    "GetByReleaseYear",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return dvds;
        }

        //sproc takes title, populate to list
        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> dvds;

            using (var connection = ADODatabaseConnection.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Title", title);

                dvds = connection.Query<Dvd>(
                    "GetByTitle",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return dvds;
        }
    }
}
