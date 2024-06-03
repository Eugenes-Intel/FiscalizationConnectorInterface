using FiCon.Models.Queue;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocketClient;

namespace FiCon.Middleware
{
    internal class Fiscalization
    {
        private readonly RequestDelegate _next;
        private readonly ISocketClient _socketClient;
        private readonly ILogger<Fiscalization> _logger;

        public Fiscalization(RequestDelegate next, ISocketClient socketClient, ILoggerFactory loggerFactory)
        {
            _next = next;

            _socketClient = socketClient;

            _logger = loggerFactory.CreateLogger<Fiscalization>();
        }

        public async Task InvokeAsync(HttpContext context, IOptionsSnapshot<HostConfig> snapshotOptionsAccessor)
        {
            try
            {
                var _hostConfig = snapshotOptionsAccessor.Value;
                // Todo implement authorization services here
                // Todo: implement connection check to see if the connection is alive.
                // if connection is active, don't create a new connection else create a new connection.
                _socketClient.Connect(_hostConfig.Port);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("{date}:{time} - {msg}:", DateTime.Today, DateTime.Now, ex.Message);
            }

            await _next(context);
        }
    }
}
