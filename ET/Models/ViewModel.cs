using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ET.Models
{
    public class ViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Cinema> Cinemas { get; set; }
    }
}