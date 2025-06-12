using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;

namespace TheWeatherApp.Database;

using SQLite;

#if DEBUG
using System.Diagnostics;
#endif

public class SqLiteRepository : IRepository
{
    readonly SQLiteAsyncConnection connection;

    public SqLiteRepository()
    {
        connection = App.SQLConnection;

        CreateTables().ConfigureAwait(false);
    }

    public async Task<bool> SaveData<T>(T toStore)
    {
        var rv = false;
        try
        {
            await connection.InsertOrReplaceAsync(toStore);
            rv = true;
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine(ex.Message);
#endif
        }

        return rv;
    }

    public async Task SaveListData<T>(List<T> toStore)
    {
        try
        {
            foreach (var ts in toStore)
            {
                await connection.InsertOrReplaceAsync(ts);
            }
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"{ex.Message}--{ex.InnerException?.Message}");
#endif
        }
    }

    public async Task<int> Count<T>() where T : class, new()
    {
        var data = await GetList<T>();
        return data.Count;
    }

    public async Task<List<T>> GetList<T>(int top = 0) where T : class, new()
    {
        var sql = string.Format("SELECT * FROM {0}", GetName(typeof(T).ToString()));
        try
        {
            var list = await connection.QueryAsync<T>(sql, string.Empty);
            if (list.Count != 0)
            {
                if (top != 0)
                {
                    list = list.Take(top).ToList();
                }
            }

            return list;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error - {ex.Message}, Inner = {ex.InnerException?.Message}");
            return new List<T>();
        }
    }

    public async Task<List<T>> GetList<T, TU>(string para, TU val, int top = 0) where T : class, new()
    {
        var sql = string.Format("SELECT * FROM {0} WHERE {1}=?", GetName(typeof(T).ToString()), para);
        var list = await connection.QueryAsync<T>(sql, val);
        if (list.Count != 0)
        {
            if (top != 0)
            {
                list = list.Take(top).ToList();
            }
        }

        return list;
    }

    public async Task<T?> GetData<T>() where T : class, new()
    {
        var sql = string.Format("SELECT * FROM {0}", GetName(typeof(T).ToString()));
        var list = await connection.QueryAsync<T>(sql, string.Empty);
        return list != null ? list.FirstOrDefault() : default;
    }

    public async Task<T?> GetData<T, TU>(string para, TU val) where T : class, new()
    {
        var sql = string.Format("SELECT * FROM {0} WHERE {1}=?", GetName(typeof(T).ToString()), para);
        var list = await connection.QueryAsync<T>(sql, val);
        return list != null ? list.FirstOrDefault() : default;
    }

    async Task CreateTables()
    {
        try
        {
            await connection.CreateTableAsync<Route>();
            await connection.CreateTableAsync<Time>();
            await connection.CreateTableAsync<Times>();
            await connection.CreateTableAsync<TimesMaster>();
            await connection.CreateTableAsync<Timetable>();
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"{ex.Message}--{ex.InnerException?.Message}");
#endif
        }
    }

    public async Task DeleteAll()
    {
        try
        {
            await connection.DeleteAllAsync<Route>();
            await connection.DeleteAllAsync<Time>();
            await connection.DeleteAllAsync<Times>();
            await connection.DeleteAllAsync<TimesMaster>();
            await connection.DeleteAllAsync<Timetable>();
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"{ex.Message}--{ex.InnerException?.Message}");
#endif
        }

    }

    public async Task Delete<T>(T stored)
    {
        try
        {
            await connection.DeleteAsync(stored);
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"{ex.Message}--{ex.InnerException?.Message}");
#endif
        }
    }

    public async Task DeleteList<T>(List<T> list)
    {
        try
        {
            foreach (var l in list)
                await connection.DeleteAsync(l);
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine($"{ex.Message}--{ex.InnerException?.Message}");
#endif
        }
    }

    public async Task<T?> GetData<T, TU, TV>(string para1, TU val1, string para2, TV val2) where T : class, new()
    {
        var sql = string.Format("SELECT * FROM {0} WHERE {1}=? AND {2}=?", GetName(typeof(T).ToString()), para1, para2);
        var list = await connection.QueryAsync<T>(sql, val1, val2);
        return list != null ? list.FirstOrDefault() : default;
    }

    public async Task<int> GetID<T>() where T : class, new()
    {
        string sql = string.Format("SELECT last_insert_rowid() FROM {0}", GetName(typeof(T).ToString()));
        var id = await connection.ExecuteScalarAsync<int>(sql, string.Empty);
        return id;
    }

    string GetName(string name)
    {
        var list = name.Split('.').ToList();
        if (list.Count == 1)
        {
            return list[0];
        }

        return list[^1];
    }

    public async Task<int> Count<T, U>(string p, U val) where T : class, new()
    {
        var sql = string.Format("SELECT * FROM {0} WHERE {1}={2}", GetName(typeof(T).ToString()), p, val);
        var list = await connection.QueryAsync<T>(sql, string.Empty);
        return list.Count;
    }
}