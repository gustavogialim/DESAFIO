using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Mappers;

namespace PhascoalottoDesafio.Infraestrutura.Adapters
{
    public class AutomapperTypeAdapterFactory : Profile, ITypeAdapterFactory
    {
        public AutomapperTypeAdapterFactory()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = false;
                cfg.CreateMissingTypeMaps = true;
                cfg.AddMemberConfiguration().AddMember<NameSplitMember>().AddName<PrePostfixName>(_ => _.AddStrings(p => p.Postfixes, "DTO"));
                cfg.AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "DTO");
                cfg.AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "ListDTO");
            });

            Mapper.AssertConfigurationIsValid();
        }

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }
    }
}
