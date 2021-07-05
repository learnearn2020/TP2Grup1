using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //"Data Source=DESKTOP-GDB781L\JHMESSEROUX;Initial Catalog=example;Persist Security Info=True;User ID=sa;Password=jhm.ok"

        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        //Clave por defecto a utlizar para la cadena de conexion
        //const string consKeyDefaultCnnString = "ConnStringLocal";
        private string stringConnection = "Data Source=DESKTOP-GDB781L\\JHMESSEROUX;Initial Catalog=Academia;Persist Security Info=True;User ID=sa;Password=jhm.ok";
        SqlConnection sqlConn = new SqlConnection();
        public SqlConnection SqlConn
        {
            get { return sqlConn;  } 
            set {
                value = sqlConn;
            }
        } 
        protected void OpenConnection()
        {
           // string stringConnection = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn.ConnectionString = stringConnection;
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
