using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
    }
}
