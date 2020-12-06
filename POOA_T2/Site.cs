namespace POOA_T2
{
    class Site //Classe model
    {

        private string url, tag, classe;

        public Site(string url, string tag, string classe)
        {
            this.url = url;
            this.tag = tag;
            this.classe = classe;
        }

        public string getUrl()
        {
            return this.url;
        }

        public string getTag()
        {
            return this.tag;
        }

        public string getClasse()
        {
            return this.classe;
        }

    }
}
