using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objectCD = new CD_Productos();

        public DataTable ShowProducts()
        {
            DataTable table = new DataTable();
            table = objectCD.ShowData();
            return table;
        }

        public void InsertProducts(string name, string description, string tradeMark, string price, string stock) 
        {
            objectCD.Insert(name, description, tradeMark, Convert.ToDouble(price), Convert.ToInt32(stock));

        }

        public void EditProducts(string id, string name, string description, string tradeMark, string price, string stock)
        {
            objectCD.Edit(Convert.ToInt32(id), name, description, tradeMark, Convert.ToDouble(price), Convert.ToInt32(stock));
        }

        public void DeleteProducts(string id)
        {
            objectCD.Delete(Convert.ToInt32(id));
        }

    }
}
