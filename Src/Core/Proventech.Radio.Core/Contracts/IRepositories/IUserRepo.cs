using Proventech.Radio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proventech.Radio.Core.Contracts.IRepositories
{
    public interface IUserRepo
    {
        List<UserModel> GetUser();
    }
}
