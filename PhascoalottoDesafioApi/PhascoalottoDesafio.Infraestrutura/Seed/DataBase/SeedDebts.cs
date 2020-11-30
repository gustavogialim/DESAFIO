using PhascoalottoDesafio.Dominio.Aggregates.DebtAgg;
using PhascoalottoDesafio.Dominio.Aggregates.DebtInstallmentAgg;
using PhascoalottoDesafio.Infraestrutura.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhascoalottoDesafio.Infraestrutura.Seed.DataBase
{
    public static class SeedDebtsExtension
    {
        public static void SeedDebts(this IRepositoryFactory repositoryFactory)
        {
            if (!repositoryFactory.DebtRepository.GetAll().Any())
            {
                #region Debt 1

                Debt debt = new Debt();
                debt.DueDate = new DateTime(2020, 11, 20);
                debt.InstallmentsCount = 3;
                debt.OriginalValue = 3000;
                debt.OrientationPhone = "(14) 99720-8435";

                repositoryFactory.DebtRepository.Add(debt);
                repositoryFactory.DebtRepository.Commit();

                List<DebtInstallment> debtInstallments = new List<DebtInstallment>();

                for (var i = 0; i < debt.InstallmentsCount; i++)
                {
                    DebtInstallment debtInstallment = new DebtInstallment();
                    debtInstallment.DebtId = debt.Id;
                    debtInstallment.DueDate = debt.DueDate.AddMonths(i);
                    debtInstallment.FinalValue = debt.OriginalValue / debt.InstallmentsCount;

                    debtInstallments.Add(debtInstallment);
                }

                repositoryFactory.DebtInstallmentRepository.AddRange(debtInstallments);
                repositoryFactory.DebtInstallmentRepository.Commit();

                #endregion

                #region Debt 2

                Debt debt2 = new Debt();
                debt2.DueDate = new DateTime(2020, 11, 10);
                debt2.InstallmentsCount = 4;
                debt2.OriginalValue = 1000;
                debt2.OrientationPhone = "(14) 99720-8435";

                repositoryFactory.DebtRepository.Add(debt2);
                repositoryFactory.DebtRepository.Commit();

                List<DebtInstallment> debtInstallments2 = new List<DebtInstallment>();

                for (var i = 0; i < debt2.InstallmentsCount; i++)
                {
                    DebtInstallment debtInstallment2 = new DebtInstallment();
                    debtInstallment2.DebtId = debt2.Id;
                    debtInstallment2.DueDate = debt2.DueDate.AddMonths(i);
                    debtInstallment2.FinalValue = debt2.OriginalValue / debt2.InstallmentsCount;

                    debtInstallments2.Add(debtInstallment2);
                }

                repositoryFactory.DebtInstallmentRepository.AddRange(debtInstallments2);
                repositoryFactory.DebtInstallmentRepository.Commit();

                #endregion

                #region Debt 3

                Debt debt3 = new Debt();
                debt3.DueDate = new DateTime(2020, 10, 01);
                debt3.InstallmentsCount = 6;
                debt3.OriginalValue = 12000;
                debt3.OrientationPhone = "(14) 99720-8435";

                repositoryFactory.DebtRepository.Add(debt3);
                repositoryFactory.DebtRepository.Commit();

                List<DebtInstallment> debtInstallments3 = new List<DebtInstallment>();

                for (var i = 0; i < debt3.InstallmentsCount; i++)
                {
                    DebtInstallment debtInstallment3 = new DebtInstallment();
                    debtInstallment3.DebtId = debt3.Id;
                    debtInstallment3.DueDate = debt3.DueDate.AddMonths(i);
                    debtInstallment3.FinalValue = debt3.OriginalValue / debt3.InstallmentsCount;

                    debtInstallments3.Add(debtInstallment3);
                }

                repositoryFactory.DebtInstallmentRepository.AddRange(debtInstallments3);
                repositoryFactory.DebtInstallmentRepository.Commit();

                #endregion
            }
        }
    }
}
