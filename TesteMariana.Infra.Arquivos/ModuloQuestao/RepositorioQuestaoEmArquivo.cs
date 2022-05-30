using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteMariana.Dominio.ModuloQuestao;
using TesteMariana.Infra.Arquivos.Compartilhado;

namespace TesteMariana.Infra.Arquivos.ModuloQuestao
{
    public class RepositorioQuestaoEmArquivo : RepositorioEmArquivoBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestaoEmArquivo(DataContext context) : base(context)
        {
            if (dataContext.Questoes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Id);
        }


        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();

        }

    }
}
