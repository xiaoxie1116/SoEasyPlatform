using System.Collections.Generic;
using SqlSugar;

namespace SugarCodeGeneration
{
    public class DbContextParameter
    {
        public string ConnectionString { get; set; }
        public DbType DbType { get; set; }
        public List<string> Tables { get; set; }

        /// <summary>
        /// 数据库实体类名称
        /// </summary>
        public string ClassNamespace { get; set; }

    }
}