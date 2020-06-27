using SugarCodeGeneration.Codes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SugarCodeGeneration
{


    /// <summary>
    /// F5直接运行生成项目
    /// </summary>
    /// <param name="args"></param>
    class Program
    {

        /***3个必填参数***/

        //如果你不需要自定义，直接配好数据库连接，F5运行项目
        const SqlSugar.DbType dbType = SqlSugar.DbType.MySql;
        /// <summary>
        /// 连接字符串
        /// </summary>
        const string connectionString = "Data Source=127.0.0.1;Database=userdb;User ID=root;Password=123456;pooling=true;port=3306;";
        /// <summary>
        ///解决方案名称
        /// </summary>
        const string SolutionName = "HC.User";//如果修改解决方案名称，F5执行完成后会自动关闭项目，找到目录重新打开项目解决方案便可

        /***3个必填参数***/

        //需要创建的表,不填默认全部,最好是手填参数，能区分大小写
        static List<string> NeedCreateTables = new List<string>()
        {
            "Company",
            "User",
            "Role",
            "UserRole",
            "Menus",
            "RoleMenu",
            "OperationLog",
            "Operation",
            "MenuOperation"
        };


        /// <summary>
        /// 执行生成
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /***连接数据库***/
            var db = GetDB();

            /***生成实体***/ //CodeFirst可以注释生成实体

            //配置参数
            //配置参数

            string classProjectName = SolutionName + ".OutPutCodes";//实体类项目名称
            string classPath = "01Models";//生成的目录
            //数据库实体命名空间
            string classNamespace = SolutionName + ".DB.Entitys";
            var classDirectory = Methods.GetSlnPath + "\\" + classProjectName + "\\" + classPath.TrimStart('\\');
            //执行生成
            GenerationClass(classProjectName, classPath, classNamespace, classDirectory);
            Print("实体创建成功");

            List<string> tables = new List<string>();

            if (NeedCreateTables.Any())
                tables = NeedCreateTables;  //db.DbMaintenance.GetTableInfoList().Where(it => NeedCreateTables.Contains(it.Name)).Select(it => it.Name).ToList();
            else
            {
                tables = db.DbMaintenance.GetTableInfoList().Select(it => it.Name).ToList();
                UpperFirst(tables);
            }

            //视图实体的命名空间
            string ModelsNamespace = SolutionName + ".DTO.Models";
            int type = 0;

            /***生成IRepository  start***/
            //配置参数
            var bllPath2 = "02IRepository";//文件目录
            var savePath2 = Methods.GetSlnPath + "\\" + classProjectName + "\\" + bllPath2;//保存目录

            //执行生成
            type = 1;
            GenerationCode(type, classProjectName, bllPath2, savePath2, tables, classNamespace, ModelsNamespace);
            Print("IRepository创建成功");
            /***生成IRepository  end***/


            /***生成Repository  start***/
            //配置参数
            var bllPath3 = "03Repository";//文件目录
            var savePath3 = Methods.GetSlnPath + "\\" + classProjectName + "\\" + bllPath3;//保存目录
            type = 2;
            //执行生成
            GenerationCode(type, classProjectName, bllPath3, savePath3, tables, classNamespace, ModelsNamespace);
            Print("Repository创建成功");
            /***生成Repository  end***/


            /***生成IServices  start***/
            //配置参数
            var bllPath4 = "04IServices";//文件目录
            var savePath4 = Methods.GetSlnPath + "\\" + classProjectName + "\\" + bllPath4;//保存目录
            type = 3;
            //执行生成
            GenerationCode(type, classProjectName, bllPath4, savePath4, tables, classNamespace, ModelsNamespace);
            Print("IServices创建成功");
            /***生成IServices  end***/

            /***生成Services  start***/
            //配置参数
            var bllPath5 = "05Services";//文件目录
            var savePath5 = Methods.GetSlnPath + "\\" + classProjectName + "\\" + bllPath5;//保存目录
            type = 4;
            //执行生成
            GenerationCode(type, classProjectName, bllPath5, savePath5, tables, classNamespace, ModelsNamespace);
            Print("Services创建成功");
            /***生成Services  end***/


            /***修改解决方案***/
            UpdateCsproj();
            Methods.RenameSln(SolutionName);
            Print("项目解决方案修改成功");


            /***添加项目引用***/
            //Methods.AddRef(classProjectName, classProjectName);
            //Print("引用添加成功");

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">
        /// 1 IRepository
        /// 2 Repository
        /// 3 IServices
        /// 4 Services
        /// </param>
        /// <param name="bllProjectName"></param>
        /// <param name="bllPath"></param>
        /// <param name="savePath"></param>
        /// <param name="tables"></param>
        /// <param name="classNamespace"></param>
        /// <param name="modelsNamespace"></param>
        private static void GenerationCode(int type, string bllProjectName,
            string bllPath, string savePath, List<string> tables,
            string classNamespace,
            string modelsNamespace
            )
        {

            string templatePath = Methods.GetCurrentProjectPath + "\\Template\\Bll.txt";//bll模版地址
            string Suffix = string.Empty; bool IsInterface = false;
            switch (type)
            {
                //IRepository
                case 1:
                    templatePath = Methods.GetCurrentProjectPath + "\\Template\\IRepository.txt";
                    Suffix = "Repository";
                    IsInterface = true;
                    break;
                case 2:
                    templatePath = Methods.GetCurrentProjectPath + "\\Template\\Repository.txt";
                    Suffix = "Repository";
                    break;
                case 3:
                    templatePath = Methods.GetCurrentProjectPath + "\\Template\\IServices.txt";
                    Suffix = "Services";
                    IsInterface = true;
                    break;
                case 4:
                    templatePath = Methods.GetCurrentProjectPath + "\\Template\\Services.txt";
                    Suffix = "Services";
                    break;
            }
            //下面代码不动
            Methods.CreateCode(templatePath, savePath, tables, SolutionName, classNamespace
                , modelsNamespace, Suffix, IsInterface);
            AddTask(bllProjectName, bllPath);
        }


        /// <summary>
        /// 生成BLL
        /// </summary>
        private static void GenerationBLL(string bllProjectName, string bllPath, string savePath, List<string> tables, string classNamespace)
        {
            var templatePath = Methods.GetCurrentProjectPath + "\\Template\\Bll.txt";//bll模版地址
            //下面代码不动
            Methods.CreateBLL(templatePath, savePath, tables, classNamespace);
            AddTask(bllProjectName, bllPath);
        }



        /// <summary>
        /// 生成DbContext
        /// </summary>
        private static void GenerationDContext(string contextProjectName, string contextPath, string savePath, List<string> tables, string classNamespace)
        {
            var templatePath = Methods.GetCurrentProjectPath + "\\Template\\DbContext.txt";//dbcontexts模版文件
            //下面代码不动
            var model = new DbContextParameter
            {
                ConnectionString = connectionString,
                DbType = dbType,
                Tables = tables,
                ClassNamespace = classNamespace
            };
            Methods.CreateDbContext(templatePath, savePath, model);
            AddTask(contextProjectName, contextPath);
        }

        /// <summary>
        /// 生成实体类
        /// </summary>
        private static void GenerationClass(string classProjectName, string classPath, string classNamespace, string classDirectory)
        {
            //连接数据库
            var db = GetDB();
            //下面代码不动
            db.DbFirst.IsCreateAttribute().CreateClassFile(classDirectory, classNamespace);
            AddTask(classProjectName, classPath);
        }

        #region 辅助方法

        public static void UpperFirst(List<string> list)
        {
            list.ForEach(c =>
            {
                c = c.Substring(0, 1).ToUpper() + c.Substring(1);
            });
        }

        /// <summary>
        ///  修改解决方案
        /// </summary>
        private static void UpdateCsproj()
        {
            foreach (var item in CsprojList)
            {
                item.Start();
                item.Wait();
            }
        }
        private static void Print(string message)
        {
            Console.WriteLine("--------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------");
        }

        private static void AddTask(string bllProjectName, string bllPath)
        {
            var task = new Task(() =>
            {
                Methods.AddCsproj(bllPath, bllProjectName);
            });
            CsprojList.Add(task);
        }
        static List<Task> CsprojList = new List<Task>();
        static SqlSugar.SqlSugarClient GetDB()
        {

            return new SqlSugar.SqlSugarClient(new SqlSugar.ConnectionConfig()
            {
                DbType = dbType,
                ConnectionString = connectionString,
                IsAutoCloseConnection = true,
                InitKeyType = SqlSugar.InitKeyType.Attribute
            });
        }
        #endregion
    }
}
