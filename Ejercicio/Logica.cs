using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio
{
    public class Logica
    {
      public bool ValidarCampos(string[] campos)
        {
           foreach (string campo in campos)
            {
                if (string.IsNullOrEmpty(campo))
                {
                    return false;
                };
            } 
            return true;
        }
        
    }

}
