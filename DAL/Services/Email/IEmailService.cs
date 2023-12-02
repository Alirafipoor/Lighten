using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Email
{
    public interface IEmailService
    {
        public Task Execute(string email,string body,string title);
    }
}
