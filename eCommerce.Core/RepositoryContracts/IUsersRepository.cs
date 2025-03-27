using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUsersRepository
    {
        public Task<ApplicationUser> AddUser(ApplicationUser user);
        public Task<ApplicationUser> GetUserByEmailAndPassword(string email, string password);
    }
}
