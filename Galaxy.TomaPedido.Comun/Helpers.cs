namespace Galaxy.TomaPedido.Comun
{
    public static class Helpers
    {
        public static int CalcularNumeroPaginas(int totalFilas, int filas)
		{
			return (int)Math.Ceiling((double)totalFilas / filas);
		}
	}
}
