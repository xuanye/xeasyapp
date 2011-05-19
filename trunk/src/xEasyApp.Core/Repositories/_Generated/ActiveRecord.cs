


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace xEasyApp.Core.Repositories
{
    
    
    /// <summary>
    /// A class which represents the ShortCut table in the xEasyApp Database.
    /// </summary>
    public partial class ShortCut: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<ShortCut> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<ShortCut>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<ShortCut> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(ShortCut item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                ShortCut item=new ShortCut();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<ShortCut> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public ShortCut(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                ShortCut.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ShortCut>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public ShortCut(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public ShortCut(Expression<Func<ShortCut, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<ShortCut> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<ShortCut> _repo;
            
            if(db.TestMode){
                ShortCut.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<ShortCut>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<ShortCut> GetRepo(){
            return GetRepo("","");
        }
        
        public static ShortCut SingleOrDefault(Expression<Func<ShortCut, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            ShortCut single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static ShortCut SingleOrDefault(Expression<Func<ShortCut, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            ShortCut single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<ShortCut, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<ShortCut, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<ShortCut> Find(Expression<Func<ShortCut, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<ShortCut> Find(Expression<Func<ShortCut, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<ShortCut> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<ShortCut> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<ShortCut> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<ShortCut> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<ShortCut> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<ShortCut> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ShortCutID";
        }

        public object KeyValue()
        {
            return this.ShortCutID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ShortCutName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(ShortCut)){
                ShortCut compare=(ShortCut)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ShortCutID;
        }
        
        public string DescriptorValue()
        {
            return this.ShortCutName.ToString();
        }

        public string DescriptorColumn() {
            return "ShortCutName";
        }
        public static string GetKeyColumn()
        {
            return "ShortCutID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ShortCutName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ShortCutID;
        public int ShortCutID
        {
            get { return _ShortCutID; }
            set
            {
                if(_ShortCutID!=value){
                    _ShortCutID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortCutID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShortCutName;
        public string ShortCutName
        {
            get { return _ShortCutName; }
            set
            {
                if(_ShortCutName!=value){
                    _ShortCutName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShortCutName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if(_Remark!=value){
                    _Remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PrivilegeCode;
        public string PrivilegeCode
        {
            get { return _PrivilegeCode; }
            set
            {
                if(_PrivilegeCode!=value){
                    _PrivilegeCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrivilegeCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UserUID;
        public string UserUID
        {
            get { return _UserUID; }
            set
            {
                if(_UserUID!=value){
                    _UserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _LastModifyTime;
        public DateTime? LastModifyTime
        {
            get { return _LastModifyTime; }
            set
            {
                if(_LastModifyTime!=value){
                    _LastModifyTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastModifyTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Sequence;
        public int? Sequence
        {
            get { return _Sequence; }
            set
            {
                if(_Sequence!=value){
                    _Sequence=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sequence");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<ShortCut, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the DictInfos table in the xEasyApp Database.
    /// </summary>
    public partial class DictInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<DictInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<DictInfo>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<DictInfo> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(DictInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                DictInfo item=new DictInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<DictInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public DictInfo(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                DictInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DictInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public DictInfo(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public DictInfo(Expression<Func<DictInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<DictInfo> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<DictInfo> _repo;
            
            if(db.TestMode){
                DictInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<DictInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<DictInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static DictInfo SingleOrDefault(Expression<Func<DictInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            DictInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static DictInfo SingleOrDefault(Expression<Func<DictInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            DictInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<DictInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<DictInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<DictInfo> Find(Expression<Func<DictInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<DictInfo> Find(Expression<Func<DictInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<DictInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<DictInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<DictInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<DictInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<DictInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<DictInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "DictID";
        }

        public object KeyValue()
        {
            return this.DictID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.DictName.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(DictInfo)){
                DictInfo compare=(DictInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.DictID;
        }
        
        public string DescriptorValue()
        {
            return this.DictName.ToString();
        }

        public string DescriptorColumn() {
            return "DictName";
        }
        public static string GetKeyColumn()
        {
            return "DictID";
        }        
        public static string GetDescriptorColumn()
        {
            return "DictName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _DictID;
        public int DictID
        {
            get { return _DictID; }
            set
            {
                if(_DictID!=value){
                    _DictID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DictID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DictName;
        public string DictName
        {
            get { return _DictName; }
            set
            {
                if(_DictName!=value){
                    _DictName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DictName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DictCode;
        public string DictCode
        {
            get { return _DictCode; }
            set
            {
                if(_DictCode!=value){
                    _DictCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DictCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _DictType;
        public bool DictType
        {
            get { return _DictType; }
            set
            {
                if(_DictType!=value){
                    _DictType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DictType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ParentID;
        public int? ParentID
        {
            get { return _ParentID; }
            set
            {
                if(_ParentID!=value){
                    _ParentID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParentID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Sequence;
        public int? Sequence
        {
            get { return _Sequence; }
            set
            {
                if(_Sequence!=value){
                    _Sequence=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sequence");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SQLCMD;
        public string SQLCMD
        {
            get { return _SQLCMD; }
            set
            {
                if(_SQLCMD!=value){
                    _SQLCMD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SQLCMD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if(_Remark!=value){
                    _Remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<DictInfo, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Departments table in the xEasyApp Database.
    /// </summary>
    public partial class Department: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Department> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Department>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Department> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Department item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Department item=new Department();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Department> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public Department(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Department.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Department>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Department(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Department(Expression<Func<Department, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Department> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<Department> _repo;
            
            if(db.TestMode){
                Department.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Department>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Department> GetRepo(){
            return GetRepo("","");
        }
        
        public static Department SingleOrDefault(Expression<Func<Department, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Department single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Department SingleOrDefault(Expression<Func<Department, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Department single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Department, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Department, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Department> Find(Expression<Func<Department, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Department> Find(Expression<Func<Department, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Department> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Department> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Department> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Department> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Department> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Department> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "DeptID";
        }

        public object KeyValue()
        {
            return this.DeptID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.DeptCode.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Department)){
                Department compare=(Department)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.DeptID;
        }
        
        public string DescriptorValue()
        {
            return this.DeptCode.ToString();
        }

        public string DescriptorColumn() {
            return "DeptCode";
        }
        public static string GetKeyColumn()
        {
            return "DeptID";
        }        
        public static string GetDescriptorColumn()
        {
            return "DeptCode";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Department> Departments
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.Department.GetRepo();
                  return from items in repo.GetAll()
                       where items.DeptID == _ParentID
                       select items;
            }
        }

        public IQueryable<UserInfo> UserInfos
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.UserInfo.GetRepo();
                  return from items in repo.GetAll()
                       where items.DeptID == _DeptID
                       select items;
            }
        }

        #endregion
        

        int _DeptID;
        public int DeptID
        {
            get { return _DeptID; }
            set
            {
                if(_DeptID!=value){
                    _DeptID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeptID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DeptCode;
        public string DeptCode
        {
            get { return _DeptCode; }
            set
            {
                if(_DeptCode!=value){
                    _DeptCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeptCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DeptName;
        public string DeptName
        {
            get { return _DeptName; }
            set
            {
                if(_DeptName!=value){
                    _DeptName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeptName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ParentID;
        public int? ParentID
        {
            get { return _ParentID; }
            set
            {
                if(_ParentID!=value){
                    _ParentID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParentID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Path;
        public string Path
        {
            get { return _Path; }
            set
            {
                if(_Path!=value){
                    _Path=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Path");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Manager;
        public string Manager
        {
            get { return _Manager; }
            set
            {
                if(_Manager!=value){
                    _Manager=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Manager");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if(_Remark!=value){
                    _Remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Sequence;
        public int Sequence
        {
            get { return _Sequence; }
            set
            {
                if(_Sequence!=value){
                    _Sequence=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sequence");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserUID;
        public string LastUpdateUserUID
        {
            get { return _LastUpdateUserUID; }
            set
            {
                if(_LastUpdateUserUID!=value){
                    _LastUpdateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserName;
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set
            {
                if(_LastUpdateUserName!=value){
                    _LastUpdateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if(_LastUpdateTime!=value){
                    _LastUpdateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Department, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Privileges table in the xEasyApp Database.
    /// </summary>
    public partial class Privilege: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Privilege> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Privilege>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Privilege> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Privilege item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Privilege item=new Privilege();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Privilege> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public Privilege(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Privilege.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Privilege>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Privilege(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Privilege(Expression<Func<Privilege, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Privilege> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<Privilege> _repo;
            
            if(db.TestMode){
                Privilege.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Privilege>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Privilege> GetRepo(){
            return GetRepo("","");
        }
        
        public static Privilege SingleOrDefault(Expression<Func<Privilege, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Privilege single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Privilege SingleOrDefault(Expression<Func<Privilege, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Privilege single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Privilege, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Privilege, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Privilege> Find(Expression<Func<Privilege, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Privilege> Find(Expression<Func<Privilege, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Privilege> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Privilege> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Privilege> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Privilege> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Privilege> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Privilege> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PrivilegeCode";
        }

        public object KeyValue()
        {
            return this.PrivilegeCode;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.PrivilegeCode.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Privilege)){
                Privilege compare=(Privilege)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.PrivilegeCode.ToString();
        }

        public string DescriptorColumn() {
            return "PrivilegeCode";
        }
        public static string GetKeyColumn()
        {
            return "PrivilegeCode";
        }        
        public static string GetDescriptorColumn()
        {
            return "PrivilegeCode";
        }
        
        #region ' Foreign Keys '
        public IQueryable<RolePrivilegeRelation> RolePrivilegeRelations
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.RolePrivilegeRelation.GetRepo();
                  return from items in repo.GetAll()
                       where items.PrivilegeCode == _PrivilegeCode
                       select items;
            }
        }

        #endregion
        

        string _PrivilegeCode;
        public string PrivilegeCode
        {
            get { return _PrivilegeCode; }
            set
            {
                if(_PrivilegeCode!=value){
                    _PrivilegeCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrivilegeCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PrivilegeName;
        public string PrivilegeName
        {
            get { return _PrivilegeName; }
            set
            {
                if(_PrivilegeName!=value){
                    _PrivilegeName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrivilegeName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _PrivilegeType;
        public bool PrivilegeType
        {
            get { return _PrivilegeType; }
            set
            {
                if(_PrivilegeType!=value){
                    _PrivilegeType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrivilegeType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ParentID;
        public string ParentID
        {
            get { return _ParentID; }
            set
            {
                if(_ParentID!=value){
                    _ParentID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParentID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Uri;
        public string Uri
        {
            get { return _Uri; }
            set
            {
                if(_Uri!=value){
                    _Uri=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Uri");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Sequence;
        public int? Sequence
        {
            get { return _Sequence; }
            set
            {
                if(_Sequence!=value){
                    _Sequence=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sequence");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserUID;
        public string LastUpdateUserUID
        {
            get { return _LastUpdateUserUID; }
            set
            {
                if(_LastUpdateUserUID!=value){
                    _LastUpdateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserName;
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set
            {
                if(_LastUpdateUserName!=value){
                    _LastUpdateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if(_LastUpdateTime!=value){
                    _LastUpdateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Privilege, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Logs table in the xEasyApp Database.
    /// </summary>
    public partial class Log: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Log> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Log>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Log> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Log item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Log item=new Log();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Log> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public Log(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Log.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Log>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Log(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Log(Expression<Func<Log, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Log> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<Log> _repo;
            
            if(db.TestMode){
                Log.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Log>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Log> GetRepo(){
            return GetRepo("","");
        }
        
        public static Log SingleOrDefault(Expression<Func<Log, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Log single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Log SingleOrDefault(Expression<Func<Log, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Log single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Log, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Log, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Log> Find(Expression<Func<Log, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Log> Find(Expression<Func<Log, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Log> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Log> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Log> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Log> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Log> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Log> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.Topic.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Log)){
                Log compare=(Log)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
            return this.Topic.ToString();
        }

        public string DescriptorColumn() {
            return "Topic";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Topic";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Topic;
        public string Topic
        {
            get { return _Topic; }
            set
            {
                if(_Topic!=value){
                    _Topic=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Topic");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Content;
        public string Content
        {
            get { return _Content; }
            set
            {
                if(_Content!=value){
                    _Content=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Content");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OperateCode;
        public string OperateCode
        {
            get { return _OperateCode; }
            set
            {
                if(_OperateCode!=value){
                    _OperateCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OperateCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _LogType;
        public bool LogType
        {
            get { return _LogType; }
            set
            {
                if(_LogType!=value){
                    _LogType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LogType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OperateUID;
        public string OperateUID
        {
            get { return _OperateUID; }
            set
            {
                if(_OperateUID!=value){
                    _OperateUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OperateUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OperateName;
        public string OperateName
        {
            get { return _OperateName; }
            set
            {
                if(_OperateName!=value){
                    _OperateName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OperateName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IPAddress;
        public string IPAddress
        {
            get { return _IPAddress; }
            set
            {
                if(_IPAddress!=value){
                    _IPAddress=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IPAddress");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _OperateTime;
        public DateTime OperateTime
        {
            get { return _OperateTime; }
            set
            {
                if(_OperateTime!=value){
                    _OperateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OperateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Log, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the RolePrivilegeRelation table in the xEasyApp Database.
    /// </summary>
    public partial class RolePrivilegeRelation: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<RolePrivilegeRelation> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<RolePrivilegeRelation>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<RolePrivilegeRelation> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(RolePrivilegeRelation item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                RolePrivilegeRelation item=new RolePrivilegeRelation();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<RolePrivilegeRelation> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public RolePrivilegeRelation(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                RolePrivilegeRelation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RolePrivilegeRelation>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public RolePrivilegeRelation(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public RolePrivilegeRelation(Expression<Func<RolePrivilegeRelation, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<RolePrivilegeRelation> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<RolePrivilegeRelation> _repo;
            
            if(db.TestMode){
                RolePrivilegeRelation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RolePrivilegeRelation>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<RolePrivilegeRelation> GetRepo(){
            return GetRepo("","");
        }
        
        public static RolePrivilegeRelation SingleOrDefault(Expression<Func<RolePrivilegeRelation, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            RolePrivilegeRelation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static RolePrivilegeRelation SingleOrDefault(Expression<Func<RolePrivilegeRelation, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            RolePrivilegeRelation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<RolePrivilegeRelation, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<RolePrivilegeRelation, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<RolePrivilegeRelation> Find(Expression<Func<RolePrivilegeRelation, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<RolePrivilegeRelation> Find(Expression<Func<RolePrivilegeRelation, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<RolePrivilegeRelation> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<RolePrivilegeRelation> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<RolePrivilegeRelation> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<RolePrivilegeRelation> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<RolePrivilegeRelation> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<RolePrivilegeRelation> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PrivilegeCode";
        }

        public object KeyValue()
        {
            return this.PrivilegeCode;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.RoleCode.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(RolePrivilegeRelation)){
                RolePrivilegeRelation compare=(RolePrivilegeRelation)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.RoleCode.ToString();
        }

        public string DescriptorColumn() {
            return "RoleCode";
        }
        public static string GetKeyColumn()
        {
            return "PrivilegeCode";
        }        
        public static string GetDescriptorColumn()
        {
            return "RoleCode";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Privilege> Privileges
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.Privilege.GetRepo();
                  return from items in repo.GetAll()
                       where items.PrivilegeCode == _PrivilegeCode
                       select items;
            }
        }

        public IQueryable<RoleInfo> RoleInfos
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.RoleInfo.GetRepo();
                  return from items in repo.GetAll()
                       where items.RoleCode == _RoleCode
                       select items;
            }
        }

        #endregion
        

        string _RoleCode;
        public string RoleCode
        {
            get { return _RoleCode; }
            set
            {
                if(_RoleCode!=value){
                    _RoleCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoleCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PrivilegeCode;
        public string PrivilegeCode
        {
            get { return _PrivilegeCode; }
            set
            {
                if(_PrivilegeCode!=value){
                    _PrivilegeCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PrivilegeCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserUID;
        public string LastUpdateUserUID
        {
            get { return _LastUpdateUserUID; }
            set
            {
                if(_LastUpdateUserUID!=value){
                    _LastUpdateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserName;
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set
            {
                if(_LastUpdateUserName!=value){
                    _LastUpdateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if(_LastUpdateTime!=value){
                    _LastUpdateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<RolePrivilegeRelation, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the UserInfos table in the xEasyApp Database.
    /// </summary>
    public partial class UserInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<UserInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<UserInfo>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<UserInfo> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(UserInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                UserInfo item=new UserInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<UserInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public UserInfo(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                UserInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public UserInfo(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public UserInfo(Expression<Func<UserInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<UserInfo> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<UserInfo> _repo;
            
            if(db.TestMode){
                UserInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<UserInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<UserInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static UserInfo SingleOrDefault(Expression<Func<UserInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            UserInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static UserInfo SingleOrDefault(Expression<Func<UserInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            UserInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<UserInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<UserInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<UserInfo> Find(Expression<Func<UserInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<UserInfo> Find(Expression<Func<UserInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<UserInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<UserInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<UserInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<UserInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<UserInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<UserInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "UserUID";
        }

        public object KeyValue()
        {
            return this.UserUID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.UserUID.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(UserInfo)){
                UserInfo compare=(UserInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.UserUID.ToString();
        }

        public string DescriptorColumn() {
            return "UserUID";
        }
        public static string GetKeyColumn()
        {
            return "UserUID";
        }        
        public static string GetDescriptorColumn()
        {
            return "UserUID";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Department> Departments
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.Department.GetRepo();
                  return from items in repo.GetAll()
                       where items.DeptID == _DeptID
                       select items;
            }
        }

        public IQueryable<RoleUserRelation> RoleUserRelations
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.RoleUserRelation.GetRepo();
                  return from items in repo.GetAll()
                       where items.UserUID == _UserUID
                       select items;
            }
        }

        #endregion
        

        string _UserUID;
        public string UserUID
        {
            get { return _UserUID; }
            set
            {
                if(_UserUID!=value){
                    _UserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set
            {
                if(_FullName!=value){
                    _FullName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FullName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UsedName;
        public string UsedName
        {
            get { return _UsedName; }
            set
            {
                if(_UsedName!=value){
                    _UsedName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UsedName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if(_Password!=value){
                    _Password=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Password");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UserNO;
        public string UserNO
        {
            get { return _UserNO; }
            set
            {
                if(_UserNO!=value){
                    _UserNO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserNO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _UserType;
        public bool UserType
        {
            get { return _UserType; }
            set
            {
                if(_UserType!=value){
                    _UserType=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserType");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _DeptID;
        public int DeptID
        {
            get { return _DeptID; }
            set
            {
                if(_DeptID!=value){
                    _DeptID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeptID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _Gender;
        public bool Gender
        {
            get { return _Gender; }
            set
            {
                if(_Gender!=value){
                    _Gender=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Gender");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Birthplace;
        public string Birthplace
        {
            get { return _Birthplace; }
            set
            {
                if(_Birthplace!=value){
                    _Birthplace=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Birthplace");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _National;
        public string National
        {
            get { return _National; }
            set
            {
                if(_National!=value){
                    _National=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="National");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IDCard;
        public string IDCard
        {
            get { return _IDCard; }
            set
            {
                if(_IDCard!=value){
                    _IDCard=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IDCard");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _Birthday;
        public DateTime? Birthday
        {
            get { return _Birthday; }
            set
            {
                if(_Birthday!=value){
                    _Birthday=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Birthday");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if(_Email!=value){
                    _Email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EmailBacker;
        public string EmailBacker
        {
            get { return _EmailBacker; }
            set
            {
                if(_EmailBacker!=value){
                    _EmailBacker=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmailBacker");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OfficePhone;
        public string OfficePhone
        {
            get { return _OfficePhone; }
            set
            {
                if(_OfficePhone!=value){
                    _OfficePhone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OfficePhone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _HomePhone;
        public string HomePhone
        {
            get { return _HomePhone; }
            set
            {
                if(_HomePhone!=value){
                    _HomePhone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HomePhone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MobilePhone;
        public string MobilePhone
        {
            get { return _MobilePhone; }
            set
            {
                if(_MobilePhone!=value){
                    _MobilePhone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MobilePhone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _QQ;
        public string QQ
        {
            get { return _QQ; }
            set
            {
                if(_QQ!=value){
                    _QQ=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QQ");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MSN;
        public string MSN
        {
            get { return _MSN; }
            set
            {
                if(_MSN!=value){
                    _MSN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MSN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _Sequence;
        public int Sequence
        {
            get { return _Sequence; }
            set
            {
                if(_Sequence!=value){
                    _Sequence=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Sequence");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CreateUserUID;
        public string CreateUserUID
        {
            get { return _CreateUserUID; }
            set
            {
                if(_CreateUserUID!=value){
                    _CreateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CreateUserName;
        public string CreateUserName
        {
            get { return _CreateUserName; }
            set
            {
                if(_CreateUserName!=value){
                    _CreateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _CreateTime;
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set
            {
                if(_CreateTime!=value){
                    _CreateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserUID;
        public string LastUpdateUserUID
        {
            get { return _LastUpdateUserUID; }
            set
            {
                if(_LastUpdateUserUID!=value){
                    _LastUpdateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserName;
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set
            {
                if(_LastUpdateUserName!=value){
                    _LastUpdateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if(_LastUpdateTime!=value){
                    _LastUpdateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _AccountState;
        public bool AccountState
        {
            get { return _AccountState; }
            set
            {
                if(_AccountState!=value){
                    _AccountState=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AccountState");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<UserInfo, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the RoleUserRelation table in the xEasyApp Database.
    /// </summary>
    public partial class RoleUserRelation: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<RoleUserRelation> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<RoleUserRelation>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<RoleUserRelation> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(RoleUserRelation item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                RoleUserRelation item=new RoleUserRelation();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<RoleUserRelation> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public RoleUserRelation(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                RoleUserRelation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RoleUserRelation>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public RoleUserRelation(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public RoleUserRelation(Expression<Func<RoleUserRelation, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<RoleUserRelation> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<RoleUserRelation> _repo;
            
            if(db.TestMode){
                RoleUserRelation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RoleUserRelation>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<RoleUserRelation> GetRepo(){
            return GetRepo("","");
        }
        
        public static RoleUserRelation SingleOrDefault(Expression<Func<RoleUserRelation, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            RoleUserRelation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static RoleUserRelation SingleOrDefault(Expression<Func<RoleUserRelation, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            RoleUserRelation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<RoleUserRelation, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<RoleUserRelation, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<RoleUserRelation> Find(Expression<Func<RoleUserRelation, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<RoleUserRelation> Find(Expression<Func<RoleUserRelation, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<RoleUserRelation> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<RoleUserRelation> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<RoleUserRelation> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<RoleUserRelation> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<RoleUserRelation> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<RoleUserRelation> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "RoleCode";
        }

        public object KeyValue()
        {
            return this.RoleCode;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.RoleCode.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(RoleUserRelation)){
                RoleUserRelation compare=(RoleUserRelation)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.RoleCode.ToString();
        }

        public string DescriptorColumn() {
            return "RoleCode";
        }
        public static string GetKeyColumn()
        {
            return "RoleCode";
        }        
        public static string GetDescriptorColumn()
        {
            return "RoleCode";
        }
        
        #region ' Foreign Keys '
        public IQueryable<RoleInfo> RoleInfos
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.RoleInfo.GetRepo();
                  return from items in repo.GetAll()
                       where items.RoleCode == _RoleCode
                       select items;
            }
        }

        public IQueryable<UserInfo> UserInfos
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.UserInfo.GetRepo();
                  return from items in repo.GetAll()
                       where items.UserUID == _UserUID
                       select items;
            }
        }

        #endregion
        

        string _RoleCode;
        public string RoleCode
        {
            get { return _RoleCode; }
            set
            {
                if(_RoleCode!=value){
                    _RoleCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoleCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _UserUID;
        public string UserUID
        {
            get { return _UserUID; }
            set
            {
                if(_UserUID!=value){
                    _UserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserUID;
        public string LastUpdateUserUID
        {
            get { return _LastUpdateUserUID; }
            set
            {
                if(_LastUpdateUserUID!=value){
                    _LastUpdateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserName;
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set
            {
                if(_LastUpdateUserName!=value){
                    _LastUpdateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if(_LastUpdateTime!=value){
                    _LastUpdateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<RoleUserRelation, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the RoleInfos table in the xEasyApp Database.
    /// </summary>
    public partial class RoleInfo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<RoleInfo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<RoleInfo>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<RoleInfo> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(RoleInfo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                RoleInfo item=new RoleInfo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<RoleInfo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public RoleInfo(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                RoleInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RoleInfo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public RoleInfo(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public RoleInfo(Expression<Func<RoleInfo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<RoleInfo> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<RoleInfo> _repo;
            
            if(db.TestMode){
                RoleInfo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RoleInfo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<RoleInfo> GetRepo(){
            return GetRepo("","");
        }
        
        public static RoleInfo SingleOrDefault(Expression<Func<RoleInfo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            RoleInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static RoleInfo SingleOrDefault(Expression<Func<RoleInfo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            RoleInfo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<RoleInfo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<RoleInfo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<RoleInfo> Find(Expression<Func<RoleInfo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<RoleInfo> Find(Expression<Func<RoleInfo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<RoleInfo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<RoleInfo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<RoleInfo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<RoleInfo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<RoleInfo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<RoleInfo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "RoleCode";
        }

        public object KeyValue()
        {
            return this.RoleCode;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.RoleCode.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(RoleInfo)){
                RoleInfo compare=(RoleInfo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.RoleCode.ToString();
        }

        public string DescriptorColumn() {
            return "RoleCode";
        }
        public static string GetKeyColumn()
        {
            return "RoleCode";
        }        
        public static string GetDescriptorColumn()
        {
            return "RoleCode";
        }
        
        #region ' Foreign Keys '
        public IQueryable<RolePrivilegeRelation> RolePrivilegeRelations
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.RolePrivilegeRelation.GetRepo();
                  return from items in repo.GetAll()
                       where items.RoleCode == _RoleCode
                       select items;
            }
        }

        public IQueryable<RoleUserRelation> RoleUserRelations
        {
            get
            {
                
                  var repo=xEasyApp.Core.Repositories.RoleUserRelation.GetRepo();
                  return from items in repo.GetAll()
                       where items.RoleCode == _RoleCode
                       select items;
            }
        }

        #endregion
        

        string _RoleCode;
        public string RoleCode
        {
            get { return _RoleCode; }
            set
            {
                if(_RoleCode!=value){
                    _RoleCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoleCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RoleName;
        public string RoleName
        {
            get { return _RoleName; }
            set
            {
                if(_RoleName!=value){
                    _RoleName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoleName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserUID;
        public string LastUpdateUserUID
        {
            get { return _LastUpdateUserUID; }
            set
            {
                if(_LastUpdateUserUID!=value){
                    _LastUpdateUserUID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserUID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastUpdateUserName;
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set
            {
                if(_LastUpdateUserName!=value){
                    _LastUpdateUserName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateUserName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if(_LastUpdateTime!=value){
                    _LastUpdateTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastUpdateTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _IsSystem;
        public bool? IsSystem
        {
            get { return _IsSystem; }
            set
            {
                if(_IsSystem!=value){
                    _IsSystem=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsSystem");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<RoleInfo, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the SysParams table in the xEasyApp Database.
    /// </summary>
    public partial class SysParam: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<SysParam> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<SysParam>(new xEasyApp.Core.Repositories.xEasyAppDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<SysParam> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(SysParam item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                SysParam item=new SysParam();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<SysParam> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        xEasyApp.Core.Repositories.xEasyAppDB _db;
        public SysParam(string connectionString, string providerName) {

            _db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                SysParam.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SysParam>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public SysParam(){
             _db=new xEasyApp.Core.Repositories.xEasyAppDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public SysParam(Expression<Func<SysParam, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<SysParam> GetRepo(string connectionString, string providerName){
            xEasyApp.Core.Repositories.xEasyAppDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new xEasyApp.Core.Repositories.xEasyAppDB();
            }else{
                db=new xEasyApp.Core.Repositories.xEasyAppDB(connectionString, providerName);
            }
            IRepository<SysParam> _repo;
            
            if(db.TestMode){
                SysParam.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<SysParam>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<SysParam> GetRepo(){
            return GetRepo("","");
        }
        
        public static SysParam SingleOrDefault(Expression<Func<SysParam, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            SysParam single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static SysParam SingleOrDefault(Expression<Func<SysParam, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            SysParam single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<SysParam, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<SysParam, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<SysParam> Find(Expression<Func<SysParam, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<SysParam> Find(Expression<Func<SysParam, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<SysParam> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<SysParam> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<SysParam> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<SysParam> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<SysParam> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<SysParam> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ParamCode";
        }

        public object KeyValue()
        {
            return this.ParamCode;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
            return this.ParamCode.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(SysParam)){
                SysParam compare=(SysParam)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
            return this.ParamCode.ToString();
        }

        public string DescriptorColumn() {
            return "ParamCode";
        }
        public static string GetKeyColumn()
        {
            return "ParamCode";
        }        
        public static string GetDescriptorColumn()
        {
            return "ParamCode";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _ParamCode;
        public string ParamCode
        {
            get { return _ParamCode; }
            set
            {
                if(_ParamCode!=value){
                    _ParamCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParamCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ParamName;
        public string ParamName
        {
            get { return _ParamName; }
            set
            {
                if(_ParamName!=value){
                    _ParamName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParamName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ParamValue;
        public string ParamValue
        {
            get { return _ParamValue; }
            set
            {
                if(_ParamValue!=value){
                    _ParamValue=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ParamValue");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Remark;
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if(_Remark!=value){
                    _Remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<SysParam, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
