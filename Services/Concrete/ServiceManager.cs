using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRegistrationFormService _registrationFormService;

        public ServiceManager(IRegistrationFormService registrationFormService)
        {
            _registrationFormService = registrationFormService;
        }

        public IRegistrationFormService RegistrationFormService => _registrationFormService;
    }
}
