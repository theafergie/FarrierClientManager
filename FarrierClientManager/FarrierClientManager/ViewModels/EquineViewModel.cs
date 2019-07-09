using SQLite;

namespace FarrierClientManager.ViewModels
{
    public class EquineViewModel : ViewModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string ShoeSize { get; set; }
        public string ShoeType { get; set; }
        public string Owner { get; set; }
    }
}
