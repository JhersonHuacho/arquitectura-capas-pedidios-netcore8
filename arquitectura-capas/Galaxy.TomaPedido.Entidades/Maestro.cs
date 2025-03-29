﻿using System;
using System.Collections.Generic;

namespace Galaxy.TomaPedido.Entidades;

public partial class Maestro : EntidadBase
{
	public string Codigo { get; set; } = null!;

	public string Nombre { get; set; } = null!;

	public string? Descripcion { get; set; }

	public virtual ICollection<MaestroDetalle> MaestroDetalles { get; set; } = new List<MaestroDetalle>();
}
