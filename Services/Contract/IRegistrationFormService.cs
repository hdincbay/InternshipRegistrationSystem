using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IRegistrationFormService
    {
        public IEnumerable<RegistrationForm> GetAll(bool trackChanges);
        public RegistrationForm? GetOne(int id, bool trackChanges);
        public void CreateOne(RegistrationForm registrationForm);
        public void UpdateOne(RegistrationForm registrationForm);
        public void DeleteOne(int id);
    }
}
