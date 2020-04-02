using System;
using System.Collections.Generic;
using System.Text;
using UserSignUp.Domain;

namespace UserSignUp.BusinessServices.Inteface
{
    public interface IRegistrationService
    {
        bool IsUserSignedUp(User signUp);
        User RegisterUser(User signUp);
        bool UpdateActivation(string code);
        User LoginUser(string username, string password);
    }
}
