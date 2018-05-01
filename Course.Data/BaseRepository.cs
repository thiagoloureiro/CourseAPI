using System.Configuration;

namespace Course.Data
{
    public class BaseRepository
    {
        public string Connstring = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
    }
}