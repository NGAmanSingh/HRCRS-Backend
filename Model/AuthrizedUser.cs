using HRCRS_BACKEND.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRCRS_BACKEND.Model
{
    public class AuthrizedUser: IAuthrizedUser
    {
        string ConnectionString=string.Empty;
        
        public AuthrizedUser(IConfiguration configuration)
        {
            ConnectionString = configuration.GetValue<string>("ConnectionStrings");
        }
        public async Task<bool> AuthrizeUser(UserInfo userinfo)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("AuthorizeUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter
                {
                    ParameterName = "@usercode", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                    Value = "ng2008"/*userinfo.username*/, //Value passes to the paramtere
                    Direction = ParameterDirection.Input //Specify the parameter as input
                };
                connection.Open();
                cmd.Parameters.Add(param1);
                var result = cmd.ExecuteScalar();
                var final = result.ToString();  
                if (final=="True")
                {
                    return true;
                }
            }
            return false;
            
         }
    }

}
