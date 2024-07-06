using AdminNamespace;
using PostNamespace;
using UserNamespace;

public class Program
{
    static List<User> users = new List<User>();
    static List<Admin> admins = new List<Admin>();
    static List<Post> posts = new List<Post>();

    public static void Main()
    {
       
        users.Add(new User { Id = 1, Name = "John", Surname = "Doe", Age = 25, Email = "john@example.com", Password = "password" });
        admins.Add(new Admin { Id = 1, Username = "admin", Email = "admin@example.com", Password = "admin" });

        Console.WriteLine("Are you a User or Admin?");
        string role = Console.ReadLine().ToLower();

        Console.WriteLine("Enter Email:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();

        if (role == "user")
        {
            User user = users.Find(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                UserMenu(user);
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }
        else if (role == "admin")
        {
            Admin admin = admins.Find(a => a.Email == email && a.Password == password);
            if (admin != null)
            {
                AdminMenu(admin);
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }
        else
        {
            Console.WriteLine("Invalid role");
        }
    }

    static void UserMenu(User user)
    {
        while (true)
        {
            Console.WriteLine("1. View posts");
            Console.WriteLine("2. Like post");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter post ID to view:");
                int postId = int.Parse(Console.ReadLine());
                Post post = posts.Find(p => p.Id == postId);
                if (post != null)
                {
                    Admin admin = admins[0];
                    post.ViewPost(admin);
                    Console.WriteLine(post.Content);
                }
                else
                {
                    Console.WriteLine("Post not found");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter post ID to like:");
                int postId = int.Parse(Console.ReadLine());
                Post post = posts.Find(p => p.Id == postId);
                if (post != null)
                {
                    Admin admin = admins[0];
                    post.LikePost(admin);
                }
                else
                {
                    Console.WriteLine("Post not found");
                }
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }

    static void AdminMenu(Admin admin)
    {
        while (true)
        {
            Console.WriteLine("1. View notifications");
            Console.WriteLine("2. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                foreach (var notification in admin.Notifications)
                {
                    Console.WriteLine($"{notification.DateTime}: {notification.Text}");
                }
            }
            else if (choice == "2")
            {
                break;
            }
        }
    }
}
