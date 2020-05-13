using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWebApi.Services
{
	public class CheckoutServiceResponse
	{
		public bool Error { get; set; }
		public Uri RedirectUri { get; set; }
	}
}
