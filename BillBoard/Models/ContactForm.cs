using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillBoard.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Need { get; set; }
        public string Message { get; set; }

    }
}