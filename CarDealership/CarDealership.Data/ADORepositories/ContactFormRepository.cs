using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class ContactFormRepository : IContactFormRepository
    {
        public ContactForm AddContactForm(ContactForm contactForm)
        {
            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                connection.Execute(
                    "AddContactForm",
                    contactForm,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }

            return contactForm;
        }
    }
}
