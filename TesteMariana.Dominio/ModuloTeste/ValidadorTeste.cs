using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteMariana.Dominio.ModuloTeste
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty(); // metodo para nao deixar o campo Titulo vazio nem nulo

            RuleFor(x => x.NumeroQuestoes)
               .NotNull().NotEmpty(); // metodo para nao deixar o campo NumeroQuestoes vazio nem nulo

             

        }


    }
}
