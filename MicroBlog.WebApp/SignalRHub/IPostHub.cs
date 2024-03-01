namespace MicroBlog.WebApp.SignalRHub
{
    public interface IPostHub
    {
        Task SendPostUpdateEvent();
    }
}
