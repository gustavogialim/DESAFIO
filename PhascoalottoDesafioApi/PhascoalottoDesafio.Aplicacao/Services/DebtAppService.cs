using PhascoalottoDesafio.Aplicacao.Base;
using PhascoalottoDesafio.Aplicacao.Services.Interfaces;
using PhascoalottoDesafio.Dominio.Aggregates.ConfigurationAgg;
using PhascoalottoDesafio.DTO;
using PhascoalottoDesafio.Infraestrutura.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhascoalottoDesafio.Aplicacao.Services
{
    public class DebtAppService : IDebtAppService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public DebtAppService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }


        public List<DebtDTO> GetAll()
        {
            try
            {
                var debts = _repositoryFactory.DebtRepository.GetAll().ToList();
                List<DebtDTO> debtsDTO = debts.ProjectedAsCollection<DebtDTO>();

                foreach (var debt in debtsDTO)
                {
                    var debtInstallment = _repositoryFactory.DebtInstallmentRepository.GetAll().Where(c => c.DebtId == debt.Id).ToList();
                    debt.Installments = debtInstallment.ProjectedAsCollection<DebtInstallmentDTO>();

                    CalculeInterest(debt);
                }

                return debtsDTO;
            }
            catch (Exception ex)
            {
                throw Throw.Exception(ex);
            }
        }

        private DebtDTO CalculeInterest(DebtDTO debt)
        {
            Configuration configuration = _repositoryFactory.ConfigurationRepository.GetAll().First();

            DateTime calculationDate = DateTime.Now;

            debt.LateDays = (calculationDate.Date - debt.DueDate.Date).Days + 1; // + 1 para incluir o dia de vencimento, de acordo com a lógica do desafio.
            debt.InterestValue = (debt.OriginalValue * configuration.InterestValue / 100) * debt.LateDays;
            debt.FinalValue = debt.OriginalValue + debt.InterestValue;
            debt.ComissionValue = debt.FinalValue * configuration.ComissionPercentage / 100;

            decimal valuePerInstallment = debt.FinalValue / debt.InstallmentsCount;

            foreach (var installment in debt.Installments)
            {
                installment.DueDate = installment.DueDate.AddDays(debt.LateDays);
                installment.FinalValue = valuePerInstallment;
            }

            return debt;
        }

        public void Dispose()
        {
            _repositoryFactory?.Dispose();
        }
    }
}
