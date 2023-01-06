using OTUSControllers;
using OTUSHigloadTestProject.Services.Abstract;

namespace OTUSHigloadTestProject.Services.Implementation
{
    public class UserService : IUserService
    {
        public Task<User> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response2> RegisterAsync(Body2 body)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> SearchAsync(string first_name, string last_name)
        {
            throw new NotImplementedException();
        }
    }
}
