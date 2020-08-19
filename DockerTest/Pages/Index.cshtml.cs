using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DockerTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<string> FilesInVolumeShare { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            FilesInVolumeShare = new List<string>();
        }

        public void OnGet()
        {

            FilesInVolumeShare = Directory.EnumerateFiles("/shared").ToList();
            _logger.LogInformation("Got {num} files", FilesInVolumeShare.Count);
        }
    }
}
