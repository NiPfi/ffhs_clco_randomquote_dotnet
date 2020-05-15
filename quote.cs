using System.Text.RegularExpressions;

namespace ClCo.RandomQuote
{
    public struct Quote
    {
        public Quote(string quote)
        {
            var reg = new Regex("\".*?\"");
            this.Text = reg.Match(quote).ToString();
            this.Author = quote.Replace(this.Text, "").Trim();
        }

        public string Text { get; private set; }
        public string Author { get; private set; }

    }

}