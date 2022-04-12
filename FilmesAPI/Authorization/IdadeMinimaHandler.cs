using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmesApi.Authorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement> // Bindind com o Requirement
    {
        // Implementando método abstrato HandleRequirementAsync da classe AuthorizationHandler
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            // usuario não tem a Claim DateOfBirth 
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
                return Task.CompletedTask; // finaliza a tarefa sem autorizar

            // Pega do usuario do contexto do Token com a Claim de DateOfBirth e converte para DateTime
            DateTime dataNascimento = Convert.ToDateTime(context.User.FindFirst(c =>
                c.Type == ClaimTypes.DateOfBirth)
                .Value);

            int idadeObtida = DateTime.Today.Year - dataNascimento.Year;

            // usuario não fez aniversário no ano ainda
            // data de nascimento é maior que hoje menos idade obtida acima, subtrai um ano
            if (dataNascimento > DateTime.Today.AddYears(-idadeObtida))
                idadeObtida--;

            // tem idade minima, sucesso
            if (idadeObtida >= requirement.IdadeMinima) 
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
