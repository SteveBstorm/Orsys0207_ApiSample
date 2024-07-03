using ApiSample.Models;

namespace ApiSample.Services
{
    public class UserService
    {
        public List<User> liste { get; set; }

        public UserService()
        {
            liste = new List<User>();
            liste.Add(new User
            {
                Id = 1,
                Email = "admin@mail.com",
                Password = "Test1234",
                UserName = "Administrator",
                IsAdmin = true
            });
            liste.Add(new User
            {
                Id = 2,
                Email = "user@mail.com",
                Password = "Test1234",
                UserName = "Sample User",
                IsAdmin = false
            });
        }

        public User? Login(string email, string password)
        {
            return liste.FirstOrDefault(x => x.Password == password && x.Email == email);
        }
    }
}
