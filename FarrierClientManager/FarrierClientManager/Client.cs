using SQLite;
using System.Collections.ObjectModel;

namespace FarrierClientManager
{
    public class Client
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

       // private SQLiteAsyncConnection _connection;
       // private ObservableCollection<Client> _clients;

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
