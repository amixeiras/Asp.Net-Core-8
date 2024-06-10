using Application.DTO.DTO;
using Domain.Models;
using Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.CrossCutting.Adapter.Mapper
{
    public class EnderecoMapper : IMapper<EnderecoModel, EnderecoDTO>
    {
        public EnderecoDTO MapperToDTO(EnderecoModel entity)
        {
            EnderecoDTO endereco = new EnderecoDTO();
            endereco.Codigo = entity.cod;
            endereco.Numero = entity.numero;
            endereco.Descricao = entity.descricao;
            endereco.Cep = entity.cep;
            endereco.Complemento = entity.complemento;
            endereco.DataInclusao = entity.data_inclusao;

            return endereco;
        }

        public EnderecoModel MapperToEntity(EnderecoDTO? dto)
        {
            EnderecoModel endereco = new EnderecoModel();
            endereco.cod = dto.Codigo;
            endereco.descricao = dto.Descricao;
            endereco.numero = dto.Numero;
            endereco.cep = dto.Cep;
            endereco.complemento = dto.Complemento;
            endereco.data_inclusao = dto.DataInclusao;

            return endereco;
        }

        public IEnumerable<EnderecoDTO> MapperToListDTO(IEnumerable<EnderecoModel> entitys)
        {
            List<EnderecoDTO> enderecos = new List<EnderecoDTO>();
            foreach (var item in entitys)
            {
                enderecos.Add(MapperToDTO(item));
            }

            return enderecos;
        }
    }
}
