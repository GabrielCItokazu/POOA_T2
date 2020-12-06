using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOA_T2
{
    class Diretorio
    {
        
        public String geraDiretorio(String dir = "", String nomeArquivo = "", String tipo = "")
        {
            String ret; //String de retorno

            if (dir.Equals("")) //Se o usuário não passar o diretório, o programa usará o Desktop por padrão
                ret = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            else
                ret = dir;            

            if(nomeArquivo.Equals("")) //Se o usuário não passar o nome do arquivo, será salvo como "NomeGenerico"
                ret += @"\NomeGenerico" + "." + tipo;
            else 
                ret += @"\" + nomeArquivo + "." + tipo;

            verificaDiretorio(ret); //Verifica se o arquivo já existe, caso exista, o programa o deletará

            return ret;
        }

        public void verificaDiretorio(String dir)
        {
            if (File.Exists(dir))
            {
                try
                {
                    File.SetAttributes(dir, FileAttributes.Normal); //Altera os atributos do arquivo
                    File.Delete(dir); //Deleta o arquivo
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao deletar arquivo anterior.\nTente executar o programa como Administrador.", "Erro");
                }
            }
        }

    }
}
