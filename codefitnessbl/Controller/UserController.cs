using System;

namespace codefitnessbl.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(User User)
        {
            User = User;
        }
        public bool Save()
    }
}
