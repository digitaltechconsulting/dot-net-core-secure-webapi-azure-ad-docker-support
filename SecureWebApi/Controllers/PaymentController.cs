using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureWebApi.Interfaces;
using SecureWebApi.Services;

namespace SecureWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly ICheckout _checkout;
		public PaymentController(ICheckout checkout)
		{
			_checkout = checkout;
		}

		[HttpPost]
		[Consumes("application/x-www-form-urlencoded")]
		public async Task<IActionResult> Checkout(IFormCollection keyValuePairs)
		{
			foreach (var item in keyValuePairs)
			{
				Console.WriteLine($"{item.Key} : {item.Value}");

			}
			var result = await _checkout.ValidatePayload();
			Response.Headers.Add("Access-Control-Allow-Origin", "*");
			return RedirectPermanent("http://google.com.au");
			//return Ok(new CheckoutServiceResponse {RedirectUri = new Uri("http://google.com.au"), Error = true });
		}
	}
}
