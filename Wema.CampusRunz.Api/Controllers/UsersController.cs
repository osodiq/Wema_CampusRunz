using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.DTOs.Request;
using Wema.CampusRunz.Core.DTOs.Response;
using Wema.CampusRunz.Core.Interfaces;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        string checkForEmail = "@";

        public UsersController(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost(template: ApiRoutes.Auth.Signup)]
        public async Task<IActionResult> Signup([FromBody] UserRegistrationRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _userService.SignupAsync(request);
            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Error = authResponse.Error
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Code = "201",
                Token = authResponse.Token,
                User = new UserDetails
                {

                    Firstname = authResponse.Firstname,
                    Lastname = authResponse.Lastname,
                    Email = authResponse.Email,
                    mobile = authResponse.PhoneNo,
                    Category = authResponse.Category,
                    businessName = authResponse.businessName,
                    businessLogo = authResponse.businessLogo

                }
            });
        }

        [HttpPost(template: ApiRoutes.Auth.Signin)]
        public async Task<IActionResult> Signin([FromBody] UserLoginRequest request)
        {
            var authResponse = await _userService.SigninAsync(request.username, request.password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Code = "400",
                    Error = authResponse.Error
                });
            }

            if (request.username.Contains(checkForEmail))
            {

                var currentuser = _userManager.Users.FirstOrDefault(x => x.UserName == request.username);

                return Ok(new AuthSuccessResponse
                {
                    Code = "200",
                    Token = authResponse.Token,
                    User = new UserDetails
                    {

                        Firstname = authResponse.Firstname,
                        Lastname = authResponse.Lastname,
                        Email = authResponse.Email,
                        mobile = authResponse.PhoneNo,
                        Category = authResponse.Category,
                        businessName = authResponse.businessName,
                        businessLogo = authResponse.businessLogo

                    }
                });

            }
            else
            {
                var currentuser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == request.username);

                return Ok(new AuthSuccessResponse
                {
                    Code = "200",
                    Token = authResponse.Token,
                    User = new UserDetails
                    {

                        Firstname = authResponse.Firstname,
                        Lastname = authResponse.Lastname,
                        Email = authResponse.Email,
                        mobile = authResponse.PhoneNo,
                        Category = authResponse.Category,
                        businessName = authResponse.businessName,
                        businessLogo = authResponse.businessLogo

                    }
                });

            }

        }

        [HttpPost(template: ApiRoutes.Auth.ForgotPassword)]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequest request)
        {
            var authResponse = await _userService.ForgotPasswordAsync(request.Username);


            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Error = authResponse.Error
                });
            }

            return Ok(new GenerateTokenSuccess
            {
                Code = "200",
                Message = "Password reset token successfully generated."
            });

        }

        [HttpPost(template: ApiRoutes.Auth.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromBody] ValidateTokenRequest request)
        {
            var authResponse = await _userService.VerifyTokenAsync(request.Token);


            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Error = authResponse.Error
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                Message = "Token has been validated"
            });



        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(template: ApiRoutes.Auth.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
           
            AppUser user = await _userManager.FindByEmailAsync(request.Username);

            var userId = user.Id;

            if (userId != User.FindFirst("id").Value)
            {
                return Unauthorized();
            }

            var authResponse = await _userService.ResetPasswordAsync(request.Username, request.Password, request.ConfirmPassword);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Error = authResponse.Error
                });
            }

            return Ok(new GenerateTokenSuccess
            {
                Message = "Password reset successfully. Please login with your new password."
            });

        }

    }

}