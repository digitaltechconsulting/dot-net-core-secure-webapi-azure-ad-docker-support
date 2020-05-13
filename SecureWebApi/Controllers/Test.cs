using System;
using Microsoft.AspNetCore.Mvc;

namespace SecureWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		public string Get()
		{
			return $"Hello World - {Environment.GetEnvironmentVariable("ENV")}";
		}

		[HttpGet("ping")]
		public string Ping()
		{
			return $"Your api is up and running.";
		}
	}
}
