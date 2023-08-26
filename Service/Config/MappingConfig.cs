using AutoMapper;

namespace WebApp.Service.Config;
class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration( config => {
            // config.CreateMap<EnderecoVO, EnderecoModel>();
            // config.CreateMap<EnderecoModel, EnderecoVO>();
        });
        return mappingConfig;
    }
}