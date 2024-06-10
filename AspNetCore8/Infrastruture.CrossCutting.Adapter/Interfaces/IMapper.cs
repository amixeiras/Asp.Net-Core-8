namespace Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapper<Tin, Tout> where Tout : new()
    {
        Tin MapperToEntity(Tout? dto);

        IEnumerable<Tout> MapperToListDTO(IEnumerable<Tin> entitys);

        Tout MapperToDTO(Tin entity);
    }
}
