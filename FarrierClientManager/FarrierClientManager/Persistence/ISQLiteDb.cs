using SQLite;

namespace FarrierClientManager.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
