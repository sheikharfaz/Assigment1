using System.Linq;
using Assignment_Level1.Models;

namespace Assignment_Level1.Data
{
    public interface IQuery
    {
        IQueryable<object> Post(QueryParameter value);
    }
}
