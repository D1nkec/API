using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
