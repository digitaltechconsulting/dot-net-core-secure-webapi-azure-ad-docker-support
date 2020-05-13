using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureWebApi.Interfaces
{
	public interface ICheckout
	{
		Task<bool> ValidatePayload();
	}
}
