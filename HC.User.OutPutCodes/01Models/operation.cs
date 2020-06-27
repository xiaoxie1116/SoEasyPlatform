using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HC.User.DB.Entitys
{
    ///<summary>
    ///按钮操作表 
    ///</summary>
    [SugarTable("operation")]
    public partial class operation
    {
           public operation(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:按钮名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BtnName {get;set;}

           /// <summary>
           /// Desc:按钮图标
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Icon {get;set;}

           /// <summary>
           /// Desc:按钮提示
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BtnTitle {get;set;}

           /// <summary>
           /// Desc:按钮排序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BtnSort {get;set;}

           /// <summary>
           /// Desc:是否可用
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string IsVaild {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CreateUser {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateDate {get;set;}

           /// <summary>
           /// Desc:更新人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ModifyUser {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ModifyDate {get;set;}

    }
}
