namespace MeuLivroDeReceitas.Domain.Entities
{
    public class EntidadeBase
    {
        public long Id { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}
