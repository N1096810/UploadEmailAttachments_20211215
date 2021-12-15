using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class EmailVM
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        [EmailAddress]
        public string To { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public HttpPostedFileBase ToAttachFile { get; set; }
    }
}