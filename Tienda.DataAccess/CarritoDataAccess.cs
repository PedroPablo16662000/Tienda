using System.Data;
using System.Data.SqlClient;
using Tienda.Models;
using Tienda.Models.Entities;
using Tienda.Models.Interfaces;

namespace Tienda.DataAccess
{
    public class CarritoDataAccess : ICarritoDataAccess
    {
        private readonly string _stringDB = LocalContext.strConn;
        public async Task<int> DbSavePedido(CarritoModel datos)
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(_stringDB))
            {
                SqlCommand cmd = new SqlCommand("AddPedido", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idCliente", datos.idCliente);
                cmd.Parameters.AddWithValue("valorTotal", datos.valorTotal);
                cn.Open();
                result = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close();
            }
            return result;
        }
        public async Task<int> DbSaveDetallePedido(CarritoModel datos)
        {
            int result = 0;
            foreach (var item in datos.detalles)
            {
                using (SqlConnection cn = new SqlConnection(_stringDB))
                {
                    SqlCommand cmd = new SqlCommand("AddDetalle", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idPedido", datos.idPedido);
                    cmd.Parameters.AddWithValue("cantidad", item.cantidad);
                    cmd.Parameters.AddWithValue("vlUnit", item.vlUnit);
                    cmd.Parameters.AddWithValue("producto", item.producto);
                    cn.Open();
                    result = int.Parse(cmd.ExecuteNonQuery().ToString());
                    cn.Close();
                    result++;
                }
            }

            return result;
        }
    }
}