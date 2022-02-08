using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conection = new CD_Conexion();

        //Leer filas de la tabla
        SqlDataReader read;
        //Almacena las filas de la consulta que realizara SqlDataReader
        DataTable table = new DataTable();
        //Ejecutar instrucciones TransactSql o procedimientos almacenados
        SqlCommand command = new SqlCommand();

        //mostrar registros de la tabla
        public DataTable ShowData()
        {
            //TRANSACT SQL

            /*command.Connection = conection.OpenConnection();
            command.CommandText = "SELECT * FROM Productos";
            read = command.ExecuteReader();
            table.Load(read);
            conection.CloseConnection();
            return table;*/

            //PROCEDIMIENTO ALCAMENADO
            command.Connection = conection.OpenConnection();
            command.CommandText = "MostrarProductos";
            command.CommandType = CommandType.StoredProcedure;
            read = command.ExecuteReader();
            table.Load(read);
            conection.CloseConnection();
            return table;
            
        }

        public void Insert(string name, string description, string tradeMark, double price, int stock)
        {
            //TRANSACT SQL
            /*command.Connection = conection.OpenConnection();
            command.CommandText = "insert into Productos values ('"+name+"', '"+description+"', '"+tradeMark+"', '"+price+"', '"+stock+"')";
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();*/

            //PROCEDIMIENTO ALCAMENADO
           
            command.Connection = conection.OpenConnection();
            command.CommandText = "InsertarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@tradeMark", tradeMark);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@stock", stock);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void Edit(int id, string name, string description, string tradeMark, double price, int stock)
        {
            
            command.Connection = conection.OpenConnection();
            command.CommandText = "EditarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@tradeMark", tradeMark);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@stock", stock);
            command.ExecuteNonQuery();
            command.Parameters.Clear();

        }

        public void Delete(int id)
        {
            command.Connection = conection.OpenConnection();
            command.CommandText = "EliminarProducto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }


    }
}
