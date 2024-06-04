using Biblioteka;
using Biblioteka.Models;
using Biblioteka.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B7.Pages
{
    [Authorize]
    public class PregledModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private BibliotekaServis _servis;
        public IEnumerable<KnjigaModel> listaKnjiga;

        public PregledModel(ILogger<IndexModel> logger, BibliotekaServis servis)
        {
            _logger = logger;
            _servis = servis;
        }

        public void OnGet()
        {
            _servis.AddElem();
            listaKnjiga = _servis.GetKnjige();

        }
    }
}
