using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WEBUI.DTOs.ContactDto
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string MapUrl { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
