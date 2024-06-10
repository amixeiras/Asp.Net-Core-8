using Application.DTO.DTO;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Domain.Models;
using Infrastruture.CrossCutting.Adapter.Interfaces;

namespace Application.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoService enderecoService;
        private readonly IMapper<EnderecoModel, EnderecoDTO> mapper;

        public EnderecoAppService(IEnderecoService _enderecoService, IMapper<EnderecoModel, EnderecoDTO> _mapper)
        {
            enderecoService = _enderecoService;
            mapper = _mapper;
        }
        public void Add(EnderecoDTO obj)
        {
            var dados = mapper.MapperToEntity(obj);
            enderecoService.Add(dados);
        }

        public void Dispose()
        {
            enderecoService?.Dispose();
        }

        public IEnumerable<EnderecoDTO> GetAll()
        {
            var dados = enderecoService.GetAll();

            return mapper.MapperToListDTO(dados);
        }

        public EnderecoDTO GetById(int id)
        {
            var dados = enderecoService.GetById(id);
            return mapper.MapperToDTO(dados);
        }

        public void Remove(EnderecoDTO obj)
        {
            var dados = mapper.MapperToEntity(obj);
            enderecoService.Remove(dados);
        }

        public void Update(EnderecoDTO obj)
        {
            var dados = mapper.MapperToEntity(obj);
            enderecoService.Update(dados);
        }
    }
}
