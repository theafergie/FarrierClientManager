using SQLite;

namespace FarrierClientManager.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string CityZip
        {
            get { return $"{City}, {Zip}"; }
        }
    }
}
