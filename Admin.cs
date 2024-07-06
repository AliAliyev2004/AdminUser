namespace AdminNamespace;

public class Admin
{

    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<PostNamespace.Post> Posts { get; set; } = new List<PostNamespace.Post>();
    public List<NotificationNamespace.Notification> Notifications { get; set; } = new List<NotificationNamespace.Notification>();

    public void ReceiveNotification(NotificationNamespace.Notification notification)
    {
        Notifications.Add(notification);
        
    }


}
