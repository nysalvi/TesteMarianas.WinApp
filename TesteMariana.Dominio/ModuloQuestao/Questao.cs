using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.Compartilhado;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;

namespace TesteMariana.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public List<Alternativas> alternativas;
        public Disciplina disciplina { get; set; }
        public Materia materia { get; set; }
        public string Nome { get; set; }

        public Questao()
        {
            alternativas = new List<Alternativas>();
        }
        public override void Atualizar(Questao registro)
        {
        }

    }
}
