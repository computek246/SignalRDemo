namespace Notification.DAL.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
