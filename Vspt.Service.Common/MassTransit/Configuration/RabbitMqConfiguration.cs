using System;

namespace Vspt.Service.Common.MassTransit.Configuration;

public class RabbitMqConfiguration
{
	public Uri HostAddress { get; set; }
	public string QueuePrefix { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
}
