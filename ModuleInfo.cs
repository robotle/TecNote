/***************************************************************************
 * 
 *       功能：     系统模块信息(Role_ModuleInfo)实体类RoleModuleInfo
 *       作者：     邓波涛
 *       日期：     2010-9-20
 * 
 *       修改日期： 
 *       修改人：
 *       修改内容：
 * 
 * *************************************************************************/
namespace QtoneYWWZ.Model
{
	using System;
	using System.Data;
	using System.Collections;
	using QtoneYWWZ.ModelDAO;
	
	/// <summary>
	/// 系统模块信息(Role_ModuleInfo)实体类RoleModuleInfo 
	/// </summary>
	/// <value>系统模块信息(Role_ModuleInfo)实体类RoleModuleInfo</value>
	/// <remarks>系统模块信息(Role_ModuleInfo)实体类RoleModuleInfo</remarks>
	[Serializable]
	public class ModuleInfo
	{
		/// <summary>
		/// RoleModuleInfo的构造函数
		/// </summary>
		public  ModuleInfo()
		{
			//
            // 此处添加RoleModuleInfo的构造函数
			//	
		}

		private long _moduleinfoid;
		/// <summary>
		/// 模块标识ID
		/// </summary>
		/// <value>模块标识ID</value>
		/// <remarks>模块标识ID</remarks>
		public long ModuleInfoID
		{
			get{return _moduleinfoid;}
			set{_moduleinfoid = value;}
		}
		private string _moduleid;
		/// <summary>
		/// 模块ID
		/// </summary>
		/// <value>模块ID</value>
		/// <remarks>模块ID</remarks>
		public string ModuleID
		{
			get{return _moduleid;}
			set{_moduleid = value;}
		}
		private string _parentid;
		/// <summary>
		/// 父ID
		/// </summary>
		/// <value>父ID</value>
		/// <remarks>父ID</remarks>
		public string ParentID
		{
			get{return _parentid;}
			set{_parentid = value;}
		}
		private string _modulename;
		/// <summary>
		/// 模块名
		/// </summary>
		/// <value>模块名</value>
		/// <remarks>模块名</remarks>
		public string ModuleName
		{
			get{return _modulename;}
			set{_modulename = value;}
		}
		private string _modulefullname;
		/// <summary>
		/// 模块全名(->表示层级)
		/// </summary>
		/// <value>模块全名(->表示层级)</value>
		/// <remarks>模块全名(->表示层级)</remarks>
		public string ModuleFullName
		{
			get{return _modulefullname;}
			set{_modulefullname = value;}
		}
		private string _modulecode;
		/// <summary>
		/// 模块代码全称
		/// </summary>
		/// <value>模块代码全称</value>
		/// <remarks>模块代码全称</remarks>
		public string ModuleCode
		{
			get{return _modulecode;}
			set{_modulecode = value;}
		}
		private string _pageurl;
		/// <summary>
		/// 页面url
		/// </summary>
		/// <value>页面url</value>
		/// <remarks>页面url</remarks>
		public string PageUrl
		{
			get{return _pageurl;}
			set{_pageurl = value;}
		}
		private int _orderno;
		/// <summary>
		/// 排序
		/// </summary>
		/// <value>排序</value>
		/// <remarks>排序</remarks>
		public int OrderNo
		{
			get{return _orderno;}
			set{_orderno = value;}
		}
		private bool _ismenu;
		/// <summary>
		/// 是否菜项
		/// </summary>
		/// <value>是否菜项</value>
		/// <remarks>是否菜项</remarks>
		public bool IsMenu
		{
			get{return _ismenu;}
			set{_ismenu = value;}
		}
		private bool _ischeck;
		/// <summary>
		/// 是否检验权限
		/// </summary>
		/// <value>是否检验权限</value>
		/// <remarks>是否检验权限</remarks>
		public bool IsCheck
		{
			get{return _ischeck;}
			set{_ischeck = value;}
		}
		private bool _isenabled;
		/// <summary>
		/// 是否启用
		/// </summary>
		/// <value>是否启用</value>
		/// <remarks>是否启用</remarks>
		public bool IsEnabled
		{
			get{return _isenabled;}
			set{_isenabled = value;}
		}
		private bool _isexpand;
		/// <summary>
		/// 在菜单中是否展开
		/// </summary>
		/// <value>在菜单中是否展开</value>
		/// <remarks>在菜单中是否展开</remarks>
		public bool IsExpand
		{
			get{return _isexpand;}
			set{_isexpand = value;}
		}
		private int _modulelevel;
		/// <summary>
		/// 层级
		/// </summary>
		/// <value>层级</value>
		/// <remarks>层级</remarks>
		public int ModuleLevel
		{
			get{return _modulelevel;}
			set{_modulelevel = value;}
		}
		private bool _isnewwin;
		/// <summary>
		/// 是否打开新窗口
		/// </summary>
		/// <value>是否打开新窗口</value>
		/// <remarks>是否打开新窗口</remarks>
		public bool IsNewWin
		{
			get{return _isnewwin;}
			set{_isnewwin = value;}
		}
		private string _createuserid;
		/// <summary>
		/// 创建人用户ID
		/// </summary>
		/// <value>创建人用户ID</value>
		/// <remarks>创建人用户ID</remarks>
		public string CreateUserID
		{
			get{return _createuserid;}
			set{_createuserid = value;}
		}
		private DateTime _createtime;
		/// <summary>
		/// 创建时间
		/// </summary>
		/// <value>创建时间</value>
		/// <remarks>创建时间</remarks>
		public DateTime CreateTime
		{
			get{return _createtime;}
			set{_createtime = value;}
		}
		private string _modifyuserid;
		/// <summary>
		/// 修改人用户ID
		/// </summary>
		/// <value>修改人用户ID</value>
		/// <remarks>修改人用户ID</remarks>
		public string ModifyUserID
		{
			get{return _modifyuserid;}
			set{_modifyuserid = value;}
		}
		private DateTime _modifytime;
		/// <summary>
		/// 修改时间
		/// </summary>
		/// <value>修改时间</value>
		/// <remarks>修改时间</remarks>
		public DateTime ModifyTime
		{
			get{return _modifytime;}
			set{_modifytime = value;}
		}
        #region 创建人 修改人
        private SysUser _CreatedUserModel;
        public SysUser CreatedUserModel
        {
            get
            {
                if (_CreatedUserModel == null)
                {
                    _CreatedUserModel = MyDAOProxy.mySysUserDAO.SelectObjectByCache(CreateUserID);
                    if (_CreatedUserModel == null)
                        _CreatedUserModel = new SysUser();
                }
                return _CreatedUserModel;
            }
        }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreatedUserName
        {
            get
            {
                return CreatedUserModel == null ? "" : CreatedUserModel.UserName;
            }
        }

        private SysUser _ModifyUserModel;

        public SysUser ModifyUserModel
        {
            get
            {
                if (_ModifyUserModel == null)
                {
                    _ModifyUserModel = MyDAOProxy.mySysUserDAO.SelectObjectByCache(ModifyUserID);
                    if (_ModifyUserModel == null)
                        _ModifyUserModel = new SysUser();
             }
                return _ModifyUserModel;
            }

        }
        public string ModifyUserName
        {
            get
            {

                return ModifyUserModel == null ? "" : ModifyUserModel.UserName;
            }
        }
        public string IsMenuText
        {
            get 
            {
                return IsMenu ? "是" : "否";
            }
        }
        public string IsCheckText
        {
            get
            {
                return IsCheck ? "是" : "否";
            }
        }
        public string IsEnabledText
        {
            get
            {
                return IsEnabled ? "是" : "否";
            }
        
        }

        #endregion
	}
}
