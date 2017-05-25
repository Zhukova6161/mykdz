using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mashaProject
{
    class User
    {
        private Int32 userId;
        public Int32 UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }
        private String username;
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }

        }
        private String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }

        }
    }
}
