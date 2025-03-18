namespace WebApp.Models
{
    public class CustomerDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
