using Entities.Models;
using Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IRegistrationFormRepository
    {
        public IQueryable<RegistrationForm> GetAllRegistrationForm(bool trackChanges);
        public RegistrationForm? GetByRegistrationForm(int id, bool trackChanges);
        public void CreateRegistrationForm(RegistrationForm registrationForm);
        public void UpdateRegistrationForm(RegistrationForm registrationForm);
        public void DeleteRegistrationForm(RegistrationForm registrationForm);

    }
}
