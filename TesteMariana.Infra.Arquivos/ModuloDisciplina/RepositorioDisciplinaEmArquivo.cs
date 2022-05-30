using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.ModuloDisciplina;
using TesteMariana.Infra.Arquivos.Compartilhado;

namespace TesteMariana.Infra.Arquivos.ModuloDisciplina
{
    public class RepositorioDisciplinaEmArquivo : RepositorioEmArquivoBase<Disciplina>, IRepositorioDisciplina
    {
        public RepositorioDisciplinaEmArquivo(DataContext context) : base(context)
        {
            if (dataContext.Disciplinas.Count > 0)
                contador = dataContext.Disciplinas.Max(x => x.Id);
        }


        public override List<Disciplina> ObterRegistros()
        {
            return dataContext.Disciplinas;
        }

        public override AbstractValidator<Disciplina> ObterValidador()
        {
            return new ValidadorDisciplina();
        }
    }
}
