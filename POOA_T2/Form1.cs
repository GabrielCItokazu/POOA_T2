using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace POOA_T2
{
    public partial class Form1 : Form
    {

        //Instanciando as classes
        DumpInfos dumpInfos = new DumpInfos(); //Classe que pega o conteúdo da tag com o titulo da noticia
        TreatmentStrings treatmentStrings = new TreatmentStrings(); //Classe que junta o conteúdo gerado pela classe anterior
        Diretorio diretorio = new Diretorio(); //Classe que retorna o caminho de onde vai ter o arquivo gerado (retorna somente o diretório, não cria o arquivo)
        Write write = new Write(); //Classe responsável por colocar os dados em algum lugar (arquivo, textbox, etc)

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            List<Site> sites = new List<Site>();
            sites.Add(new Site("https://g1.globo.com/", "a", "feed-post-link gui-color-primary gui-color-hover"));            
            sites.Add(new Site("https://techtudo.com.br", "a", "feed-post-link gui-color-primary gui-color-hover"));   
            
            //Execução
            int i = 1;
            foreach (Site s in sites)
            {
                executa(s, "", "Gerado" + i, "csv"); //Parâmetros: Objeto do tipo Site, diretório, nome_arquivo, formato_arquivo
                i++;
            }
        }

        private async System.Threading.Tasks.Task executa(Site site, String caminho = "", String nomeArq = "", String extensao = "")
        {
            string dir = diretorio.geraDiretorio(caminho, nomeArq, extensao); //Gera o caminho completo, incluindo o nome do arquivo, mas não cria o arquivo
            List<string> l = await dumpInfos.dumpAsync(site.getUrl(), site.getTag(), site.getClasse());
            String ger = treatmentStrings.createString(l); //Junta em uma string só todas as linhas criadas na dumpInfos

            write.inFile(dir, ger); //Cria o arquivo com o texto

            MessageBox.Show("Finalizado!", "Aviso");
        }
    }
}