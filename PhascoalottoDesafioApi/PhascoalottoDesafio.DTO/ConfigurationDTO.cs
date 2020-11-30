using PhascoalottoDesafio.Enum;

namespace PhascoalottoDesafio.DTO
{
    public class ConfigurationDTO
    {
        public int MaxInstallments { get; set; }

        public EnumInterestType InterestType { get; set; }

        public decimal InterestValue { get; set; }

        public decimal ComissionPercentage { get; set; }
    }
}
