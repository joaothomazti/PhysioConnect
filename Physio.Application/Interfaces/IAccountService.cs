using Physio.Application.Dtos.Account;

namespace Physio.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ResultDto> RegisterUserAsync(RegisterDto register);

        Task<ResultDto> LoginUserAsync(LoginDto login);
    }
}
