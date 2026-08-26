// What is a hashset and why do we need it?
// A HashSet is a collection that contains no duplicate elements and provides high-performance set operations.
// It is part of the System.Collections.Generic namespace in C#.

//Sets C#
HashSet<int> numbers = new HashSet<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(1);

HashSet<int> numbers1 = new HashSet<int>();
numbers1.Add(11);
numbers1.Add(12);
numbers1.Add(13);
numbers1.Add(14);
numbers1.Add(1);
numbers.Add(2);

numbers.UnionWith(numbers1); // Adds the elements of numbers1 to numbers, ignoring duplicates
numbers.IntersectWith(numbers1); // Keeps only the elements that are also in numbers1

numbers.ExceptWith(numbers1); // Removes the elements of numbers1 from numbers
numbers.SymmetricExceptWith(numbers1); // Keeps only the elements that are in either numbers or numbers1, but not both in this case it will keep 2,3,4,11,12,13,14

bool isSubset = numbers.IsSubsetOf(numbers1); // Checks if numbers is a subset of numbers1
bool isSuperSet = numbers.IsSupersetOf(numbers1); // Checks if numbers is a superset of numbers1
bool overlaps = numbers.Overlaps(numbers1); // Checks if numbers and numbers1 share any elements

//How does overlap function and intersect differ from each other? 
// The `Overlaps` function and the `IntersectWith` function in a HashSet serve different purposes:
// - `Overlaps` checks if there is any common element between two sets and returns a boolean value.
// - `IntersectWith` modifies the current set to keep only the elements that are also in another set.

foreach (int number in numbers) 
{
    Console.WriteLine(number); // Prints the elements of the numbers HashSet after performing the set operations

}

for (int n=0; n<numbers1.Count;n++) 
{
    Console.WriteLine(numbers1.ElementAt(n)); // Prints the elements of the numbers1 HashSet using a for loop and ElementAt method
}

