﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HC.User.DB.Entitys
{
    ///<summary>
    ///角色权限映射表 
    ///</summary>
    [SugarTable("rolemenu")]
    public partial class rolemenu
    {
           public rolemenu(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:外键-角色
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FK_Role {get;set;}

           /// <summary>
           /// Desc:外键-权限
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FK_Menu {get;set;}

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
