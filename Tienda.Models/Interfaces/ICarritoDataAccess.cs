using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Models.Entities;

namespace Tienda.Models.Interfaces
{
    public interface ICarritoDataAccess
    {
        Task<int> DbSaveDetallePedido(CarritoModel datos);
        Task<int> DbSavePedido(CarritoModel datos);
    }
}
