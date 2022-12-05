using FluentValidation.Results;
using HRCRS_BACKEND.DTO;
using HRCRS_BACKEND.Validators;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRCRS_BACKEND.Model
{
    public class Demographic : Idemographic
    {
        string ConnectionString = string.Empty;

        public Demographic(IConfiguration configuration)
        {
            ConnectionString = configuration.GetValue<string>("ConnectionStrings");
        }
        public async Task<DemographicInsertReturnType> DemographicInsert(DemographicType Newuser)
        {
            DemographicInsertReturnType temp = new DemographicInsertReturnType();

            DemographicValidation validator = new DemographicValidation();

            ValidationResult result = validator.Validate(Newuser);
            if (result.IsValid == true)
            {
                temp.Validation = true;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("DemographicInsert", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@foreName", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.ForeName, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param2 = new SqlParameter
                    {
                        ParameterName = "@surName", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.SurName, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param3 = new SqlParameter
                    {
                        ParameterName = "@DOB", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Date, //Data Type of Parameter
                        Value = Newuser.DateofBirth, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param4 = new SqlParameter
                    {
                        ParameterName = "@gender", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.Gender, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param5 = new SqlParameter
                    {
                        ParameterName = "@Iname", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.IdentificationName, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param6 = new SqlParameter
                    {
                        ParameterName = "@Inumber", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.IdentificationNumber, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param7 = new SqlParameter
                    {
                        ParameterName = "@street", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.Street, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param8 = new SqlParameter
                    {
                        ParameterName = "@city", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.City, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param9 = new SqlParameter
                    {
                        ParameterName = "@state", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.State, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param10 = new SqlParameter
                    {
                        ParameterName = "@region", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = Newuser.Region, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param11 = new SqlParameter
                    {
                        ParameterName = "@pincode", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = Newuser.Pincode, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param12 = new SqlParameter
                    {
                        ParameterName = "@addressType", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = Newuser.AddressType, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param13 = new SqlParameter
                    {
                        ParameterName = "@PhoneNumber", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.PhoneNumber, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param14 = new SqlParameter
                    {
                        ParameterName = "@Email", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.Email, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param15 = new SqlParameter
                    {
                        ParameterName = "@LCS", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.VarChar, //Data Type of Parameter
                        Value = Newuser.LegalCopyStatus, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param16 = new SqlParameter
                    {
                        ParameterName = "@IsActive", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Bit, //Data Type of Parameter
                        Value = Newuser.IsActive, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param17 = new SqlParameter
                    {
                        ParameterName = "@Addedby", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = Newuser.AddedBy, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param18 = new SqlParameter
                    {
                        ParameterName = "@Modiffiedby", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = Newuser.ModifiedBy, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    SqlParameter param19 = new SqlParameter()
                    {
                        ParameterName = "@flag",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output,
                    };

                    connection.Open();

                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);
                    cmd.Parameters.Add(param5);
                    cmd.Parameters.Add(param6);
                    cmd.Parameters.Add(param7);
                    cmd.Parameters.Add(param8);
                    cmd.Parameters.Add(param9);
                    cmd.Parameters.Add(param10);
                    cmd.Parameters.Add(param11);
                    cmd.Parameters.Add(param12);
                    cmd.Parameters.Add(param13);
                    cmd.Parameters.Add(param14);
                    cmd.Parameters.Add(param15);
                    cmd.Parameters.Add(param16);
                    cmd.Parameters.Add(param17);
                    cmd.Parameters.Add(param18);
                    cmd.Parameters.Add(param19);




                    cmd.ExecuteNonQuery();

                    string flag = param19.Value.ToString();

                    if (flag == "0")
                    {
                        temp.Conflict = true;
                        DemographicType ExistingData = new DemographicType();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ExistingData.ForeName = reader.GetString("ForeName");
                                ExistingData.SurName = reader.GetString("SurName");
                                ExistingData.PhoneNumber = reader.GetString("PhoneNumber");
                                ExistingData.Email = reader.GetString("Email");
                                ExistingData.IdentificationName = reader.GetString("IdentificationName");
                                ExistingData.IdentificationNumber = reader.GetString("IdentificationNumber");
                                ExistingData.DateofBirth = reader.GetDateTime("DateofBirth");
                            }
                        }
                        temp.DemographicObject = ExistingData;
                        connection.Close();
                        return temp;
                    }
                    else
                    {
                        temp.Conflict = false;
                        return temp;
                    }

                }
            }
            else
            {
                temp.Validation=false;
                List<string> errorsList = new List<string>();
                foreach(ValidationFailure failure in result.Errors)
                {
                    errorsList.Add($"{failure.PropertyName}:{failure.ErrorMessage}");
                }
                temp.Errors = errorsList;
                return temp;
            }

            
        }

        public async Task<bool> DemographicDelete(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Demographicdelete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Inumber",
                    SqlDbType = SqlDbType.VarChar,
                    Value = id, 
                    Direction = ParameterDirection.Input,
                };
                SqlParameter param2 = new SqlParameter()
                {
                    ParameterName = "@flag",
                    SqlDbType=SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                };
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add (param2);
                connection.Open();
                cmd.ExecuteNonQuery();
                string flag = param2.Value.ToString();
                connection.Close();
                if(flag == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            
        }

        public async Task<DemographicUpdateReturnType> DemographicUpdate(DemographicType Newuser)
        {
            DemographicUpdateReturnType temp = new DemographicUpdateReturnType();
            DemographicValidation validator = new DemographicValidation();

            ValidationResult result = validator.Validate(Newuser);
            if (result.IsValid == true)
            {
                temp.Validation = true;
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Demographicedit", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter param1 = new SqlParameter()
                    {
                        ParameterName = "@Inumber",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.IdentificationNumber,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param2 = new SqlParameter()
                    {
                        ParameterName = "@Email",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.Email,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param3 = new SqlParameter()
                    {
                        ParameterName = "@phonenumber",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.PhoneNumber,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param4 = new SqlParameter()
                    {
                        ParameterName = "@street",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.Street,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param5 = new SqlParameter()
                    {
                        ParameterName = "@Forename",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.ForeName,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param6 = new SqlParameter()
                    {
                        ParameterName = "@Surname",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.SurName,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param7 = new SqlParameter()
                    {
                        ParameterName = "@Pincode",
                        SqlDbType = SqlDbType.Int,
                        Value = Newuser.Pincode,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param8 = new SqlParameter()
                    {
                        ParameterName = "@Region",
                        SqlDbType = SqlDbType.Int,
                        Value = Newuser.Region,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param9 = new SqlParameter()
                    {
                        ParameterName = "@City",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.City,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param10 = new SqlParameter()
                    {
                        ParameterName = "@State",
                        SqlDbType = SqlDbType.VarChar,
                        Value = Newuser.State,
                        Direction = ParameterDirection.Input,
                    };
                    SqlParameter param11 = new SqlParameter()
                    {
                        ParameterName = "@flag",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output,
                    };
                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);
                    cmd.Parameters.Add(param3);
                    cmd.Parameters.Add(param4);
                    cmd.Parameters.Add(param5);
                    cmd.Parameters.Add(param6);
                    cmd.Parameters.Add(param7);
                    cmd.Parameters.Add(param8);
                    cmd.Parameters.Add(param9);
                    cmd.Parameters.Add(param10);
                    cmd.Parameters.Add(param11);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    string flag = param11.Value.ToString();
                    connection.Close();
                    if (flag == "1")
                    {
                        temp.DataUpdated=true;
                    }
                    else
                    {
                        temp.DataUpdated=false;
                    }
                    return temp;

                }
            }
            else
            {
                temp.Validation = false;
                List<string> errorsList = new List<string>();
                foreach (ValidationFailure failure in result.Errors)
                {
                    errorsList.Add($"{failure.PropertyName}:{failure.ErrorMessage}");
                }
                temp.Errors = errorsList;
                return temp;
            }
           
        }

        public async Task<IEnumerable<DemographicType>> DemographicReadAll()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Demographicreadall", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                var reader = cmd.ExecuteReader();
                List<DemographicType> Finalresult = new List<DemographicType>();
                while (reader.Read())
                {
                    DemographicType ReturnData = new DemographicType();
                    ReturnData.ForeName = reader.GetString("ForeName");
                    ReturnData.SurName = reader.GetString("SurName");
                    ReturnData.Gender = reader.GetString("Gender");
                    ReturnData.Email = reader.GetString("Email");
                    ReturnData.IdentificationNumber = reader.GetString("identificationNumber");
                    ReturnData.IdentificationName = reader.GetString("identificationName");
                    ReturnData.Pincode = reader.GetInt32("Pincode");
                    ReturnData.PhoneNumber = reader.GetString("PhoneNumber");
                    ReturnData.DateofBirth = reader.GetDateTime("DateofBirth");
                    ReturnData.City = reader.GetString("City");
                    ReturnData.State = reader.GetString("State");
                    ReturnData.Street = reader.GetString("Street");
                    ReturnData.LegalCopyStatus = reader.GetString("LegalCopyStatus");
                    ReturnData.IsActive = reader.GetBoolean("IsActive");
                    ReturnData.AddedBy = reader.GetInt32("AddedBy");
                    ReturnData.ModifiedBy = reader.GetInt32("ModifiedBy");
                    ReturnData.Region = reader.GetInt32("Region");
                    ReturnData.AddressType = reader.GetInt32("AddressType");


                    Finalresult.Add(ReturnData);
                }
                connection.Close();
                return Finalresult;

            }
        }

        public async Task<DemographicType> DemographicReadbyID(string id)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DemographicreadbyID",connection)
                {
                    CommandType= CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Inumber",
                    SqlDbType = SqlDbType.VarChar,
                    Value = id,
                    Direction = ParameterDirection.Input,
                };
                cmd.Parameters.Add(param1);
                connection.Open();
                var reader = cmd.ExecuteReader();
                DemographicType ReturnData = new DemographicType();
                while (reader.Read())
                {
                    ReturnData.ForeName = reader.GetString("ForeName");
                    ReturnData.SurName = reader.GetString("SurName");
                    ReturnData.Gender = reader.GetString("Gender");
                    ReturnData.Email = reader.GetString("Email");
                    ReturnData.IdentificationNumber = reader.GetString("identificationNumber");
                    ReturnData.IdentificationName = reader.GetString("identificationName");
                    ReturnData.Pincode = reader.GetInt32("Pincode");
                    ReturnData.PhoneNumber = reader.GetString("PhoneNumber");
                    ReturnData.DateofBirth = reader.GetDateTime("DateofBirth");
                    ReturnData.City = reader.GetString("City");
                    ReturnData.State = reader.GetString("State");
                    ReturnData.Street = reader.GetString("Street");
                    ReturnData.LegalCopyStatus = reader.GetString("LegalCopyStatus");
                    ReturnData.IsActive = reader.GetBoolean("IsActive");
                    ReturnData.AddedBy = reader.GetInt32("AddedBy");
                    ReturnData.ModifiedBy = reader.GetInt32("ModifiedBy");
                    ReturnData.Region = reader.GetInt32("Region");
                    ReturnData.AddressType = reader.GetInt32("AddressType");
                }
                connection.Close();
                return ReturnData;
            }
        }

    }
}
