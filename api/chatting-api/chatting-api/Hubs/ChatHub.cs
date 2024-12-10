namespace chatting_api.Hubs;

public class ChatHub : Hub
{
    // Mesaj gönderme metodu
    public async Task SendMessage(string user, string message)
    {
        // Tüm bağlı istemcilere mesaj gönder
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
