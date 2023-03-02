using Dapper;
using Npgsql;
using OTUSHigloadTestProject.DTO;
using OTUSHigloadTestProject.Helpers;
using OTUSHigloadTestProject.Models.Database;
using OTUSHigloadTestProject.Models.Requests;
using OTUSHigloadTestProject.Services.Abstract;
using System.Data;


namespace OTUSHigloadTestProject.Services.Implementation
{
    public class UserService : IUserService
    {
        //private readonly string _connectionString;
        private readonly IDbConnection _dbConnection;

        public UserService(IDbConnection dbConnection)
        {
           _dbConnection = dbConnection;
        }
        public async Task<UserFormDto?> GetByIdAsync(string id)
        {
            return (await _dbConnection.QueryAsync<UserFormDto>(@"
                                SELECT
                                id,
                                first_name as FirstName,
                                second_name as SecondName,
                                age,
                                biography,
                                city,
                                login
                                FROM users WHERE id=@id",
                                new { id = new Guid(id) }))?.FirstOrDefault();
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            //using IDbConnection db = new NpgsqlConnection(_connectionString);

            return (await _dbConnection.QueryAsync<User>($"SELECT * FROM users WHERE login=@login", new { login }))?.FirstOrDefault();
        }

        public async Task<Guid> RegisterAsync(UserRegisterRequest userRegisterRequest)
        {
            //using IDbConnection db = new NpgsqlConnection(_connectionString);

            var salt = PasswordHasher.GenerateSalt();
            var passwordHash = PasswordHasher.ComputeHash(userRegisterRequest.Password, salt);

            return await _dbConnection.QuerySingleAsync<Guid>(@"
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
        }

        public async Task<IEnumerable<UserFormDto>> SearchAsync(string firstName, string lastName)
        {
            if (firstName.Length < 3 || lastName.Length < 3) throw new Exception("Имя и фамилия должны содержать не менее 3 букв");

            //using IDbConnection db = new NpgsqlConnection(_connectionString);

            return await _dbConnection.QueryAsync<UserFormDto>(@"
                                SELECT
                                id,
                                first_name as FirstName,
                                second_name as SecondName,
                                age,
                                biography,
                                city as City,
                                login
                                FROM users WHERE LOWER(first_name) like @firstName AND LOWER(second_name) like @secondName",
                       new { firstName = $"{firstName.ToLower()}%", secondName = $"{lastName.ToLower()}%" });
        }
    }
}
