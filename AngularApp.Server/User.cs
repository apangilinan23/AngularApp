using Microsoft.Identity.Client;

namespace AngularApp.Server
{
    public class User
    {
        public string UserName { get; set; }

        public byte[] Password { get; set; }

        public int Id { get; set; }
    }
}
