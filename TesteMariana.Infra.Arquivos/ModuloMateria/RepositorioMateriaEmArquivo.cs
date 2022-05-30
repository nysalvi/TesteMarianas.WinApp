using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Dominio.ModuloMateria;
using TesteMariana.Infra.Arquivos.Compartilhado;

namespace TesteMariana.Infra.Arquivos.ModuloMateria
{
    public class RepositorioMateriaEmArquivo : RepositorioEmArquivoBase<Materia>, IRepositorioMateria
    {
        public RepositorioMateriaEmArquivo(DataContext context) : base(context)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Id);
        }


        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();

        }
    }
}
