using System;
using System.Collections.Generic;
using System.Linq;
using UserSignUp.BusinessServices.Repository.Interface;
using UserSignUp.Domain;

namespace UserSignUp.BusinessServices.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>();
        private int id = 100;

        public User AddUser(User newUser)
        {
            var user = new User
            {
                Id = id++,
                EmailAddress = newUser.EmailAddress,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PhoneNumber = newUser.PhoneNumber,
                AddressLine1 = newUser.AddressLine1,
                AddressLine2 = newUser.AddressLine2,
                City = newUser.City,
                State = newUser.State,
                ZipCode = newUser.ZipCode,
                AllowNotifications = newUser.AllowNotifications,
                AllowPromoEmails = newUser.AllowPromoEmails
            };
            users.Add(user);
            return user;
        }

        public User Login(string username, string password) =>
            users.FirstOrDefault(t => string.Compare(t.EmailAddress, username, true).Equals(0)
                        && string.Compare(t.Password, password, false).Equals(0));

        public User GetUserInfo(int id) =>
            users.FirstOrDefault(t => t.Id == id);

        public bool UpdateActivation(string code)
        {
            var user = users.FirstOrDefault(t => t.ActivationCode == code && t.ActivationMailSent);
            if (user != null)
            {
                user.IsActive = true;
                return true;
            }
            return false;
        }

        public User UpdateActivation(int id, string code)
        {
            var user = users.FirstOrDefault(t => t.Id == id);
            user.ActivationMailSent = true;
            user.ActivationCode = code;

            return user;
        }

        public bool UserExists(string email) =>
            users.Any(t => string.Compare(t.EmailAddress, email, true).Equals(0));
    }
}
