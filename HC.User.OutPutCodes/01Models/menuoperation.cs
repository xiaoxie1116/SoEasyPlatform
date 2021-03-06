﻿using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HC.User.DB.Entitys
{
    ///<summary>
    ///菜单模块与按钮操作关系表 
    ///</summary>
    [SugarTable("menuoperation")]
    public partial class menuoperation
    {
           public menuoperation(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:菜单外键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FK_menu {get;set;}

           /// <summary>
           /// Desc:按钮外键
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FK_Operation {get;set;}

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
