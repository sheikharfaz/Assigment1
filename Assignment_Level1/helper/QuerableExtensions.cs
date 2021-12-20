using System;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment_Level1.helper
{
    public static partial class QueryableExtensions
    {
        public static IQueryable<T> SelectMembers<T>(this IQueryable<T> source, params string[] memberNames)
        {
            var parameter = Expression.Parameter(typeof(T), "e");
            var bindings = memberNames
                .Select(name => Expression.PropertyOrField(parameter, name))
                .Select(member => Expression.Bind(member.Member, member));
            var body = Expression.MemberInit(Expression.New(typeof(T)), bindings);
            var selector = Expression.Lambda<Func<T, T>>(body, parameter);
            return source.Select(selector);
        }

        public static IQueryable<T> WhereMembers<T>(this IQueryable<T> source, string field, string value)
        {
            var _Type = typeof(T);  
            var _Prop = _Type.GetProperty(field);
            var _Param = Expression.Parameter(_Type, _Prop.Name);
            var _Left = Expression.PropertyOrField(_Param, _Prop.Name);
            var _Right = Expression.Constant(value, _Prop.PropertyType);
            var _body = Expression.Equal(_Left, _Right);
            var _Where = Expression.Lambda<Func<T, bool>>(_body, _Param);
            return source.Where(_Where);
        }

        public static IQueryable<T> OrderByMembers<T>(this IQueryable<T> source, string memberNames)
        {
            var _Type = typeof(T);
            var _Prop = _Type.GetProperty(memberNames);
            var _Param = Expression.Parameter(_Type, _Prop.Name);
            var _Left = Expression.PropertyOrField(_Param, _Prop.Name);
            var _Right = Expression.Constant(memberNames, _Prop.PropertyType);
            var _body = Expression.Equal(_Left, _Right);
            var _OrderBy = Expression.Lambda<Func<T, bool>>(_body, _Param);
            return source.OrderBy(_OrderBy);
        }
    }
}
