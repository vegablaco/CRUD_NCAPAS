using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private readonly SqlConnection Conexion = new SqlConnection("server=DESKTOP-SM0AHH5; database=Practica; integrated security=true");

        public SqlConnection OpenConnection()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }

        public SqlConnection CloseConnection()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;
        }




    }
}
