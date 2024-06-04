using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Biblioteka.Models;

namespace Biblioteka.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private BibliotekaServis _servis;
        public IEnumerable<KnjigaModel> listaKnjiga;

        public IndexModel(ILogger<IndexModel> logger, BibliotekaServis servis)
        {
            _logger = logger;
            _servis = servis;
        }

        public void OnGet()
        {
            listaKnjiga = _servis.GetKnjige();  

        }
    }
}