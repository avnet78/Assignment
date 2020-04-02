using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using UserSignUp.BusinessServices.Inteface;
using UserSignUp.BusinessServices.Repository.Interface;
using UserSignUp.Domain;

namespace UserSignUp.BusinessServices.Implementation
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public User LoginUser(string username, string password)=>
            _userRepository.Login(username, password);

        public User RegisterUser(User signUp)
        {
            var userAdded = _userRepository.AddUser(signUp);
            var activationCode = Guid.NewGuid().ToString();
            SendVerificationEmail(signUp.EmailAddress, activationCode);
            return _userRepository.UpdateActivation(userAdded.Id, activationCode);
        }

        public bool IsUserSignedUp(User signUp) =>
            _userRepository.UserExists(signUp.EmailAddress);

        private void SendVerificationEmail(string emailID, string activationCode)
        {
            var verificationURL = $"{ConfigurationManager.AppSettings["RequestURL"]}Home/Activate?code={activationCode}";
            var fromEmail = new MailAddress("test@gmail.com", "Promotion Notification");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "test";
            string subject = "Account Created";
            string body = $"Your new account is successfully created. Please click <a href='{verificationURL}'>here</a> to verify your account";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public bool UpdateActivation(string code) =>
            _userRepository.UpdateActivation(code);
    }
}
