using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POO.Utilities;

namespace POO.Models
{
    class User
    {
        
        public string? Name { get; set; }

        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public short Age { get; set; }

        public string? Telephone { get; set; }

        public bool IsValid(bool validateAge = true)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || !HelperValidator.IsValidEmail(Email) || 
                Age < 0 || Age > 120)
            
                return false;
            

            if ((Age < 0 || Age > 120) && validateAge)
            
                return false;
            

            return true;
        }

    }
}
