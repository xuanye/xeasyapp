using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Entities
{
    public class PagedList<T> where T:class
    {
        
        public List<T> DataList
        {
            get;
            set;
        }
        public int PageSize
        { 
            get; 
            set; 
        }
        public int PageIndex
        {
            get;
            set;
        }
        public int Total
        { get; set; }
    }
}
