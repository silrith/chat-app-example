namespace chatting_api.Models;

public class Message
{
    public int Id { get; set; }
    public string Sender { get; set; } // Mesajı gönderen kullanıcı adı
    public string Content { get; set; } // Mesaj içeriği
    public DateTime Timestamp { get; set; } // Mesaj gönderim zamanı
}
