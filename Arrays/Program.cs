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
//int[] marks = { 56, 78, 92, 45, 67, 88, 73, 61 };
//Console.WriteLine("Enter the mark to search for:");
//int searchMark = int.Parse(Console.ReadLine());

//int firstIndex = -1;
//int count = 0;

//for (int i = 0; i < marks.Length; i++)
//{
//    if (marks[i] == searchMark)
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
//int[] scores = new int[10];
//// Input: Read 10 exam scores from the user
//Console.WriteLine("Enter 10 exam scores(0-100)");
//for (int i = 0; i < scores.Length; i++)
//{
//    Console.WriteLine("Score" + (i+1)+ ": ");
//    scores[i] = int.Parse(Console.ReadLine());
//}

////Pass 1 Calculate the average 
//double average = scores.Sum()/scores.Length;

//Console.WriteLine();
//Console.WriteLine("Average score: " + average);

////Pass 2: Count and display scores above average
//int aboveCount = 0;
//for (int i = 0; i < scores.Length; i++)
//{
//    if (scores[i]>average) 
//    {
//        aboveCount++;
//        Console.WriteLine(scores[i] + " ");
//    }
//}
//Console.WriteLine();

//// Final result
//if (aboveCount == 0)
//{
//    Console.WriteLine("No scores are above the average");
//}
//else
//{
//    Console.WriteLine($"Number of scores above average are: {aboveCount}");
//}

//Exercise 7:
//Original array
//int[] nums = { 2, 5, 7, 1, 8 };
//foreach (int num in nums) 
//{
//    Console.Write(num + " ");
//}
//Console.WriteLine();

//int square = 0;
//for (int i =0;i<nums.Length;i++) 
//{ 
//    square = nums[i] * nums[i];
//    Console.Write(square + " ");
//}
//Console.WriteLine();

//Exercise 8:
//int temp = 0;
//int[] arr = { 10, 20, 30, 40, 50 };
//Console.WriteLine("Original array before rotation:");
//foreach (int num in arr) 
//{
//    Console.Write(num + " ");
//} 
//Console.WriteLine();

//// Rotate right by 1 position
//temp = arr[arr.Length - 1];
//for (int i = arr.Length - 1; i > 0; i--)
//{
//    arr[i] = arr[i - 1];
//}
//arr[0] = temp;

//Console.WriteLine("Array after rotation:");
//foreach (int num in arr)
//{
//    Console.Write(num + " ");
//}
//Console.WriteLine();

//Exercise 9:
//int[] nums = { 4, 2, 7, 2, 9, 4, 1, 7 };

//// --- Display the original array ---
//Console.Write("Original array:      ");
//for (int i = 0; i < nums.Length; i++)
//{
//    if (i < nums.Length - 1)
//        Console.Write(nums[i] + ", ");
//    else
//        Console.Write(nums[i]);
//}
//Console.WriteLine();

//// --- Pass 1: Count how many unique values exist ---
//int uniqueCount = 0;
//for (int i = 0; i < nums.Length; i++)
//{
//    bool alreadySeen = false;

//    for (int j = 0; j < i; j++)   // only check elements BEFORE i
//    {
//        if (nums[j] == nums[i])
//        {
//            alreadySeen = true;
//            break;
//        }
//    }

//    if (!alreadySeen)
//    {
//        uniqueCount++;
//    }
//}

//// --- Create the unique array with the exact size needed ---
//int[] unique = new int[uniqueCount];

//// --- Pass 2: Fill the unique array ---
//int index = 0;
//for (int i = 0; i < nums.Length; i++)
//{
//    bool alreadySeen = false;

//    for (int j = 0; j < i; j++)   // only check elements BEFORE i
//    {
//        if (nums[j] == nums[i])
//        {
//            alreadySeen = true;
//            break;
//        }
//    }

//    if (!alreadySeen)
//    {
//        unique[index] = nums[i];
//        index++;
//    }
//}

//// --- Display the deduplicated array ---
//Console.Write("Deduplicated array:  ");
//for (int i = 0; i < unique.Length; i++)
//{
//    if (i < unique.Length - 1)
//        Console.Write(unique[i] + ", ");
//    else
//        Console.Write(unique[i]);
//}
//Console.WriteLine();

//Console.WriteLine("Original length:     " + nums.Length);
//Console.WriteLine("Unique length:       " + unique.Length);

//Exercise 10: 
//int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

//int rows = matrix.GetLength(0);    // number of rows    = 3
//int cols = matrix.GetLength(1);    // number of columns = 3

//// --- Display the matrix in grid format ---
//Console.WriteLine("Matrix:");
//for (int i = 0; i < rows; i++)
//{
//    for (int j = 0; j < cols; j++)
//    {
//        Console.Write(matrix[i, j] + "\t");
//    }
//    Console.WriteLine();
//}

//// --- Total sum of all elements ---
//int totalSum = 0;
//for (int i = 0; i < rows; i++)
//{
//    for (int j = 0; j < cols; j++)
//    {
//        totalSum += matrix[i, j];
//    }
//}
//Console.WriteLine();
//Console.WriteLine("Sum of all elements: " + totalSum);

//// --- Sum of each row ---
//Console.WriteLine();
//Console.WriteLine("Row sums:");
//for (int i = 0; i < rows; i++)
//{
//    int rowSum = 0;
//    for (int j = 0; j < cols; j++)
//    {
//        rowSum += matrix[i, j];
//    }
//    Console.WriteLine("  Row " + (i + 1) + ": " + rowSum);
//}

//// --- Sum of each column ---
//Console.WriteLine();
//Console.WriteLine("Column sums:");
//for (int j = 0; j < cols; j++)
//{
//    int colSum = 0;
//    for (int i = 0; i < rows; i++)
//    {
//        colSum += matrix[i, j];
//    }
//    Console.WriteLine("  Column " + (j + 1) + ": " + colSum);
//}

//Exercise 11:
// --- Declare and initialise the jagged array ---
//int[][] grades = new int[3][];

//grades[0] = new int[] { 80, 90, 85 };
//grades[1] = new int[] { 75, 88 };
//grades[2] = new int[] { 95, 92, 87, 91 };

//int highestGrade = 0;

//// --- Loop through each student ---
//for (int i = 0; i < grades.Length; i++)
//{
//    int sum = 0;

//    Console.Write("Student " + (i + 1) + " grades: ");

//    for (int j = 0; j < grades[i].Length; j++)
//    {
//        // Display grade
//        if (j < grades[i].Length - 1)
//            Console.Write(grades[i][j] + ", ");
//        else
//            Console.Write(grades[i][j]);

//        // Accumulate sum
//        sum += grades[i][j];

//        // Track highest grade across all students
//        if (grades[i][j] > highestGrade)
//        {
//            highestGrade = grades[i][j];
//        }
//    }

//    double average = (double)sum / grades[i].Length;

//    Console.WriteLine();
//    Console.WriteLine("Student " + (i + 1) + " average: " + average);
//    Console.WriteLine();
//}

//// --- Display the highest grade found ---
//Console.WriteLine("Highest grade across all students: " + highestGrade);

//Exercise 12:
//int[] arr1 = { 2, 5, 8, 12 };
//int[] arr2 = { 3, 7, 9, 11, 14 };

//int[] merged = new int[arr1.Length + arr2.Length];

//// --- Two-pointer merge ---
//int i = 0;   // pointer for arr1
//int j = 0;   // pointer for arr2
//int k = 0;   // pointer for merged

//while (i < arr1.Length && j < arr2.Length)
//{
//    if (arr1[i] <= arr2[j])
//    {
//        merged[k] = arr1[i];
//        i++;
//    }
//    else
//    {
//        merged[k] = arr2[j];
//        j++;
//    }
//    k++;
//}

//// --- Copy any remaining elements from arr1 ---
//while (i < arr1.Length)
//{
//    merged[k] = arr1[i];
//    i++;
//    k++;
//}

//// --- Copy any remaining elements from arr2 ---
//while (j < arr2.Length)
//{
//    merged[k] = arr2[j];
//    j++;
//    k++;
//}

//// --- Display all three arrays ---
//Console.Write("Array 1:       ");
//for (int x = 0; x < arr1.Length; x++)
//{
//    if (x < arr1.Length - 1)
//        Console.Write(arr1[x] + ", ");
//    else
//        Console.Write(arr1[x]);
//}
//Console.WriteLine();

//Console.Write("Array 2:       ");
//for (int x = 0; x < arr2.Length; x++)
//{
//    if (x < arr2.Length - 1)
//        Console.Write(arr2[x] + ", ");
//    else
//        Console.Write(arr2[x]);
//}
//Console.WriteLine();

//Console.Write("Merged array:  ");
//for (int x = 0; x < merged.Length; x++)
//{
//    if (x < merged.Length - 1)
//        Console.Write(merged[x] + ", ");
//    else
//        Console.Write(merged[x]);
//}
//Console.WriteLine();

//Console.WriteLine("Merged length: " + merged.Length);

//Mini project:

//double[] sales = new double[7];
//string[] dayNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

//// --- Input: Read and validate 7 days of sales ---
//Console.WriteLine("===== SHOP SALES ENTRY =====");
//for (int i = 0; i < sales.Length; i++)
//{
//    Console.Write("Enter sales for " + dayNames[i] + ": R ");
//    sales[i] = double.Parse(Console.ReadLine());

//    while (sales[i] < 0)
//    {
//        Console.WriteLine("  Invalid! Sales cannot be negative. Please try again.");
//        Console.Write("Enter sales for " + dayNames[i] + ": R ");
//        sales[i] = double.Parse(Console.ReadLine());
//    }
//}

//// --- Total and Average ---
//double total = 0;
//for (int i = 0; i < sales.Length; i++)
//{
//    total += sales[i];
//}
//double average = total / sales.Length;

//// --- Highest and Lowest day ---
//int highestIndex = 0;
//int lowestIndex = 0;

//for (int i = 1; i < sales.Length; i++)
//{
//    if (sales[i] > sales[highestIndex])
//        highestIndex = i;

//    if (sales[i] < sales[lowestIndex])
//        lowestIndex = i;
//}

//// --- Count days above average ---
//int aboveAverage = 0;
//for (int i = 0; i < sales.Length; i++)
//{
//    if (sales[i] > average)
//        aboveAverage++;
//}

//// --- Sort a copy from highest to lowest (Bubble Sort) ---
//double[] sorted = new double[sales.Length];
//for (int i = 0; i < sales.Length; i++)
//{
//    sorted[i] = sales[i];
//}

//for (int i = 0; i < sorted.Length - 1; i++)
//{
//    for (int j = 0; j < sorted.Length - 1 - i; j++)
//    {
//        if (sorted[j] < sorted[j + 1])
//        {
//            double temp = sorted[j];
//            sorted[j] = sorted[j + 1];
//            sorted[j + 1] = temp;
//        }
//    }
//}

//// --- Display the full report ---
//Console.WriteLine();
//Console.WriteLine("========================================");
//Console.WriteLine("         WEEKLY SALES REPORT            ");
//Console.WriteLine("========================================");

//Console.WriteLine();
//Console.WriteLine("----- Daily Sales Entered -----");
//for (int i = 0; i < sales.Length; i++)
//{
//    Console.WriteLine("  " + dayNames[i] + ": \t R " + sales[i].ToString("F2"));
//}

//Console.WriteLine();
//Console.WriteLine("----- Summary -----");
//Console.WriteLine("  Total sales for the week:    R " + total.ToString("F2"));
//Console.WriteLine("  Average daily sales:         R " + average.ToString("F2"));
//Console.WriteLine("  Highest sales day:           " + dayNames[highestIndex] + " (R " + sales[highestIndex].ToString("F2") + ")");
//Console.WriteLine("  Lowest sales day:            " + dayNames[lowestIndex] + " (R " + sales[lowestIndex].ToString("F2") + ")");
//Console.WriteLine("  Days above average:          " + aboveAverage + " day(s)");

//Console.WriteLine();
//Console.WriteLine("----- Sales Ranked Highest to Lowest -----");
//for (int i = 0; i < sorted.Length; i++)
//{
//    Console.WriteLine("  " + (i + 1) + ". R " + sorted[i].ToString("F2"));
//}

//Console.WriteLine();
//Console.WriteLine("========================================");
