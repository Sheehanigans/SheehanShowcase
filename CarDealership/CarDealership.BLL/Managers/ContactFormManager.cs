using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class ContactFormManager
    {
        private IContactFormRepository Repo { get; set; }

        public ContactFormManager(IContactFormRepository cfRepo)
        {
            Repo = cfRepo;
        }

        public TResponse<ContactForm> AddContactForm(ContactForm cf)
        {
            var response = new TResponse<ContactForm>();

            //cf validation 

            if (cf.FormMessage == null)
            {
                response.Message = "Contact form message invalid";
                response.Success = false;
            }
            else if (cf.Email == null && cf.Phone == null)
            {
                response.Message = "Email or phone required";
                response.Success = false;
            }
            else if (cf.CustomerName == null || cf.CustomerName.Length > 50)
            {
                response.Message = "Customer name invalid";
                response.Success = false;
            }
            else
            {
                response.Payload = Repo.AddContactForm(cf);

                if (response.Payload.ContactFormId == cf.ContactFormId
                    && response.Payload.CustomerName == cf.CustomerName
                    && response.Payload.Email == cf.Email
                    && response.Payload.FormMessage == cf.FormMessage
                    && response.Payload.Phone == cf.Phone)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Contact form add unsuccessful. Contact Form ID: {cf.ContactFormId}";
                }
            }            

            return response;
        }
    }
}
