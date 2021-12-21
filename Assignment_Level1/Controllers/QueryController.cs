using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Assignment_Level1.helper;
using Assignment_Level1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Level1.Controllers
{
    [Route("api/[controller]")]
    public class QueryController : Controller
    {
        private readonly QueryDBContext _dbContext;

        public QueryController(QueryDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // POST api/values
       [HttpPost]
        public IQueryable<object> Post([FromBody] QueryParameter value)
        {
            Dictionary<string, Type> TableTypeDictionary = new Dictionary<string, Type>()
            {
                {"Students",typeof(Student) },
            };

            //var tableData = _dbContext.Query("Student");

            //var lamba = GroupByExpression.GroupByExpressions<Student>(value.GroupByColumns);

            //var selectResult = _dbContext.Students.SelectMembers(value.SelectColumns);

            //var groupByResult = selectResult.GroupBy(lamba.Compile()).AsQueryable();

            //var orderByResult = selectResult.OrderByMembers(value.OrderByColumns).AsQueryable();

            var result = _dbContext.Students.SelectMembers(value.SelectColumns).GroupByExpressions(value.GroupByColumns)
                .OrderByMembers(value.OrderByColumns)
                .WhereMembers(value.WhereClause.Field, value.WhereClause.WhereClauseValue);
                
                                           
            return result;
        }




    }
}
