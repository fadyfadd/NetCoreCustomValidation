using System;
using System.Collections.Generic; 
using Oracle.ManagedDataAccess.Client;
using System.Data; 
using System.Linq; 
using System.Reflection; 
using Oracle.ManagedDataAccess.Types;


namespace NetCoreCustomValidation
{
    public class OracleUtilities
    {    
        public static c ParseDataReader<e,c> (OracleDataReader reader) where e : new() where c : ICollection<e> ,  new()
        {
            try {  
                   c container = new c(); 
                   List<String> names = new List<String>(); 
                   
                   for (int i=0 ; i<= reader.FieldCount - 1 ; i++) {
                       names.Add(reader.GetName(i));
                   }

                   while (reader.Read()) {

                       e element = new e(); 

                       for (int i = 0 ; i <= names.Count - 1 ; i++) {
                           
                           Object  fieldValue = reader[names[i]];                           
                           PropertyInfo info = typeof(e).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                           .Where(p=>p.Name.ToUpper() == names[i].ToUpper()).FirstOrDefault();
                           Object castedValue = CastValue(fieldValue , info); 
                           info.SetValue(element , castedValue);

                       }

                       container.Add(element);
                   }
                   
                   return container; 
            }
            catch (Exception) {
               throw; 
            }
            finally {
                reader.Close(); 
            }
                     
        }
   
        public static Object CastValue(Object value , PropertyInfo info){
            
            Type infoType = info.PropertyType;
            
            if (infoType == typeof(Int16?)) {
                return (Int16?)value;
            }
            else if (infoType == typeof(Int32?)) {
                return (Int32?)value;
            }
             else if (infoType == typeof(Int64?)) {
                 return (Int64?)value;
            }
            else if (infoType == typeof(Single?)) {
                 return (Single?)value;
            }
            else if (infoType == typeof(Double?)) {
                 return (Double?)value;
            }
             else if (infoType == typeof(Decimal?)) {
                 return (Decimal?)value;
            }
            else {
                return Convert.ChangeType(value , infoType);
            } 
                   
        }
    
        public static OracleCommand ExecuteGenericProcedure(OracleConnection conn , String procedureName , OracleTransaction trans ,  params OracleParameter[] parameters) {
            
            using (OracleCommand comm = new OracleCommand()) {
                comm.CommandText = procedureName;
                comm.Connection = conn; 
                comm.Transaction = trans; 
                comm.CommandType = CommandType.StoredProcedure; 

                foreach (OracleParameter param in parameters) {
                    comm.Parameters.Add(param);
                }

                comm.ExecuteNonQuery();   
                return comm;             
            }        
           
        }
    }
}

/*
  public List<Employee> GetEmployees() {
           
           using (OracleConnection conn = new OracleConnection(this.ConnectionString)) {
               
               conn.Open();                

               OracleCommand command = OracleUtilities.ExecuteGenericProcedure(conn , "hr_app.get_all_employees" , null , new OracleParameter() {
                       OracleDbType = OracleDbType.RefCursor , ParameterName = "p_recordset" , 
                       Direction = ParameterDirection.Output                      
                   });

                var reader = ((OracleRefCursor)command.Parameters["p_recordset"].Value).GetDataReader();
                List<Employee> list =  OracleUtilities.ParseDataReader<Employee,List<Employee>>(reader);
                return list; 
           }           
            
}
*/