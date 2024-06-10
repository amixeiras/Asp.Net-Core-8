using Domain.Core.Interfaces.Repository;
using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastruture.Repository.Repositorys
{
    public class EnderecoRepository : RepositoryBase<EnderecoModel>, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration _configuration) : base(_configuration)
        {
        }
       
    }
}
