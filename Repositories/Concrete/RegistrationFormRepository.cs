using Entities.Models;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete
{
    public class RegistrationFormRepository : RepositoryBase<RegistrationForm>, IRegistrationFormRepository
    {
        public RegistrationFormRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateRegistrationForm(RegistrationForm registrationForm) => Create(registrationForm);

        public void DeleteRegistrationForm(RegistrationForm registrationForm) => Delete(registrationForm);

        public IQueryable<RegistrationForm> GetAllRegistrationForm(bool trackChanges) => FindAll(trackChanges);

        public RegistrationForm? GetByRegistrationForm(int id, bool trackChanges) => FindByCondition(r => r.RegistrationFormId.Equals(id), trackChanges);

        public void UpdateRegistrationForm(RegistrationForm registrationForm) => Update(registrationForm);
    }
}
