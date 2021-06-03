using System.ComponentModel.DataAnnotations.Schema;

namespace Notification.DAL.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl  { get; set; }


        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}".Trim();
    }
}
