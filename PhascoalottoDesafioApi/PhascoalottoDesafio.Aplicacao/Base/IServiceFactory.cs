using PhascoalottoDesafio.Aplicacao.Services.Interfaces;
using System;

namespace PhascoalottoDesafio.Aplicacao.Base
{
    public interface IServiceFactory : IDisposable
    {
        IConfigurationAppService ConfigurationAppService { get; }
        IDebtAppService DebtAppService { get; }
    }
}
