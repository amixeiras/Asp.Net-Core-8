namespace Domain.Models
{
    public class EnderecoModel : BaseModel
    {
        public virtual string? descricao { get; set; }
        public virtual string? cep { get; set; }
        public virtual string? numero { get; set; }
        public virtual string? complemento { get; set; }
    }
}
