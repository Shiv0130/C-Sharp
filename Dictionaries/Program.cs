//Dictionary- stores data in pairs

//first data type keys are strings and second data type values are integers
//Dictionary<string, int> ageDictionary = new Dictionary<string, int>()
//{
//    {"Alice", 30 },
//    {"Bob",25 },
//    {"Charlie", 35 }
//};
//ageDictionary.Add("Diana", 40); // Adding a new user
//Console.WriteLine("Alices's age:" + ageDictionary);

//ageDictionary.Remove("Bob"); // Removing Bob
//Console.WriteLine("Contains Alice:" + ageDictionary);

//Dictionary<int, string> myDictionary = new Dictionary<int, string>();

//myDictionary.Add(1,"Something");
//myDictionary.Add(5, "Something");
//myDictionary.Add(9, "Something");

//foreach (var item in myDictionary) 
//{
//    Console.WriteLine(item);
//}

Dictionary<int, string> myDictionary = new Dictionary<int, string>();

myDictionary.Add(1, "Something");
myDictionary.Add(5, "Something");
myDictionary.Add(9, "Something");

foreach (var item in myDictionary)
{
    if (item.Key == 5) 
    {
        Console.WriteLine(item.Value);   
    } else 
    {
        Console.WriteLine(item.Key);
    }

}



