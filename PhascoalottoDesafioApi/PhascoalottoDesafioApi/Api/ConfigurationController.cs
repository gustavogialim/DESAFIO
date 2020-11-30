using Microsoft.AspNetCore.Mvc;
using PhascoalottoDesafio.Aplicacao.Base;
using PhascoalottoDesafio.DTO;

namespace PhascoalottoDesafioApi.Api
{
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        private readonly IServiceFactory _serviceFactory;

        public ConfigurationController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public ConfigurationDTO Get()
        {
            var configuration = _serviceFactory.ConfigurationAppService.GetConfiguration();
            return configuration;
        }
    }
}
