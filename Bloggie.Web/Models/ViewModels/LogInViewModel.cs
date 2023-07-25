namespace Bloggie.Web.Models.ViewModels
{
    public class LogInViewModel
    {
        public string UserName { get; set; }
     
        public string Password { get; set; }
        
        public string? ReturnUrl { get; set; }
    }
}
