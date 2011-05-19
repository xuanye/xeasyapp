using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.JsonEntities
{
    public class JsonTreeNode
    {
        #region properties

        public string id { get; set; }

        public string text { get; set; }

        public string value { get; set; }

        public bool showcheck { get; set; }

        public bool isexpand { get; set; }

        public byte checkstate { get; set; }

        public bool hasChildren { get; set; }

        public bool complete { get; set; }

        public string classes { get; set; }

        public Dictionary<string, string> data { get; set; }

        private List<JsonTreeNode> _ChildNodes;
        public List<JsonTreeNode> ChildNodes
        {
            get
            {
                if (_ChildNodes == null)
                {
                    _ChildNodes = new List<JsonTreeNode>();
                }
                return _ChildNodes;
            }
        }

        #endregion
    }
}
