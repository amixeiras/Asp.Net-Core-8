using Domain.Core.Interfaces.Repository;
using Domain.Core.Interfaces.Services;
using Domain.Models;

namespace Domain.Services.Services
{
    public class EnderecoService : ServiceBase<EnderecoModel>, IEnderecoService
    {
        public EnderecoService(IEnderecoRepository repository) : base(repository) { }
    }
}
