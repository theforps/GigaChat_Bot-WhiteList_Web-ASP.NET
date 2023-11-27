using Microsoft.EntityFrameworkCore;
using YandexGPT_bot.models;
using YandexGPT_bot.repositories.interfaces;

namespace YandexGPT_bot.repositories.impl;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _db = new();

    public async Task<User> getUserByUsername(string? username)
    {
        return await _db.users.FirstOrDefaultAsync(x => x.Username.Equals(username));
    }

    public async Task addUser(User user)
    {
        await _db.users.AddAsync(user);
        await _db.SaveChangesAsync();
    }

    public async Task<List<History>> getHistory(int userId)
    {
        return await _db.history.Where(x => x.User.Id == userId).ToListAsync();
    }

    public async Task addHistory(History history)
    {
        await _db.history.AddAsync(history);
        await _db.SaveChangesAsync();
    }

    public async Task<User> getUserById(int id)
    {   
        return await _db.users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task clearHistory(string username)
    {
        var history = _db.history.Where(x => x.User.Username.Equals(username)).ToArray();

        if(history.Length > 0)
        {
            _db.history.RemoveRange(history);
            await _db.SaveChangesAsync();
        }
    }
}