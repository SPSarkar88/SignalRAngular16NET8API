using MicroBlog.API.Models;
using MicroBlog.API.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace MicroBlog.API.SignalRHub
{
    public class PostHub : Hub, IPostHub
    {
        private readonly IHubContext<PostHub> hubContext;
        public PostHub(IHubContext<PostHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task SendPostUpdateEvent()
        {
            await hubContext.Clients.All.SendAsync("ReceivePost");
        }
    }
}
