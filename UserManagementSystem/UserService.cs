using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class UserService
{
    private List<User> users = new List<User>();
    private int nextId = 1;
    private const string filePath = "users.json"; // файл для хранения пользователей

    public UserService()
    {
        LoadUsers(); // Загружаем пользователей при инициализации
    }

    // Create
    public User Create(string name, string email)
    {
        var user = new User { Id = nextId++, Name = name, Email = email };
        users.Add(user);
        SaveUsers(); // Сохраняем пользователей после добавления нового
        return user;
    }

    // Read all users
    public List<User> GetAll()
    {
        return users;
    }

    // Read user by ID
    public User GetById(int id)
    {
        return users.SingleOrDefault(u => u.Id == id);
    }

    // Update
    public User Update(int id, string name, string email)
    {
        var user = GetById(id);
        if (user != null)
        {
            user.Name = name;
            user.Email = email;
            SaveUsers(); // Сохраняем пользователей после обновления
            return user;
        }
        return null;
    }

    // Delete
    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user != null)
        {
            users.Remove(user);
            SaveUsers(); // Сохраняем пользователей после удаления
            return true;
        }
        return false;
    }

    // Сохранение пользователей в файл
    private void SaveUsers()
    {
        File.WriteAllText(filePath, JsonConvert.SerializeObject(users));
    }

    // Загрузка пользователей из файла
    private void LoadUsers()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<User>>(json);
            nextId = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1; // Устанавливаем следующий ID
        }
    }
}
