using Microsoft.AspNetCore.SignalR;

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
