using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Physio.Application.Dtos.Account;
using Physio.Application.Interfaces;
using Physio.Domain.Models;
using Physio.Domain.Models.Enum;

namespace Physio.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<ResultDto> LoginUserAsync(LoginDto login)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == login.UserName);
            if (user == null)
                return new ResultDto { Success = false, Errors = new[] { "Invalid Username!" } };


            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded)
                return new ResultDto { Success = false, Errors = new[] { "Username not found and/or password incorrect" } };


            return new ResultDto
            {
                Success = true,
                Data = new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            };

        }

        public async Task<ResultDto> RegisterUserAsync(RegisterDto register)
        {
            var existingUser = await _userManager.FindByEmailAsync(register.Email);
            if (existingUser != null)
                return new ResultDto { Success = false, Errors = new[] { "Email is already in use." } };

            if (!Enum.IsDefined(typeof(UserType), register.UserType))
                return new ResultDto { Success = false, Errors = new[] { "Invalid UserType provided." } };

            var appUser = new User
            {
                UserName = register.Username,
                Email = register.Email,
                UserType = register.UserType
            };

            var createdUser = await _userManager.CreateAsync(appUser, register.Password);
            if (!createdUser.Succeeded)
                return new ResultDto { Success = false, Errors = createdUser.Errors.Select(e => e.Description).ToArray() };

            string role = register.UserType == UserType.Physiotherapist ? "Physiotherapist" : "Client";
            var roleResult = await _userManager.AddToRoleAsync(appUser, role);

            if (!roleResult.Succeeded)
                return new ResultDto { Success = false, Errors = roleResult.Errors.Select(e => e.Description).ToArray() };

            return new ResultDto
            {
                Success = true,
                Data = new NewUserDto
                {
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                    Token = _tokenService.CreateToken(appUser)
                }
            };
        }
    }
}
