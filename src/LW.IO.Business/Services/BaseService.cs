using FluentValidation;
using FluentValidation.Results;
using LW.IO.Business.Interfaces;
using LW.IO.Business.Models;
using LW.IO.Business.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LW.IO.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }
        
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));

        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
