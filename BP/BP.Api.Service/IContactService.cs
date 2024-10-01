using System;
using System.Collections.Generic;
using System.Text;
using BP.Api.Models;

namespace BP.Api.Service
{
    public interface IContactService
    {
        public ContactDVO GetContactById(int Id);
    }
}
