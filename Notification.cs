﻿namespace NotificationNamespace;

public class Notification
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public UserNamespace.User FromUser { get; set; }
}
