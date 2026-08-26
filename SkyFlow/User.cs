<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public abstract class User
    {
        //Private backing fields - encapsulatoin
        private int _userId;
        private string _userName = "";
        private string _role = "";

        //Public properties - controlled access
        public int UserId { get => _userId; set => _userId = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Role { get => _role; set => _role = value; }

        public string Email { get; set; } = "";

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        //Full name helper
        public string FullName => $"{FirstName} {LastName}".Trim();

        // Abstract method

        public abstract void DisplayDashboard();
        public void DisplayWelcome() 
        {
            Console.WriteLine($"\nWelcome, {FullName} [{Role}]");
        }


    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public abstract class User
    {
        //Private backing fields - encapsulatoin
        private int _userId;
        private string _userName = "";
        private string _role = "";

        //Public properties - controlled access
        public int UserId { get => _userId; set => _userId = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Role { get => _role; set => _role = value; }

        public string Email { get; set; } = "";

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        //Full name helper
        public string FullName => $"{FirstName} {LastName}".Trim();

        // Abstract method

        public abstract void DisplayDashboard();
        public void DisplayWelcome() 
        {
            Console.WriteLine($"\nWelcome, {FullName} [{Role}]");
        }


    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
