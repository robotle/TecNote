/***************************************************************************
 * 
 *       功能：     系统模块信息(Role_ModuleInfo)持久层类ModuleInfoDAO
 *       作者：     邓波涛
 *       日期：     2010-9-20
 * 
 *       修改日期： 
 *       修改人：
 *       修改内容：
 * 
 * *************************************************************************/

namespace QtoneYWWZ.ModelDAO
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Collections.Generic;
	using IBatisNet.Common;
	using IBatisNet.DataMapper;
	using IBatisNet.Common.Exceptions;
	using QtoneYWWZ.Model;

	/// <summary>
	/// 系统模块信息(Role_ModuleInfo)ModuleInfo的DAO操作类
	/// </summary>
	/// <value>系统模块信息(Role_ModuleInfo)ModuleInfo的DAO操作类</value>
	/// <remarks>系统模块信息(Role_ModuleInfo)ModuleInfo的DAO操作类</remarks>
	public class ModuleInfoDAO : MyBaseDao,IDAODelete
	{
		#region 不需要修改(模板生成)
		/// <summary>
		/// 系统模块信息(Role_ModuleInfo)ModuleInfoDAO的构造函数
		/// </summary>
		public ModuleInfoDAO()
		{
			//
			// 此处添加ModuleInfoDAO的构造函数
			//
		}

		/// <summary>
		/// 根据唯一属性得到系统模块信息(Role_ModuleInfo)ModuleInfo
		/// </summary>
		/// <remarks>根据唯一属性得到系统模块信息(Role_ModuleInfo)ModuleInfo</remarks>
		/// <param name="pID">主键id</param>
		/// <returns>系统模块信息(Role_ModuleInfo)ModuleInfo</returns>
        public ModuleInfo SelectObject(string pID)
        {
            return (ModuleInfo)MyMapper.QueryForObject("SelectObject_Role_ModuleInfo", pID);
        }

		/// <summary>
		/// 新增,返回值为系统模块信息(Role_ModuleInfo)ModuleInfo唯一属性的值
		/// </summary>
		/// <remarks>新增,返回值为系统模块信息(Role_ModuleInfo)ModuleInfo唯一属性的值</remarks>
		/// <param name="pModuleInfo">系统模块信息(Role_ModuleInfo)ModuleInfo</param>
		/// <returns>返回值为系统模块信息(Role_ModuleInfo)ModuleInfo唯一属性的值</returns>
        public long Add(ModuleInfo pModuleInfo)
        {
			long id =base.GetId("Role_ModuleInfo","ModuleInfoID");
            pModuleInfo.ModuleInfoID = id;
            ModuleInfo ModuleParent = this.SelectObject(pModuleInfo.ParentID);
            if (ModuleParent != null)
            {
                pModuleInfo.ModuleCode = ModuleParent.ModuleCode + "-" + pModuleInfo.ModuleID;
                pModuleInfo.ModuleFullName = ModuleParent.ModuleFullName + "→" + pModuleInfo.ModuleName;
                pModuleInfo.ModuleLevel = ModuleParent.ModuleLevel + 1;
              
            }
            else
            {
                pModuleInfo.ModuleCode = pModuleInfo.ModuleID;
                pModuleInfo.ModuleFullName = pModuleInfo.ModuleName;
                pModuleInfo.ModuleLevel = 1;
            }
            MyMapper.BeginTransaction(); 

            try
            {
                MyMapper.Insert("Insert_Role_ModuleInfo", pModuleInfo );
                if (ModuleParent != null)
                {
                    MyMapper.Update("Update_Role_ModuleInfo", ModuleParent);
                }
                MyMapper.CommitTransaction();


            }
            catch (Exception e)
            {

                MyMapper.RollBackTransaction();
                id = 0;
                throw e;
            }
            return id;
        }

		/// <summary>
		/// 修改系统模块信息(Role_ModuleInfo)ModuleInfo
		/// </summary>
		/// <remarks>修改系统模块信息(Role_ModuleInfo)ModuleInfo</remarks>
		/// <param name="pModuleInfo">系统模块信息(Role_ModuleInfo)ModuleInfo</param>
		/// <returns></returns>
        public void Update(ModuleInfo pModuleInfo)
        {
            string aCode = pModuleInfo.ModuleCode;
            int i = pModuleInfo.ModuleLevel;
            int MaxLoop = (int)MyMapper.QueryForObject("Select_Role_ModuleInfo.ModuleCode", aCode);
            Hashtable aHashtable = new Hashtable();
            aHashtable["ModuleCode"] = aCode;
            ModuleInfo ModuleParent = this.SelectObject(pModuleInfo .ParentID);
            if (ModuleParent != null)
            {
                pModuleInfo.ModuleCode = ModuleParent.ModuleCode + "-" + pModuleInfo.ModuleID;
                pModuleInfo.ModuleFullName = ModuleParent.ModuleFullName + "→" + pModuleInfo.ModuleName;
                pModuleInfo.ModuleLevel = ModuleParent.ModuleLevel + 1;
                
            }
            else
            {
                pModuleInfo.ModuleCode = pModuleInfo.ModuleID;
                pModuleInfo.ModuleFullName = pModuleInfo.ModuleName;
                pModuleInfo.ModuleLevel = 1;
                
            }
            MyMapper.BeginTransaction();
            try
            {
                MyMapper.Update("Update_Role_ModuleInfo", pModuleInfo);
                for (i = i + 1; i <= MaxLoop; i++)
                {
                    aHashtable["ModuleLevel"] = i;
                    MyMapper.Update("Update_Role_ModuleInfo_ModuleLevel", aHashtable);
                }
                MyMapper.CommitTransaction();
            }
            catch (Exception e)
            {
                MyMapper.RollBackTransaction();
                throw e;
            }
        }

		/// <summary>
		/// 删除系统模块信息(Role_ModuleInfo)ModuleInfo
		/// </summary>
		/// <remarks>删除系统模块信息(Role_ModuleInfo)ModuleInfo</remarks>
		/// <param name="pID">主键id</param>
		/// <returns></returns>
        public void Delete(long pID)
        {
            MyMapper.Delete("Delete_Role_ModuleInfo", pID);
        }

        /// <summary>
        /// 得到系统模块信息(Role_ModuleInfo)ModuleInfo的全部记录
        /// </summary>
		/// <returns>系统模块信息(Role_ModuleInfo)ModuleInfo全部记录的IList集合</returns>
        public override IList SelectAll()
        {
            return MyMapper.QueryForList("SelectAll_Role_ModuleInfo",null);
        }
		/// <summary>
		/// 得到系统模块信息(Role_ModuleInfo)ModuleInfo默认查询记录,返回前pMaxRecordReturn条记录
		/// </summary>
		/// <remarks>得到系统模块信息(Role_ModuleInfo)ModuleInfo默认查询记录,返回前pMaxRecordReturn条记录</remarks>
		/// <param name="pMaxRecordReturn">查询记录数</param>
		/// <returns>系统模块信息(Role_ModuleInfo)ModuleInfo默认查询记录的IList集合</returns>
        public override IList SelectDefault(int pMaxRecordReturn)
        {
            Hashtable aHashtable=new Hashtable();
            aHashtable.Add("top", pMaxRecordReturn);
            return MyMapper.QueryForList("SelectDefault_Role_ModuleInfo", aHashtable);  
        }
        /// <summary>
        /// 根据查询参数返回系统模块信息(Role_ModuleInfo)ModuleInfo的前pMaxRecordReturn条记录
        /// </summary>
		/// <remarks>根据查询参数返回系统模块信息(Role_ModuleInfo)ModuleInfo的前pMaxRecordReturn条记录</remarks>
		/// <param name="pMaxRecordReturn">查询记录数</param>
		/// <param name="pHashtable">查询参数的Hashtable集合</param>
		/// <returns>符合条件的IList集合</returns>
        public override IList SelectByParameter(string pMaxRecordReturn,Hashtable pHashtable)
        {
			pHashtable["top"] = pMaxRecordReturn;
			if (!pHashtable.ContainsKey("orderby"))
			{
                pHashtable["orderby"] = "Role_ModuleInfo.ModuleFullName asc ";
			}
			return MyMapper.QueryForList("SelectByParameter_Role_ModuleInfo", pHashtable);
		}
		#endregion
		#region 扩充代码	
	
        /// <summary>
        /// 获取模块的子模块信息
        /// </summary>
        /// <param name="pUserID">用户UserID</param>
        /// <param name="pModuleID">模块ID</param>
        /// <returns></returns>
        public IList<ModuleInfo> GetSubListByParams(string pUserID, string pModuleID)
        {
            Hashtable aHashtable = new Hashtable();
            aHashtable["IsEnabled"] = true;
            aHashtable["IsMenu"] = true;
            aHashtable["ParentID"] = pModuleID;
            aHashtable["UserID"] = pUserID;

            return MyMapper.QueryForList<ModuleInfo>("GetSubListByParams_Role_ModuleInfo", aHashtable);  
        }

	    #endregion
	}
}
