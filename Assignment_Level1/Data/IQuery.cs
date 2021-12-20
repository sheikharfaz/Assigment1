using Assignment_Level1.Models;

namespace Assignment_Level1.Data
{
    public interface IQuery
    {
        string Post(QueryParameter query);
    }
}
