using Dapper;
using Npgsql;
using OTUSControllers;
using OTUSHigloadTestProject.Helpers;
using OTUSHigloadTestProject.Models.Database;
using OTUSHigloadTestProject.Models.Requests;
using OTUSHigloadTestProject.Services.Abstract;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;


namespace OTUSHigloadTestProject.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Task<User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);

            return (await db.QueryAsync<User>($"SELECT * FROM users WHERE login=@login", new { login }))?.FirstOrDefault();
        }

        public async Task<Guid> RegisterAsync(UserRegisterRequest userRegisterRequest)
        {
            using IDbConnection db = new NpgsqlConnection(_connectionString);

            var salt = PasswordHasher.GenerateSalt();
            var passwordHash = PasswordHasher.ComputeHash(userRegisterRequest.Password, salt);

            var newUserId = await db.QuerySingleAsync<Guid>(@"
                            INSERT INTO users
                            (first_name, second_name, age, biography, city, password, salt, login)
                            VALUES(@FirstName,@SecondName,@Age,@Biography,@City,@Password,@Salt,@Login)
                            RETURNING id;",
                            new
                            {
                                Age = userRegisterRequest.Age,
                                Biography = userRegisterRequest.Biography,
                                City = userRegisterRequest.City,
                                Login = userRegisterRequest.Login,
                                Salt = salt,
                                Password = passwordHash,
                                FirstName = userRegisterRequest.First_name,
                                SecondName = userRegisterRequest.Second_name

                            });
            return newUserId;
        }

        public Task<ICollection<User>> SearchAsync(string first_name, string last_name)
        {
            throw new NotImplementedException();
        }
    }
}
