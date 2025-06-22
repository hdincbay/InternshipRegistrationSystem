using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IRegistrationFormRepository _registrationFormRepository;
        private readonly RepositoryContext _context;

        public RepositoryManager(IRegistrationFormRepository registrationFormRepository, RepositoryContext context)
        {
            _registrationFormRepository = registrationFormRepository;
            _context = context;
        }

        public IRegistrationFormRepository RegistrationFormRepository => _registrationFormRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
