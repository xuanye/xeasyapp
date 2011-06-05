using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xEasyApp.Core.Repositories
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.IsNew = true;
   
        }

        public void ClearChangedList()
        {
            _ChangedPropertyChangedList = new List<string>();
        }
        private List<string> _ChangedPropertyChangedList = new List<string>();
        protected void OnPropertyChanged(string propertyName)
        {
            if (!_ChangedPropertyChangedList.Contains(propertyName))
            {
                _ChangedPropertyChangedList.Add(propertyName);
            }
        }
        public int ChangedPropertyCount
        {
            get {
                return _ChangedPropertyChangedList.Count;
            }
        }
        public bool IsChanged(string propertyName)
        {
            return _ChangedPropertyChangedList.Contains(propertyName);
        }
        public List<string> ChangedPropertyList
        {
            get {
                return _ChangedPropertyChangedList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNew
        {
            get;
            set;
        }
    }
    public class TestEntity : BaseEntity
    {
        
    }
}
