using PhascoalottoDesafio.Infraestrutura.Transversal.Exceptions;
using System;

namespace PhascoalottoDesafio.Aplicacao.Base
{
    public static class Throw
    {
        internal static Exception Exception(Exception ex)
        {
            if (ex is AppException appException)
            {
                throw appException;
            }

            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}
