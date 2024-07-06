namespace PostNamespace
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }

        public void ViewPost(AdminNamespace.Admin admin)
        {
            ViewCount++;
            var notification = new NotificationNamespace.Notification
            {
                Id = new Random().Next(1, 1000),
                Text = "Post viewed",
                DateTime = DateTime.Now,
                FromUser = null 
            };
            admin.ReceiveNotification(notification);
        }

        public void LikePost(AdminNamespace.Admin admin)
        {
            LikeCount++;
            var notification = new NotificationNamespace.Notification
            {
                Id = new Random().Next(1, 1000),
                Text = "Post liked",
                DateTime = DateTime.Now,
                FromUser = null 
            };
            admin.ReceiveNotification(notification);
        }
    }
}
}
