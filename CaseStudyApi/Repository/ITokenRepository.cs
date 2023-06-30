using CaseStudyApi.Models;

namespace CaseStudyApi.Repository
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Users users);
    }
}
