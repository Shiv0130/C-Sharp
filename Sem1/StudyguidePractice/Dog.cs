<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public  class Dog: Animal
    {
        public void Display() 
        {


            //Console.WriteLine(Name); //(a) This will work because Name is a public property in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.
            //Console.WriteLine(Age); //(b) This will cause an error because Age is a private field in the Animal class and cannot be accessed directly from the Dog class.
            //Console.WriteLine(Species); //(c) This will work because Species is a protected field in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.

        }
        public override void Speak()
        {
            Console.WriteLine("Dog barks");
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public  class Dog: Animal
    {
        public void Display() 
        {


            //Console.WriteLine(Name); //(a) This will work because Name is a public property in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.
            //Console.WriteLine(Age); //(b) This will cause an error because Age is a private field in the Animal class and cannot be accessed directly from the Dog class.
            //Console.WriteLine(Species); //(c) This will work because Species is a protected field in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.

        }
        public override void Speak()
        {
            Console.WriteLine("Dog barks");
        }
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
