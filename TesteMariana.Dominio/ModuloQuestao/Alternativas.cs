
using TesteMariana.Dominio.Compartilhado;

namespace TesteMariana.Dominio.ModuloQuestao
{
    public  class Alternativas : EntidadeBase<Alternativas>
    {
        public char letra { get; set; }
        public bool Correta { get; set; }
        public string Resposta { get; set; }

        public override void Atualizar(Alternativas registro)
        {
        }

        public override string ToString()
        {
            return Resposta;
        }
    }
}
