using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Entities
{
    public class PageView
    {
        public PageView()
        { 
        
        }
        public PageView(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public int PageIndex
        { get; set; }

        public int PageSize
        { get; set; }
    }
}
