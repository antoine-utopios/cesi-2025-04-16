using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Cesi.Builder.Classes
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public class Builder
        {
            private AppUser _appUser;

            public Builder SetId(int id)
            {
                _appUser.Id = id;
                return this;
            }

            public Builder SetFirstName(string firstName)
            {
                _appUser.FirstName = firstName;
                return this;
            }

            public Builder SetLastName(string lastName)
            {
                _appUser.LastName = lastName;
                return this;
            }

            public Builder SetEmail(string email)
            {
                _appUser.Email = email;
                return this;
            }

            public Builder SetPhoneNumber(string phoneNumber)
            {
                _appUser.PhoneNumber = phoneNumber;
                return this;
            }

            public AppUser Build()
            {
                return _appUser;
            }

        }
    }
}
