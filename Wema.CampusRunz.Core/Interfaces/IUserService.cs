using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.DTOs.Request;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface IUserService
    {

        Task<AuthenticationResult> SignupAsync(UserRegistrationRequest request);

        Task<AuthenticationResult> SigninAsync(string email, string password);

        Task<AuthenticationResult> ForgotPasswordAsync(string email);

        Task<AuthenticationResult> VerifyTokenAsync(string token);
        Task<AuthenticationResult> ResetPasswordAsync(string username, string newpassword, string confirmnewpassword);
    }
}
