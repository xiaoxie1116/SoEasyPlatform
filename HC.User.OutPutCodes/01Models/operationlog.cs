using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HC.User.DB.Entitys
{
    ///<summary>
    ///操作日志表 
    ///</summary>
    [SugarTable("operationlog")]
    public partial class operationlog
    {
           public operationlog(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:操作类型（枚举）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OperationType {get;set;}

           /// <summary>
           /// Desc:外键-操作人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FK_User {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

           /// <summary>
           /// Desc:操作IP
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ClientIP {get;set;}

           /// <summary>
           /// Desc:操作时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OperationTime {get;set;}

    }
}
