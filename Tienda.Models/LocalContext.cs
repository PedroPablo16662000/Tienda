using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tienda.Models
{
    public static class LocalContext {
        public static string? strConn  { get; set; }

    }
}
