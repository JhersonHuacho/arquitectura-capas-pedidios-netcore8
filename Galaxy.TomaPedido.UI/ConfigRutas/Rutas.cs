namespace Galaxy.TomaPedido.UI.ConfigRutas
{
	public static class Rutas
	{
		public const string ListarClientes = "/Clientes";
		public const string RegistrarClientes = "/Clientes/registro";
		public const string EditarClientesNav = "/Clientes/editar/{id:int}";
		public const string EditarClientes = "/Clientes/editar";

		public const string ListarProductos = "/Productos";
		public const string RegistrarProductos = "/Productos/registro";
		public const string EditarProductosNav = "/Productos/editar/{id:int}";
		public const string EditarProductos = "/Productos/editar";

		public const string Pedido = "/Pedido";
	}
}
