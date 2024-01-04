using Proventech.Radio.Core.Contracts.IRepositories;
using Proventech.Radio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proventech.Radio.Infrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly Context _context;


        public UserRepo(Context context)
        {
            _context = context;
        }
        public List<UserModel> GetUser()
        {
            return _context.User.ToList();
        }
    }
}
