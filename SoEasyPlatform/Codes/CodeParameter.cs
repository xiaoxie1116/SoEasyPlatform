using System;
using System.Collections.Generic;
using System.Text;

namespace SugarCodeGeneration
{
    public class CodeParameter
    {
        public string Name { get; set; }

        public string ClassNamespace { get; set; }


        /// <summary>
        /// 视图类实体名称
        /// </summary>
        public string ModelsNamespace { get; set; }

        /// <summary>
        /// 解决方案名称
        /// </summary>
        public string SolutionName { get; set; }
    }
}
