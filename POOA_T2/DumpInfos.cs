using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOA_T2
{
    class DumpInfos
    {

        public async Task<List<string>> dumpAsync(String site, String tag, String classe)
        {
            List<string> l = new List<string>();

            var config = Configuration.Default.WithDefaultLoader(); //Configuração padrão do AngleSharp
            var address = site;
            var document = await BrowsingContext.New(config).OpenAsync(address); //Pega o código do site/endereço

            //LINQ 
            var blueListItemsLinq = document.All.Where(m => m.LocalName == tag && m.GetAttribute("class") == classe);
            foreach (var item in blueListItemsLinq)
            {                
                l.Add("Principal;" + item.Text() + ";" + item.GetAttribute("href") + ";"); //Cria no formato Principal;Titulo;Link e adiciona na lista de strings que será retornada
            }            

            return l;
        }

    }
}

//LINQ equivalent CSS selector
//var blueListItemsCSS = document.QuerySelectorAll("a[class='feed-post-link gui-color-primary gui-color-hover']");