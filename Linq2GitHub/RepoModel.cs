using System;
using System.Collections.Generic;
using System.Text;

namespace Linq2GitHub
{
    class RepoModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime PushedDate { get; set; }
    }
}
