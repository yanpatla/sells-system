using WSventa.Models.Request;
using WSventa.Models.Response;

namespace WSventa.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
