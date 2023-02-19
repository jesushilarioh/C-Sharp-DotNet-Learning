namespace minimalApiExample1.DB;

public record User
{
    public int Id { get; set; }
    public string ? Name {get; set; }
}

public class UserDB
{
    private static List<User> _users = new List<User>()
    {
        new User { Id = 1, Name = "Jesus" },
        new User { Id = 2, Name = "Christina" },
        new User { Id = 3, Name = "Francesca" },
        new User { Id = 4, Name = "Michael" }
    };

    public static List<User> GetUsers()
    {
        return _users;
    }
    public static User ? GetUser(int id)
    {
        return _users.SingleOrDefault(user => user.Id == id);
    }
    
    public static User CreateUser(User user)
    {
        _users.Add(user);
        return user;
    }

    public static User UpdateUser(User updatedUser)
    {
        _users = _users.Select(user =>
        {
            if (user.Id == updatedUser.Id)
            {
                user.Name = updatedUser.Name;
            }
            return user;

        }).ToList();

        return updatedUser;
    }
    
    public static void RemoveUser(int id)
    {
        _users = _users.FindAll(user => user.Id != id).ToList();
    }
}