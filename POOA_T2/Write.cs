using System;
using System.IO;

namespace POOA_T2
{
    class Write : iWrite
    {
        public void inFile(String dir, String ger)
        {
            File.WriteAllText(dir, ger, System.Text.Encoding.UTF8); //Cria efetivamente o arquivo com os dados
            File.SetAttributes(dir, FileAttributes.ReadOnly); //Altera o atributo do arquivo para "somente leitura"
        }
    }
}
