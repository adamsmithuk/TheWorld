using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class FileUploadViewModel
    {

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        [Required]
        [FileExtensions(Extensions = "jpg,jpeg")]
        public IFormFile File { get; set; }

    }
}
