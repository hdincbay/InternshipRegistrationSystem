using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IRepositoryManager
    {
        public IRegistrationFormRepository RegistrationFormRepository { get; }
        public void Save();
    }
}
