using Entities.Models;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class RegistrationFormService : IRegistrationFormService
    {
        private readonly IRepositoryManager _manager;

        public RegistrationFormService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateOne(RegistrationForm registrationForm)
        {
            _manager.RegistrationFormRepository.CreateRegistrationForm(registrationForm);
            _manager.Save();
        }

        public void DeleteOne(int id)
        {
            var model = _manager.RegistrationFormRepository.GetByRegistrationForm(id, true);
            if(model is not null)
            {
                _manager.RegistrationFormRepository.DeleteRegistrationForm(model);
                _manager.Save();
            }
        }

        public IEnumerable<RegistrationForm> GetAll(bool trackChanges)
        {
            return _manager.RegistrationFormRepository.GetAllRegistrationForm(trackChanges);
        }

        public RegistrationForm? GetOne(int id, bool trackChanges)
        {
            return _manager.RegistrationFormRepository.GetByRegistrationForm(id, trackChanges);
        }

        public void UpdateOne(RegistrationForm registrationForm)
        {
            var model = _manager.RegistrationFormRepository.GetByRegistrationForm(registrationForm.RegistrationFormId, true);
            if (model is not null)
            {
                _manager.RegistrationFormRepository.UpdateRegistrationForm(model);
                _manager.Save();
            }
        }
    }
}
