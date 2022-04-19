using WebAPI.Models.Domain;

namespace WebAPI.Repository
{
    public interface ITokenHandler 
    {
        Task<string> CreateTokenAsync(User user);
    }
}
