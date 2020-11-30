using Microsoft.AspNetCore.Mvc;
using PhascoalottoDesafio.Aplicacao.Base;
using PhascoalottoDesafio.DTO;
using System.Collections.Generic;

namespace PhascoalottoDesafioApi.Api
{
    [Route("api/[controller]")]
    public class DebtController : Controller
    {
        private readonly IServiceFactory _serviceFactory;

        public DebtController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public List<DebtDTO> GetAll()
        {
            var debts = _serviceFactory.DebtAppService.GetAll();
            return debts;
        }
    }
}
