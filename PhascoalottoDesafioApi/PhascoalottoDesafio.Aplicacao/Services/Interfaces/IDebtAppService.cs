using PhascoalottoDesafio.DTO;
using System;
using System.Collections.Generic;

namespace PhascoalottoDesafio.Aplicacao.Services.Interfaces
{
    public interface IDebtAppService : IDisposable
    {
        List<DebtDTO> GetAll();
    }
}
