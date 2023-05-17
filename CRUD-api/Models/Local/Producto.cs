using System;
using System.Collections.Generic;

namespace CRUD_api.Models.Local;

public partial class Producto
{
    public int Id { get; set; }

    public string? Producto1 { get; set; }

    public string? Cantidad { get; set; }

    public DateTime? Fecha { get; set; }
}
