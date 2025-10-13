using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Band_it.Modules;

namespace Band_it.Services
{

    //class APISymbolResponse
    //{

    //    public bool success { get; set; }
    //    public Dictionary<string, string> metadata { get; set; }
    //    public List<Dictionary<string, object>> data { get; set; }



        

       
    //}
    public class APISymbolResponse
    {
        public bool success { get; set; }
        public Metadata metadata { get; set; }
        public Exercise[] data { get; set; }
    }

    public class Metadata
    {
        public int totalPages { get; set; }
        public int totalExercises { get; set; }
        public int currentPage { get; set; }
        public string previousPage { get; set; }
        public string nextPage { get; set; }
    }

}

