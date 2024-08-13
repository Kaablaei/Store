using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace Domain.Users
{
    public class User : IdentityUser<int>
    {

       
        public string Family { get; set; }

        public static User Create(string name, string family, string phone, string email, string password)
        {

            name = Guard.Against.NullOrWhiteSpace(name);
            family = Guard.Against.NullOrEmpty(family);
            phone = Guard.Against.NullOrEmpty(phone);
            email = Guard.Against.NullOrEmpty(email);

            return new User
            {
                PasswordHash = password,
                UserName = name,
                Family = family,
                Email = email,
                PhoneNumber = phone,
            };
        }
        public void Update(string name, string family)
        {
            UserName = name;
            Family = family;
        }
    }
}
