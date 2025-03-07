using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VintageGameLibrary.Data;
using VintageGameLibrary.Models;

namespace VintageGameLibrary.Components.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly VintageGameLibrary.Data.LibraryContext _context;

        public IndexModel(VintageGameLibrary.Data.LibraryContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Game = await _context.Games.ToListAsync();
        }
    }
}
