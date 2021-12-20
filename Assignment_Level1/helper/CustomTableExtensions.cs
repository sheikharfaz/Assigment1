using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Level1.helper
{
    public static partial class CustomTableExtensions
    {
    //    public static PropertyInfo Query(this DbContext context, string entityName) =>
    //        context.GetType().GetProperty(entityName);


        public static Type Query(this DbContext context, string entityName) =>
        context.Model.FindEntityType(entityName).ClrType;

    //static readonly MethodInfo SetMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set));

    //public static IQueryable<object> Query(this DbContext context, Type entityType) =>
    //    (IQueryable<object>)SetMethod.MakeGenericMethod(entityType).Invoke(context, null);
}
}
    