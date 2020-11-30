using PhascoalottoDesafio.DTO;
using System;

namespace PhascoalottoDesafio.Aplicacao.Services.Interfaces
{
    public interface IConfigurationAppService : IDisposable
    {
        ConfigurationDTO GetConfiguration();
    }
}
