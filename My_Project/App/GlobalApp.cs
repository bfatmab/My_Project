using System.Configuration;
using System.Data.SqlClient;

namespace My_Project.App
{
    public class GlobalApp
    {
        public static SqlConnection Connection { get 
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["adoConnectionString"].ConnectionString);
            
            } 
            private set 
            { 
                Connection = value;
            }
        
        }
    }
}
