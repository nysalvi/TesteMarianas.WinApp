using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.Compartilhado;
using TesteMariana.Dominio.ModuloMateria;

namespace TesteMariana.Dominio.ModuloDisciplina
{
    public class Disciplina: EntidadeBase<Disciplina>
    {
        public List<Materia> materias { get; set; }

        public string Nome { get; set; }

        public override void Atualizar(Disciplina registro)
        {
        }

        public override string ToString()
        {
            return $"{Nome}";
        }


    }

}
