using Tienda.Models.Entities;
using Tienda.Models.Interfaces;

namespace Tienda.Business
{
    public class CarritoBusiness : ICarritoBusiness
    {
        private readonly ICarritoDataAccess _dataAccess;
        public CarritoBusiness(ICarritoDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<int> SavePedido(CarritoModel datos)
        {
            try
            {
                int resultPedido = await _dataAccess.DbSavePedido(datos);
                datos.idPedido = resultPedido;
                int resultDetalle = await _dataAccess.DbSaveDetallePedido(datos);
                return resultPedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}