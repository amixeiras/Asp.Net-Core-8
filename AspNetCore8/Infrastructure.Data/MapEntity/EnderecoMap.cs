using Domain.Models;
using FluentNHibernate.Mapping;

namespace Infrastructure.Data.MapEntity
{
    public class EnderecoMap : ClassMap<EnderecoModel>
    {
        public EnderecoMap() 
        {
            Id(e => e.cod);
            Map(e => e.cep);
            Map(e => e.numero);
            Map(e => e.descricao);
            Map(e => e.complemento);
            Map(e => e.data_inclusao);
            Table("movie.endereco");
        }
    }
}
