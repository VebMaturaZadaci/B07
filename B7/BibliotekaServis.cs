using Biblioteka.Models;
using System.Xml;

namespace Biblioteka
{
    public class BibliotekaServis
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public BibliotekaServis(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<KnjigaModel> GetKnjige()
        {
            List<KnjigaModel> knjige = new List<KnjigaModel>();
            XmlDocument doc = new XmlDocument();
            doc.Load(string.Concat(this.WebHostEnvironment.WebRootPath, "/biblioteka.xml"));

            foreach (XmlNode node in doc.SelectNodes("/biblioteka/knjiga"))
            {
                knjige.Add(new KnjigaModel
                {
                    //ovde postoji potencijal za exception ako nemate atribut ISBN 
                    ISBN = node.Attributes["ISBN"].Value,
                    Naslov = node["naslov"].InnerText,
                    Stanje = int.Parse(node["stanje"].InnerText),
                    Citano = int.Parse(node["citano"].InnerText)
                });
            }
            return knjige;
        }

        public void AddElem()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(string.Concat(this.WebHostEnvironment.WebRootPath, "/biblioteka.xml"));
            XmlElement elem = doc.CreateElement("knjiga");
            elem.SetAttribute("ISBN", "11-000000-008");
            XmlElement elNas = doc.CreateElement("naslov"); elNas.InnerText = "Zbrika C++";
            XmlElement elSta = doc.CreateElement("stanje"); elSta.InnerText = "10";
            XmlElement elCit = doc.CreateElement("citano"); elCit.InnerText = "6";
            elem.AppendChild(elNas);
            elem.AppendChild(elSta);
            elem.AppendChild(elCit);
            doc.DocumentElement.AppendChild(elem);
            doc.Save(string.Concat(this.WebHostEnvironment.WebRootPath, "/biblioteka.xml"));

        }


    }
}
