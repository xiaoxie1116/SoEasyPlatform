using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace HC.User.DB.Entitys
{
    ///<summary>
    ///公司表 
    ///</summary>
    [SugarTable("company")]
    public partial class company
    {
           public company(){


           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:公司名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CompanyName {get;set;}

           /// <summary>
           /// Desc:公司地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Address {get;set;}

           /// <summary>
           /// Desc:品牌名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BrandName {get;set;}

           /// <summary>
           /// Desc:营业执照
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BusinessLicense {get;set;}

           /// <summary>
           /// Desc:处理（审核）状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AuditStatus {get;set;}

           /// <summary>
           /// Desc:ERP源公司ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CompanySourceID {get;set;}

           /// <summary>
           /// Desc:ERP源部门ID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DepartmentSourceID {get;set;}

           /// <summary>
           /// Desc:是否在erp维护
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IsExistErp {get;set;}

           /// <summary>
           /// Desc:是否维护过合同
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IsExistContract {get;set;}

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
           public DateTime? CreateTime {get;set;}

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
           public DateTime? ModifyTime {get;set;}

    }
}
