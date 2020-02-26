using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface IUserService
    {

        Task<AuthenticationResult> SignupAsync(string firstname, string lastname, string email, string password, string confirm_pass, string phonenumber, string category, string businessname, string businessdesc, string base64image);

        Task<AuthenticationResult> SigninAsync(string email, string password);

        Task<AuthenticationResult> ForgotPasswordAsync(string email);

        Task<AuthenticationResult> VerifyTokenAsync(string token);
        Task<AuthenticationResult> ResetPasswordAsync(string username, string newpassword, string confirmnewpassword);
    }
}
