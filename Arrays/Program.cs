//Exercise 1:
//int[] temps = {22,25,19,21,28,24,26 };

//foreach (int temp in temps) 
//{
//    Console.WriteLine(temp);
//}

//int Avg = 0;
//for (int i = 0; i < temps.Length; i++) 
//{
//    Avg = temps.Sum() / temps.Length;
//}
//Console.WriteLine($"The average temperature is {Avg}");

//Console.WriteLine($"The maximum temperature is:{temps.Max()}");
//Console.WriteLine($"The minimum temperature is:{temps.Min()}");

//int Count = 0;
//for (int t = 0; t < temps.Length; t++) 
//{
//    if (temps[t]>25) 
//    {
//        Count++;
//    }

//}
//Console.WriteLine($"Only {Count} days was it above 25 degrees");

//Exercise 2:

//Console.WriteLine("Enter how many elements:");
//int size = int.Parse(Console.ReadLine());
//int[] numbers = new int[size];

//for (int i = 0; i < numbers.Length; i++) 
//{
//    Console.WriteLine($"Enter element {i}:");
//    // Convert string input to integer 
//    numbers[i] = int.Parse(Console.ReadLine());

//}
//Console.WriteLine("The numbers you entered are:");
//Console.WriteLine("----------------------------");


//foreach (int num in numbers) 
//{
//    Console.WriteLine(num);
//}
//Console.WriteLine("----------------------------");

//int avg = 0;
//for (int i = 0; i < numbers.Length; i++)
//{
//    avg = numbers.Sum() / numbers.Length;

//}
//Console.WriteLine($"The sum is {numbers.Sum()}");
//Console.WriteLine($"The average is {avg}");
//Console.WriteLine("----------------------------");

//for (int i = numbers.Length-1; i>=0; i--) 
//{
//    Console.WriteLine(numbers[i]);
//}
//Console.WriteLine("----------------------------");
//foreach (int num in numbers) 
//{
//    if (num % 2 == 0) 
//    {
//        Console.WriteLine($"{num} is even");
//    }
//    else 
//    {
//        Console.WriteLine($"{num} is odd");
//    }
//}

//Exercise 3:   

//int[] numbers = {1,2,3,5,6,7,8,9,10 };

//int n = numbers.Length + 1; // N = 10 because one number is missing

//int expectedSum = n*(n+1) /2; // Sum formula 1+2+...+N

//int actualSum = 0;
//for (int i = 0; i < numbers.Length; i++)
//{
//    actualSum += numbers[i];
//}
//int missingNumber = expectedSum - actualSum;
//Console.WriteLine("N= " + n);
//Console.WriteLine("Expected Sum(1 to "+ n +" ): " + expectedSum);
//Console.WriteLine("Actual Sum: " + actualSum);
//Console.WriteLine($"The missing number is {missingNumber}");

//Exercise 4:
//int[] marks = { 56,78,92,45,67,88,73,61 };
//Console.WriteLine("Enter the mark to search for:");
//int searchMark = int.Parse(Console.ReadLine());

//int firstIndex = -1;
//int count = 0;

//for (int i = 0; i < marks.Length; i++)
//{
//    if (marks[i]== searchMark) 
//    { 
//        if (firstIndex == -1) 
//        {
//            firstIndex = i;
//        }
//        count++;
//    }
//}
//if (firstIndex != -1)
//{
//    Console.WriteLine($"The first occurrence of {searchMark} is at index {firstIndex}");
//    Console.WriteLine($"The number {searchMark} appears {count} times in the array");
//}
//else
//{
//    Console.WriteLine($"The number {searchMark} is not found in the array");
//} 

// Exercise 5: y attempt
//int count = 0;
//int[] numbers = {-5,-12,-3,8,0,-1,7,4 };

//for (int i = 0; i < numbers.Length; i++) 
//{
//    if (numbers[i]>0) 
//    {
//        count++;
//    }

//}
//int[] postiveNumbers = new int[count];

//for (int j = 0; j < postiveNumbers.Length; j++)
//{
//    Console.WriteLine(postiveNumbers[j]);
//}

//Exercise 5 correction:
//int[] numbers = {-5,12,-3,8,0,-1,7,4 };

////Pass 1: Count how many positive numbers exists
//int positiveCount = 0;
//for (int i = 0; i < numbers.Length; i++) 
//{
//    if (numbers[i] > 0) 
//    {
//        positiveCount++;
//    }
//}

////Create the new array with the exact size needed
//int[] positives = new int[positiveCount];

////Pass 2: Fill the new array with positive numbers 
//int index = 0;
//for (int i=0;i<numbers.Length;i++) 
//{
//    if (numbers[i]>0) 
//    {
//        positives[index] = numbers[i];
//        index++;
//    }
//}

////Display the positive numbers
//Console.Write("Positive numbers:");
//for (int i =0;i<positives.Length;i++) 
//{
//    if (i < positives.Length - 1)
//    {
//        Console.Write(positives[i] + ", ");
//    }
//    else 
//    {
//        Console.Write(positives[i]);// No comma after last element
//    }
//}
//Console.WriteLine();

////Calculate and display the average
//int sum = 0;
//for (int i = 0; i < positives.Length; i++) 
//{
//    sum += positives[i];
//}
//double average = positives.Sum()/positives.Length;

//Console.WriteLine($"Count of positive numbers: {positiveCount}");
//Console.WriteLine($"Sum of positive numbers: {sum}");
//Console.WriteLine($"Average of positive numbers:{average}");

//Exercise 6:
int[] scores = new int[10];
// Input: Read 10 exam scores from the user
Console.WriteLine("Enter 10 exam scores(0-100)");
for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine("Score" + (i+1)+ ": ");
    scores[i] = int.Parse(Console.ReadLine());
}

//Pass 1 Calculate the average 
double average = scores.Sum()/scores.Length;

Console.WriteLine();
Console.WriteLine("Average score: " + average);

//Pass 2: Count and display scores above average
int aboveCount = 0;
for (int i = 0; i < scores.Length; i++)
{
    if (scores[i]>average) 
    {
        aboveCount++;
        Console.WriteLine(scores[i] + " ");
    }
}
Console.WriteLine();

// Final result
if (aboveCount == 0)
{
    Console.WriteLine("No scores are above the average");
}
else
{
    Console.WriteLine($"Number of scores above average are: {aboveCount}");
}
