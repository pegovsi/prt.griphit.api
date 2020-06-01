using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Prt.Graphit.Application.Map.Queries.Models
{
    public class FileContainer
    {
        public Stream Data { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
