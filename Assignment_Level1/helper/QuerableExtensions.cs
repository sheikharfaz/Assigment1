using System;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment_Level1.helper
{
    public static partial class QueryableExtensions
    {
        public static IQueryable<T> SelectMembers<T>(this IQueryable<T> source, params string[] memberNames)
        {
            //if (memberNames.Contains("string"))
            //    return source;

            var parameter = Expression.Parameter(typeof(T), "e");
            var bindings = memberNames
                .Select(name => Expression.PropertyOrField(parameter, name))
                .Select(member => Expression.Bind(member.Member, member));
            var body = Expression.MemberInit(Expression.New(typeof(T)), bindings);
            var selector = Expression.Lambda<Func<T, T>>(body, parameter);
            return source.Select(selector);
        }

        public static IQueryable<T> WhereMembers<T>(this IQueryable<T> source, string field, int value)
        {
            //if (field.Contains("string"))
            //    return source;

            var _Type = typeof(T);  
            var _Prop = _Type.GetProperty(field);
            var _Param = Expression.Parameter(_Type, _Prop.Name);
            var _Left = Expression.PropertyOrField(_Param, _Prop.Name);
            var _Right = Expression.Constant(value, _Prop.PropertyType);
            var _body = Expression.Equal(_Left, _Right);
            var _Where = Expression.Lambda<Func<T, bool>>(_body, _Param);
            return source.Where(_Where);
        }

        

        public static IQueryable<T> OrderByMembers<T>(this IQueryable<T> source, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }

        public static IQueryable<T> GroupByExpressions<T>(this IQueryable<T> source, string[] propertyNames)
        {
            if (propertyNames.Count() == 1 && propertyNames.Contains("string"))
                return source;

            var properties = propertyNames.Select(name => typeof(T).GetProperty(name)).ToArray();
            var propertyTypes = properties.Select(p => p.PropertyType).ToArray();
            var tupleTypeDefinition = typeof(Tuple).Assembly.GetType("System.Tuple`" + properties.Length);
            var tupleType = tupleTypeDefinition.MakeGenericType(propertyTypes);
            var constructor = tupleType.GetConstructor(propertyTypes);
            var param = Expression.Parameter(typeof(T), "item");
            var body = Expression.New(constructor, properties.Select(p => Expression.Property(param, p)));
            var expr = Expression.Lambda<Func<T, object>>(body, param);
            var exp = expr.Compile();

            return source.GroupBy(exp).SelectMany(exp => exp).AsQueryable();
        }


        //public static IQueryable<T> OrderByMembers<T>(this IQueryable<T> source, string[] memberNames)
        //{

        //    //if (memberNames.Contains("string"))
        //    //    return source;
        //    var _Type = typeof(T);
        //    var _Prop = _Type.GetProperty(memberNames.First());
        //    var parameter = Expression.Parameter(typeof(T), "e");
        //    var bindings = memberNames
        //        .Select(name => Expression.PropertyOrField(parameter, name))
        //        .Select(member => Expression.Bind(member.Member, member));
        //    var body = Expression.MemberInit(_Prop, bindings);
        //    var selector = Expression.Lambda<Func<T, T>>(body, parameter);
        //    return source.Select(selector);

        //    //var _Type = typeof(T);
        //    //var _Prop = _Type.GetProperty(memberNames);
        //    //var _Param = Expression.Parameter(_Type, _Prop.Name);
        //    //var _Left = Expression.PropertyOrField(_Param, _Prop.Name);
        //    //var _Right = Expression.Constant(memberNames, _Prop.PropertyType);
        //    //var _body = Expression.Equal(_Left, _Right);
        //    //var _OrderBy = Expression.Lambda<Func<T, bool>>(_body, _Param);
        //    //return source.OrderBy(_OrderBy);
        //}
    }
}
