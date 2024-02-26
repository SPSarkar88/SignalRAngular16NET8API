namespace MicroBlog.API.SignalRHub
{
    public interface IPostHub
    {
        Task SendPostUpdateEvent();
    }
}
