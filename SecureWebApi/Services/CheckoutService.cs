using SecureWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SecureWebApi.Services
{
	public class CheckoutService : ICheckout
	{
		public async Task<bool> ValidatePayload()
		{
			var result = false;
			var task = Task.Factory.StartNew(() =>
			{
				Thread.Sleep(5000);
				result = true;
			});

			await task;
			return result;
		}
	}
}
