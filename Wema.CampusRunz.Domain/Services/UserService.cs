using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.DTOs;
using Wema.CampusRunz.Core.DTOs.Request;
using Wema.CampusRunz.Core.Interfaces;
using Wema.CampusRunz.Core.Models;
using Wema.CampusRunz.Core.Options;
using Wema.CampusRunz.Data.Data;

namespace Wema.CampusRunz.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        //private readonly UserToken _userToken;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, JwtSettings jwtSettings, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            //_userToken = userToken;
            _applicationDbContext = applicationDbContext;

        }



        public async Task<AuthenticationResult> SignupAsync(UserRegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            var currentuser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == request.phoneNo);

            if (existingUser != null)
            {

                return new AuthenticationResult
                {
                    Error = "User already exists" 
                };
            }

            if (currentuser != null)
            {
                return new AuthenticationResult
                {
                    Error = "User with this number already exists"
                };
            }



            if (request.Password != request.confirmPassword)
            {
                return new AuthenticationResult
                {
                    Error = "Password Mismatch"
                };
            }

            //var newUser = new IdentityUser
            var newUser = new AppUser
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.phoneNo,
                Category = request.Category,
                Businessname = request.businessName,
                BusinessDescription = request.businessDescription,
                BusinessLogo = request.businessLogo

            };

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }



            return GenerateAuthenticationResultForUser(newUser);

        }

        public async Task<AuthenticationResult> SigninAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            string Email = "";
            string checkForEmail = "@";



            if (!email.Contains(checkForEmail))
            {
                var PhoneNumber = email;

                var confirmUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == email);

                var getEmail = confirmUser.Email;

                Email = getEmail;

                var newUser = await _userManager.FindByEmailAsync(getEmail);

                if (confirmUser == null)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { "User does not exist" }
                    };
                }


                var loginWithPhone = await _userManager.CheckPasswordAsync(newUser, password);

                if (!loginWithPhone)
                {
                    return new AuthenticationResult
                    {
                        Error = "User/Password Combination is wrong"
                    };
                }


            }

            else
            {
                var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

                Email = email;

                if (!userHasValidPassword)

                {
                    return new AuthenticationResult
                    {
                        Error = "User/Password Combination is wrong"
                    };

                }
            }

            var currentuser = _userManager.Users.FirstOrDefault(x => x.UserName == Email);


            return GenerateAuthenticationResultForUser2(currentuser);
        }

        private AuthenticationResult GenerateAuthenticationResultForUser2(AppUser currentuser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: currentuser.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim("id", value:  currentuser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(TokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                Firstname = currentuser.Firstname,
                Lastname = currentuser.Lastname,
                Email = currentuser.Email,
                PhoneNo = currentuser.PhoneNumber,
                Category = currentuser.Category,
                businessName = currentuser.Businessname,
                businessLogo = currentuser.BusinessLogo
            };
        }


        private AuthenticationResult GenerateAuthenticationResultForUser(AppUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: newUser.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(type: "id", value: newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(TokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                Firstname = newUser.Firstname,
                Lastname = newUser.Lastname,
                Email = newUser.Email,
                PhoneNo = newUser.PhoneNumber,
                Category = newUser.Category,
                businessName = newUser.Businessname,
                businessLogo = newUser.BusinessLogo
            };
        }

        public async Task<AuthenticationResult> ForgotPasswordAsync(string username)
        {

            string checkForEmail = "@";
            string userId = "";          

            if (!username.Contains(checkForEmail))
            {
                var PhoneNumber = username;

                var confirmPhoneNumber =  _userManager.Users.FirstOrDefault(x => x.PhoneNumber == username);

               

                if (confirmPhoneNumber == null)
                {
                    return new AuthenticationResult
                    {
                        Error = "The information you entered does not match our records."
                    };
                }

                userId = confirmPhoneNumber.Id;

                var checkExistingToken = await _applicationDbContext.Tokens.Where(T => T.UserId == userId).FirstOrDefaultAsync();

                if(checkExistingToken != null)
                {
                    _applicationDbContext.Tokens.Remove(checkExistingToken);

                    await _applicationDbContext.SaveChangesAsync();


                }

            }

            else
            {
                var user = await _userManager.FindByEmailAsync(username);

                    if (user == null)
                    {
                        return new AuthenticationResult
                        {
                            Error = "The information you entered does not match our records."

                        };
                    }

                userId = user.Id;

                var checkExistingToken = await _applicationDbContext.Tokens.Where(T => T.UserId == userId).FirstOrDefaultAsync();

                if (checkExistingToken != null)
                {
                    _applicationDbContext.Tokens.Remove(checkExistingToken);

                    await _applicationDbContext.SaveChangesAsync();


                }
            }

            //var currentuser = _userManager.Users.FirstOrDefault(x => x.UserName == email);

            var Token = GenerateToken();

            Tokens rsttokens = new Tokens();

            rsttokens.UserId = userId;
            rsttokens.Token = Token;
            _applicationDbContext.Tokens.Add(rsttokens);
            if (await _applicationDbContext.SaveChangesAsync() > 0)
            {
                return new AuthenticationResult
                {
                    Success = true,

                };
            }
            return null;
        }

        private string GenerateToken()
        {
            StringBuilder builder = new StringBuilder();

            Random rstToken = new Random();

            char ch;
            for (int i = 0; i < 6; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rstToken.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public async Task<AuthenticationResult> VerifyTokenAsync(string token)
        {
            var ValidToken = await _applicationDbContext.Tokens.Where(T => T.Token == token).FirstOrDefaultAsync();

            var user = await  _userManager.FindByIdAsync(ValidToken.UserId);

           
            if (ValidToken == null)
            {
                return new AuthenticationResult
                {
                    Error = "Invalid Token"
                };

            }
            _applicationDbContext.Tokens.Remove(ValidToken);

            await _applicationDbContext.SaveChangesAsync();

            return GenerateAuthenticationResultForUser3(user);

        }

        private AuthenticationResult GenerateAuthenticationResultForUser3(AppUser user) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
                {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: user.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(type: "id", value: user.Id) 
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(TokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),

            };

        }
        public async Task<AuthenticationResult> ResetPasswordAsync(string username, string newpassword, string confirmnewpassword)
        {
            var user = await _userManager.FindByEmailAsync(username);


            if (user == null)
            {
                return new AuthenticationResult
                {
                    Error = "Username you entered does not match our records."

                };
            }



            if (newpassword != confirmnewpassword)
            {
                return new AuthenticationResult
                {
                    Error = "Password Mismatch"
                };
            }

            var newPassword = _userManager.PasswordHasher.HashPassword(user, newpassword);
            user.PasswordHash = newPassword;
            var res = await _userManager.UpdateAsync(user);

            if (res.Succeeded)
            {
                return new AuthenticationResult
                {
                    Success = true
                };

            }
            return null;


        }
    }

}
