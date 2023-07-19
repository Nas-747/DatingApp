using API.Entities;

namespace API.interfaces
{
    public interface ITokenService
    {
        String CreateToken (AppUser user);
    }
}