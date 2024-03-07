using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Log_inWeb_Api.Models
{
    public class DAL
    {
        private static int webapicon;
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[webapicon].ConnectionString);
        //SqlDataAdapter da = null;
        DataTable dt = null;

        public string GetLogin(LoginModel loginModel)
        {
            //da = new SqlDataAdapter("Select * from Users where UserName = '"+ loginModel.Username+"' and Password = '"+ loginModel.Password +"' ", con);
            dt = new DataTable();
            //da.Fill(dt);    
            if(dt.Rows.Count>0)
            
                return "Logged In";
            else
                return "Login failed";

            
        }
    }
}
