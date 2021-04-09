using Microsoft.AspNetCore.Identity;

namespace Lab4new.Models
{


    public class TcgUser : IdentityUser
    {
        public string favourite { get; set; }
    }


}