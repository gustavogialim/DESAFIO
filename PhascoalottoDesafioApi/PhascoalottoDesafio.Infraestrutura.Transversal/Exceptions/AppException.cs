using System;

namespace PhascoalottoDesafio.Infraestrutura.Transversal.Exceptions
{
    public class AppException : Exception
    {
        // Here we could have many ways to handle the exception
        public AppException(string mensagem) : base(mensagem) { }
    }
}
