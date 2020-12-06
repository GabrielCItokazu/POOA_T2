using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace POOA_T2
{
    public partial class Form1 : Form
    {

        //Instanciando as classes
        DumpInfos dumpInfos = new DumpInfos(); //Classe que pega o conteúdo da tag com o titulo da noticia
        TreatmentStrings treatmentStrings = new TreatmentStrings(); //Classe que junta o conteúdo gerado pela classe anterior
        Diretorio diretorio = new Diretorio(); //Classe que retorna o caminho de onde vai ter o arquivo gerado (retorna somente o diretório, não cria o arquivo)

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
                executa(s, "", "Gerado" + i, "csv"); //objeto do tipo site, diretório, nome_arquivo, formato_arquivo
                i++;
            }
            /*Site site = new Site("https://g1.globo.com/", "a", "feed-post-link gui-color-primary gui-color-hover");
            MessageBox.Show(site.getUrl(), "Teste");
            MessageBox.Show(site.getTag(), "Teste1");
            MessageBox.Show(site.getClasse(), "Teste2");
            executa(site, @"C:\Users\Gabriel\Desktop\", "Gerado", "csv");*/
        }

        private async System.Threading.Tasks.Task executa(Site site, String caminho = "", String nomeArq = "", String extensao = "")
        {
            string dir = diretorio.geraDiretorio(caminho, nomeArq, extensao);
            List<string> linha_completa = await dumpInfos.dumpAsync(site.getUrl(), site.getTag(), site.getClasse());
            String ger = treatmentStrings.createString(linha_completa); //Junta em uma string só todas as linhas criadas na dumpInfos

            File.WriteAllText(dir, ger, System.Text.Encoding.UTF8); //Cria efetivamente o arquivo com os dados
            File.SetAttributes(dir, FileAttributes.ReadOnly); //Altera o atributo do arquivo para "somente leitura"

            MessageBox.Show("Finalizado!", "Aviso");
        }
    }
}