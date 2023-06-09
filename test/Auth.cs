using System;
namespace test
{
    public class Auth
    {
        public Auth()
        {
        }

        public bool Login(string username, string password)
        {
            if (username == "David" && password == "123")
            {
                return true;
            }
            return false;
        }
    }

    class Test
    {
        public void Main()
        {

        }
    }
}

