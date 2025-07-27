using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductGrid.Models;

namespace ProductGrid.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<Produto> Produtos { get; set; }

    public void OnGet() { }

}


