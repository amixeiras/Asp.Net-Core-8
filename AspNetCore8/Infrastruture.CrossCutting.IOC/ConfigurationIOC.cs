using Application.DTO.DTO;
using Application.Interfaces;
using Application.Services;
using Autofac;
using Domain.Core.Interfaces.Repository;
using Domain.Core.Interfaces.Services;
using Domain.Models;
using Domain.Services.Services;
using Infrastruture.CrossCutting.Adapter.Interfaces;
using Infrastruture.CrossCutting.Adapter.Mapper;
using Infrastruture.Repository.Repositorys;

namespace Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<EnderecoAppService>().As<IEnderecoAppService>();
            #endregion

            #region IOC Services
            builder.RegisterType<EnderecoService>().As<IEnderecoService>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<EnderecoRepository>().As<IEnderecoRepository>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<EnderecoMapper>().As<IMapper<EnderecoModel, EnderecoDTO>>();
            #endregion

            #endregion
        }
    }
}
