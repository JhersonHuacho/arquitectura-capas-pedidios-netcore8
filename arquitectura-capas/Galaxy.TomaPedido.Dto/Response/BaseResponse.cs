namespace Galaxy.TomaPedido.Dto.Response
{
	public class BaseResponse
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public string? ErrorCode { get; set; }
	}

	public class BaseResponse<T> : BaseResponse
	{
		public T? Data { get; set; }
	}

	/*
	 * public class BaseResponse {}
	 * public class BaseResponseGenerico<T> : BaseResponse {}
	 * 
	 * var response = new BaseResponse();
	 * var response = new BaseResponseGenerico<Cliente>();
	 */
}
