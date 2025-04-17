using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Seguridad
    {

        public static bool sessionActiva(object user)
        {
            Usuario logeado = user != null ? (Usuario)user : null;
            if (logeado != null && logeado.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object user)
        {
            Usuario logeado = user != null ? (Usuario)user : null;
            return logeado != null ? logeado.Admin : false;
        }

    }
}
