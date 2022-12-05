using HRCRS_BACKEND.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRCRS_BACKEND.Model
{
    public class PincodeClass: IPincode
    {
        string ConnectionString =string.Empty;

        public PincodeClass(IConfiguration configuration )
        {
            ConnectionString = configuration.GetValue<string>("ConnectionStrings");
        }
        public async Task<Pincoderesponse> PincodeData(int pincode)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Pincode", connection)
                {
                    CommandType= System.Data.CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter
                {
                     ParameterName="@Pincode",
                     SqlDbType = System.Data.SqlDbType.Int,
                     Value=pincode,
                     Direction=System.Data.ParameterDirection.Input
                };
                SqlParameter param2 = new SqlParameter
                {
                    ParameterName = "@flag",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction=System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                connection.Open();


                Pincoderesponse pincoderesponse = new Pincoderesponse();
                cmd.ExecuteNonQuery();
                object kuchbhi = param2.Value;
                int flag = Convert.ToInt32(kuchbhi);
                using (var reader = cmd.ExecuteReader())
                {
                    if (flag==0)
                    {
                        pincoderesponse.Status = false;
                    }
                    else
                    {
                        
                            while (reader.Read())
                            {
                                pincoderesponse.Status = true;
                                pincoderesponse.Pincode = reader.GetInt32("Pincode");
                                pincoderesponse.City = reader.GetString("City");
                                pincoderesponse.State = reader.GetString("State");

                            }
                        
                    }
                }

                
                connection.Close();
                return  pincoderesponse;
            }
        }
    }
}
