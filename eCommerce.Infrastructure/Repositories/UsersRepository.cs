using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext context;

        public UsersRepository(DapperDbContext context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            string query =
                "INSERT INTO public.\"Users\" "
                + "(\"UserId\", \"Email\", \"Password\", \"PersonName\", \"Gender\") "
                + "VALUES (@UserId, @Email, @Password, @PersonName, @Gender)";
            int rowsAffected = await context.DbConnection.ExecuteAsync(query, user);
            if (rowsAffected == 0)
                return null;

            return user;
        }

        public async Task<ApplicationUser> GetUserByEmailAndPassword(string email, string password)
        {
            string query =
                "SELECT * FROM public.\"Users\" "
                + "WHERE \"Email\" = @Email AND \"Password\" = @Password";
            var user = await context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(
                query,
                new { Email = email, Password = password }
            );
            return user;
        }
    }
}
