using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOA_T2
{
    class TreatmentStrings
    {

        public String createString(List<string> linha)
        {
            String completo = "Tipo;Titulo;Link\n";     

            foreach (string l in linha)
            {
                completo += l + "\n";
            }

            return completo;
        }

    }
  
}