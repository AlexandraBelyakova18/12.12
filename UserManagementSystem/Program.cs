using System;

class Program
{
    static void Main(string[] args)
    {
        UserService userService = new UserService();

        while (true)
        {
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Read Users");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    var email = Console.ReadLine();
                    var newUser = userService.Create(name, email);
                    Console.WriteLine($"User created with ID: {newUser.Id}");
                    break;

                case "2":
                    var users = userService.GetAll();
                    Console.WriteLine("Users:");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
                    }
                    break;

                case "3":

                    Console.Write("Enter User ID to Update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("Enter New Name: ");
                        var newName = Console.ReadLine();
                        Console.Write("Enter New Email: ");
                        var newEmail = Console.ReadLine();
                        var updatedUser = userService.Update(updateId, newName, newEmail);
                        if (updatedUser != null)
                        {
                            Console.WriteLine($"User {updatedUser.Id} updated.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                    }
                    break;

                case "4":
                    Console.Write("Enter User ID to Delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        var success = userService.Delete(deleteId);
                        if (success)
                        {
                            Console.WriteLine("User deleted.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine(); // Just to add a blank line for better readability
        }
    }
}
