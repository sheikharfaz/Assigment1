using System.Collections.Generic;

namespace Assignment_Level1.Models
{
    public class QueryParameter
    {
        public string ObjectName { get; set; }

        public string[] SelectColumns { get; set; }

        public WhereClause WhereClause { get; set; }

        public string[] GroupByColumns { get; set; }

        public string OrderByColumns { get; set; }

    }
}
