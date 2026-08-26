//// CompanyDepts
//// ── Bring the Dictionaries namespace into scope ──────────────
//// This lets us use StaffMember without writing Dictionaries.StaffMember
//using Dictionaries;

//// ── The main dictionary ──────────────────────────────────────
//// string              = department name (the KEY)
//// List<StaffMember>   = all employees in that dept (the VALUE)
//// We start with an empty dictionary – no departments yet
//Dictionary<string, List<StaffMember>> staffDictionary = new Dictionary<string, List<StaffMember>>();


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 1 – Add a department
////  Parameter : deptName  – the department name to add
////
////  Logic:
////    Before adding, check if the key already exists.
////    ContainsKey() returns true if the key is found.
////    If it does NOT exist → create it with an empty employee list
////    If it DOES exist     → warn the user, do nothing
////
////  Expected outcomes:
////    AddDepartment("IT")  → "Department 'IT' added."
////    AddDepartment("IT")  → "Department 'IT' already exists."  (duplicate blocked)
//// ════════════════════════════════════════════════════════════
//void AddDepartment(string deptName)
//{
//    if (!staffDictionary.ContainsKey(deptName))
//    {
//        // The ! means NOT – so this block runs when dept does NOT exist yet
//        // We create the key and assign an empty List as its value.
//        // The list starts empty because no staff have been added yet.
//        staffDictionary[deptName] = new List<StaffMember>();
//        Console.WriteLine($"Department '{deptName}' added.");
//        // e.g. → Department 'IT' added.
//    }
//    else
//    {
//        // Department already exists – we don't overwrite it
//        // because that would delete all employees currently in it!
//        Console.WriteLine($"Department '{deptName}' already exists.");
//        // e.g. → Department 'IT' already exists.
//    }
//}


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 2 – Add an employee to a department
////  Parameters:
////    deptName  – which department to add the employee to
////    empName   – the employee's name
////    position  – the employee's job title
////
////  Logic:
////    First confirm the department exists.
////    If it does → retrieve its employee list and append the new employee
////    If it doesn't → warn the user
////
////  KEY CONCEPT – double indexing:
////    staffDictionary[deptName]        gives you the List<StaffMember>
////    staffDictionary[deptName].Add()  calls Add() ON that list
////
////  Expected outcomes:
////    AddEmployee("IT", "Shivaar", "Developer")
////        → "'Shivaar' added to 'IT'."
////    AddEmployee("Sales", "Sipho", "Sales Rep")
////        → "Department 'Sales' not found."  (dept was never created)
//// ════════════════════════════════════════════════════════════
//void AddEmployee(string deptName, string empName, string position)
//{
//    if (staffDictionary.ContainsKey(deptName))
//    {
//        // Step 1: staffDictionary[deptName] → fetches the List<StaffMember> for this dept
//        // Step 2: .Add(new StaffMember(...)) → creates a new employee object and appends it
//        staffDictionary[deptName].Add(new StaffMember(empName, position));
//        Console.WriteLine($"'{empName}' added to '{deptName}'.");
//        // e.g. → 'Shivaar' added to 'IT'.
//    }
//    else
//    {
//        // The department doesn't exist – can't add an employee to something that isn't there
//        Console.WriteLine($"Department '{deptName}' not found.");
//        // e.g. → Department 'Sales' not found.
//    }
//}


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 3 – Display all departments and employees
////
////  Logic:
////    Loop through every key-value pair in the dictionary.
////    For each department, print the dept name (the KEY).
////    Then loop through its employee list (the VALUE) and
////    print each employee's name and position.
////
////  KeyValuePair<string, List<StaffMember>>
////    dept.Key   = department name  e.g. "IT"
////    dept.Value = the List of StaffMember objects in that dept
////
////  Expected output:
////    ===== All Departments =====
////
////    Department: IT
////      - Shivaar | Developer
////      - Aiden   | Systems Analyst
////
////    Department: HR
////      - Priya | HR Manager
////
////    Department: Finance
////      - Rohan | Accountant
//// ════════════════════════════════════════════════════════════
//void DisplayAll()
//{
//    Console.WriteLine("\n===== All Departments =====");

//    // Outer loop: goes through each department (each key-value pair)
//    foreach (KeyValuePair<string, List<StaffMember>> dept in staffDictionary)
//    {
//        Console.WriteLine($"\nDepartment: {dept.Key}");
//        // dept.Key = the department name e.g. "IT"

//        if (dept.Value.Count == 0)
//        {
//            // dept.Value is the List – Count == 0 means no employees added yet
//            Console.WriteLine("  (No employees)");
//        }
//        else
//        {
//            // Inner loop: goes through each StaffMember in this dept's list
//            foreach (StaffMember emp in dept.Value)
//            {
//                // emp is one StaffMember object – access its properties with dot notation
//                Console.WriteLine($"  - {emp.Name} | {emp.Position}");
//                // e.g. → - Shivaar | Developer
//            }
//        }
//    }
//}


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 4 – Count employees per department
////
////  Logic:
////    Loop through each department.
////    dept.Value is the List<StaffMember> for that dept.
////    .Count gives the number of items in the list.
////
////  Expected output:
////    ===== Employee Count Per Department =====
////    IT: 2 employee(s)
////    HR: 1 employee(s)
////    Finance: 1 employee(s)
//// ════════════════════════════════════════════════════════════
//void CountEmployees()
//{
//    Console.WriteLine("\n===== Employee Count Per Department =====");

//    foreach (KeyValuePair<string, List<StaffMember>> dept in staffDictionary)
//    {
//        // dept.Key   = department name
//        // dept.Value.Count = how many StaffMember objects are in the list
//        Console.WriteLine($"{dept.Key}: {dept.Value.Count} employee(s)");
//        // e.g. → IT: 2 employee(s)
//    }
//}


//// ════════════════════════════════════════════════════════════
////  RUNNING / TESTING THE PROGRAM
////  This is where we actually call the methods above.
////  In a real app this could be a menu-driven loop instead.
//// ════════════════════════════════════════════════════════════

//// Create 3 departments
//// After these calls, staffDictionary has 3 keys, each with an empty list
//AddDepartment("IT");        // → Department 'IT' added.
//AddDepartment("HR");        // → Department 'HR' added.
//AddDepartment("Finance");   // → Department 'Finance' added.

//// Test the duplicate check
//AddDepartment("IT");        // → Department 'IT' already exists.

//// Add employees to their departments
//// Each call creates a new StaffMember object and appends it to the correct list
//AddEmployee("IT", "Shivaar", "Developer");       // IT list now has 1 employee
//AddEmployee("IT", "Aiden", "Systems Analyst"); // IT list now has 2 employees
//AddEmployee("HR", "Priya", "HR Manager");      // HR list now has 1 employee
//AddEmployee("Finance", "Rohan", "Accountant");      // Finance list now has 1 employee

//// Test the missing department check
//AddEmployee("Sales", "Sipho", "Sales Rep");  // → Department 'Sales' not found.

//// Print full department + employee listing
//DisplayAll();

//// Print how many employees are in each department
//CountEmployees();

//// ── Bring the Dictionaries namespace into scope ──────────────
//// Lets us write Patient instead of Dictionaries.Patient
//using Dictionaries;

//// ── The main dictionary ──────────────────────────────────────
//// int     = patient ID number  (the KEY)
//// Patient = the full patient object (the VALUE)
//// Starts empty – no patients registered yet
//Dictionary<int, Patient> patientDictionary = new Dictionary<int, Patient>();


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 1 – Add a patient
////  Parameters:
////    id        – the unique patient ID number
////    name      – patient's full name
////    diagnosis – what they are being treated for
////
////  Logic:
////    Check if the ID already exists in the dictionary.
////    If NOT → create a new Patient object and store it
////    If YES → warn the user, don't overwrite existing record
////
////  Expected outcomes:
////    AddPatient(101, "John Dube", "Flu")
////        → "Patient 'John Dube' (ID: 101) added."
////    AddPatient(101, "John Dube", "Flu")  ← same ID again
////        → "A patient with ID 101 already exists."
//// ════════════════════════════════════════════════════════════
//void AddPatient(int id, string name, string diagnosis)
//{
//    if (!patientDictionary.ContainsKey(id))
//    {
//        // ID doesn't exist yet – safe to add
//        // new Patient(...) creates the object, then we store it at key = id
//        patientDictionary[id] = new Patient(id, name, diagnosis);
//        Console.WriteLine($"Patient '{name}' (ID: {id}) added.");
//        // e.g. → Patient 'John Dube' (ID: 101) added.
//    }
//    else
//    {
//        // ID already taken – each patient must have a unique ID
//        Console.WriteLine($"A patient with ID {id} already exists.");
//        // e.g. → A patient with ID 101 already exists.
//    }
//}


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 2 – Search for a patient by ID
////  Parameter:
////    id – the patient ID to look up
////
////  Logic:
////    TryGetValue(id, out Patient? p) does two things at once:
////      1. Checks if the key exists
////      2. If it does, stores the Patient object in 'p'
////    This is safer than using ContainsKey + then indexing separately.
////    'out' means the variable p is declared AND filled by the method.
////
////  Expected outcomes:
////    SearchPatient(101)
////        → Found: ID=101 | Name=John Dube | Diagnosis=Flu | Discharged=False
////    SearchPatient(999)   ← ID doesn't exist
////        → "No patient found with ID 999."
//// ════════════════════════════════════════════════════════════
//void SearchPatient(int id)
//{
//    // TryGetValue returns true if found, false if not
//    // 'out Patient? p' – the ? means p could be null if not found
//    if (patientDictionary.TryGetValue(id, out Patient? p))
//    {
//        // p is now the Patient object stored at that ID
//        // We access each field using dot notation on p
//        Console.WriteLine($"\nFound: ID={p.PatientId} | Name={p.Name} | " +
//                          $"Diagnosis={p.Diagnosis} | Discharged={p.IsCharged}");
//        // e.g. → Found: ID=101 | Name=John Dube | Diagnosis=Flu | Discharged=False
//    }
//    else
//    {
//        // TryGetValue returned false – key doesn't exist in the dictionary
//        Console.WriteLine($"No patient found with ID {id}.");
//        // e.g. → No patient found with ID 999.
//    }
//}


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 3 – Remove all discharged patients
////
////  Logic:
////    We CANNOT remove items from a dictionary while we are
////    looping through it – C# will throw an error if you try.
////    Solution: first collect all IDs to remove in a separate
////    List<int>, THEN loop that list and remove from dictionary.
////
////    Step 1: Loop dictionary → find all where IsCharged == true
////            → add their ID to the toRemove list
////    Step 2: Loop toRemove list → delete each ID from dictionary
////
////  Expected outcomes (assuming patient 102 is discharged):
////    → "Removing discharged patient: Sarah Naidoo (ID: 102)"
////    → "1 discharged patient(s) removed."
////    (if none discharged)
////    → "No discharged patients to remove."
//// ════════════════════════════════════════════════════════════
//void RemoveDischarged()
//{
//    // Step 1: Collect IDs of discharged patients
//    // We build this list BEFORE touching the dictionary
//    List<int> toRemove = new List<int>();

//    foreach (KeyValuePair<int, Patient> entry in patientDictionary)
//    {
//        // entry.Key   = the patient ID
//        // entry.Value = the Patient object
//        // Check the IsCharged flag on the Patient object
//        if (entry.Value.IsCharged == true)
//        {
//            toRemove.Add(entry.Key);  // store the ID, not the object
//        }
//    }

//    // Step 2: Now it is safe to remove because we are no longer
//    // iterating over the dictionary – we are iterating over toRemove
//    if (toRemove.Count == 0)
//    {
//        Console.WriteLine("No discharged patients to remove.");
//        // e.g. → No discharged patients to remove.
//    }
//    else
//    {
//        foreach (int id in toRemove)
//        {
//            // patientDictionary[id].Name – access the name before deleting for the message
//            Console.WriteLine($"Removing discharged patient: {patientDictionary[id].Name} (ID: {id})");
//            patientDictionary.Remove(id);  // permanently deletes this key-value pair
//            // e.g. → Removing discharged patient: Sarah Naidoo (ID: 102)
//        }
//        Console.WriteLine($"{toRemove.Count} discharged patient(s) removed.");
//        // e.g. → 1 discharged patient(s) removed.
//    }
//}


//// ════════════════════════════════════════════════════════════
////  REQUIREMENT 4 – Display all remaining patients
////
////  Logic:
////    Simply loop through every key-value pair in the dictionary
////    and print each patient's details.
////    After RemoveDischarged() runs, only admitted patients remain.
////
////  Expected output (after discharge removal):
////    ===== Current Patients =====
////    ID: 101 | Name: John Dube    | Diagnosis: Flu          | Discharged: False
////    ID: 103 | Name: Ravi Pillay  | Diagnosis: Appendicitis | Discharged: False
//// ════════════════════════════════════════════════════════════
//void DisplayAll()
//{
//    Console.WriteLine("\n===== Current Patients =====");

//    if (patientDictionary.Count == 0)
//    {
//        // .Count on the dictionary tells us how many key-value pairs exist
//        Console.WriteLine("No patients currently on record.");
//        return;  // exit the method early – nothing more to do
//    }

//    foreach (KeyValuePair<int, Patient> entry in patientDictionary)
//    {
//        // entry.Key   = patient ID (the int key)
//        // entry.Value = the full Patient object
//        Patient p = entry.Value;  // store in a local variable for cleaner access

//        Console.WriteLine($"ID: {p.PatientId} | Name: {p.Name} | " +
//                          $"Diagnosis: {p.Diagnosis} | Discharged: {p.IsCharged}");
//        // e.g. → ID: 101 | Name: John Dube | Diagnosis: Flu | Discharged: False
//    }
//}


//// ════════════════════════════════════════════════════════════
////  RUNNING / TESTING THE PROGRAM
//// ════════════════════════════════════════════════════════════

//// Add 3 patients to the system
//// Dictionary after these calls:
////   101 → Patient(101, "John Dube",    "Flu",          false)
////   102 → Patient(102, "Sarah Naidoo", "Broken Arm",   false)
////   103 → Patient(103, "Ravi Pillay",  "Appendicitis", false)
//AddPatient(101, "John Dube", "Flu");
//AddPatient(102, "Sarah Naidoo", "Broken Arm");
//AddPatient(103, "Ravi Pillay", "Appendicitis");

//// Test the duplicate ID check
//// → "A patient with ID 101 already exists."
//AddPatient(101, "Ghost User", "None");

//// Mark patient 102 as discharged
//// We index into the dictionary with [102] to get the Patient object
//// then use dot notation to change the IsCharged property to true
//patientDictionary[102].IsCharged = true;
//// Dictionary now:
////   102 → Patient { ..., IsCharged = true }  ← flagged for removal

//// Search for an existing patient
//// → Found: ID=101 | Name=John Dube | Diagnosis=Flu | Discharged=False
//SearchPatient(101);

//// Search for a patient that doesn't exist
//// → No patient found with ID 999.
//SearchPatient(999);

//// Show all patients BEFORE removing discharged ones (102 still here)
//Console.WriteLine("\n--- BEFORE removing discharged patients ---");
//DisplayAll();

//// Remove all patients where IsCharged == true (patient 102)
//// → Removing discharged patient: Sarah Naidoo (ID: 102)
//// → 1 discharged patient(s) removed.
//RemoveDischarged();

//// Show all patients AFTER removal (only 101 and 103 remain)
//Console.WriteLine("\n--- AFTER removing discharged patients ---");
//DisplayAll();

// ── Bring the Dictionaries namespace into scope ──────────────
// Lets us write Player instead of Dictionaries.Player
using Dictionaries;

// ── The main dictionary ──────────────────────────────────────
// string = username   (the KEY)
// Player = player object with username + score (the VALUE)
// Starts empty – no players on the board yet
Dictionary<string, Player> leaderboard = new Dictionary<string, Player>();


// ════════════════════════════════════════════════════════════
//  REQUIREMENT 1 – Add a player
//  Parameters:
//    username – the player's unique name
//    score    – their starting score
//
//  Logic:
//    Check if the username key already exists.
//    If NOT → create a new Player object and store it
//    If YES → tell the user to use UpdateScore instead
//             (we never silently overwrite an existing player)
//
//  Expected outcomes:
//    AddPlayer("Shivaar", 4500)
//        → "Player 'Shivaar' added with score 4500."
//    AddPlayer("Shivaar", 9999)  ← same username again
//        → "Player 'Shivaar' already exists. Use UpdateScore to change their score."
// ════════════════════════════════════════════════════════════
void AddPlayer(string username, int score)
{
    if (!leaderboard.ContainsKey(username))
    {
        // Username not taken – create the Player object and store it
        // new Player(username, score) builds the object
        // leaderboard[username] = ... stores it at that key
        leaderboard[username] = new Player(username, score);
        Console.WriteLine($"Player '{username}' added with score {score}.");
        // e.g. → Player 'Shivaar' added with score 4500.
    }
    else
    {
        // Username already registered – don't overwrite
        Console.WriteLine($"Player '{username}' already exists. Use UpdateScore to change their score.");
        // e.g. → Player 'Shivaar' already exists. Use UpdateScore to change their score.
    }
}


// ════════════════════════════════════════════════════════════
//  REQUIREMENT 2 – Update a player's score
//  Parameters:
//    username – which player to update
//    newScore – the score to set them to
//
//  Logic:
//    TryGetValue(username, out Player? p):
//      - Returns true + fills 'p' if username exists
//      - Returns false if username not found
//    If found → update the Score property on the Player object
//    If not   → tell the user the player doesn't exist
//
//  KEY CONCEPT:
//    Because Player is a class (reference type), 'p' points to
//    the SAME object stored in the dictionary. So changing
//    p.Score ALSO changes it inside the dictionary – no need
//    to re-insert the object.
//
//  Expected outcomes:
//    UpdateScore("Shivaar", 9999)
//        → "'Shivaar' score updated: 4500 → 9999"
//    UpdateScore("Ghost99", 100)   ← doesn't exist
//        → "Player 'Ghost99' not found."
// ════════════════════════════════════════════════════════════
void UpdateScore(string username, int newScore)
{
    if (leaderboard.TryGetValue(username, out Player? p))
    {
        // p is the actual Player object inside the dictionary
        int oldScore = p.Score;   // save the old score for the message
        p.Score = newScore;       // this updates the object inside the dictionary too
        Console.WriteLine($"'{username}' score updated: {oldScore} → {newScore}");
        // e.g. → 'Shivaar' score updated: 4500 → 9999
    }
    else
    {
        // TryGetValue returned false – username doesn't exist in the dictionary
        Console.WriteLine($"Player '{username}' not found.");
        // e.g. → Player 'Ghost99' not found.
    }
}


// ════════════════════════════════════════════════════════════
//  REQUIREMENT 3 – Display the player with the highest score
//
//  Logic:
//    Loop through every player in the dictionary.
//    Keep track of the current highest player found so far.
//    If a player's score beats the current highest → update it.
//    After the loop, the top variable holds the overall winner.
//
//  We do this MANUALLY with a foreach (no LINQ) so you can
//  clearly see the comparison logic step by step.
//
//  Expected output (after Shivaar is updated to 9999):
//    🏆 Top Player: Shivaar with 9999 points
// ════════════════════════════════════════════════════════════
void DisplayTopPlayer()
{
    if (leaderboard.Count == 0)
    {
        // No players on the board yet – nothing to compare
        Console.WriteLine("Leaderboard is empty.");
        return;  // exit early
    }

    // Start with null – no winner found yet
    // Player? means the variable can hold null
    Player? top = null;

    foreach (KeyValuePair<string, Player> entry in leaderboard)
    {
        // entry.Key   = username string
        // entry.Value = the Player object

        if (top == null || entry.Value.Score > top.Score)
        {
            // Two conditions that update our 'top' player:
            // 1) top == null   → first player we've seen, automatically the leader so far
            // 2) this player's score beats the current top score → new leader
            top = entry.Value;
        }
        // If neither condition is true, this player scores lower – skip them
    }

    // After the loop, top is guaranteed to hold the highest-scoring player
    Console.WriteLine($"\n🏆 Top Player: {top!.Username} with {top.Score} points");
    // e.g. → 🏆 Top Player: Shivaar with 9999 points
    // The ! after top tells C# we are sure top is not null at this point
}


// ════════════════════════════════════════════════════════════
//  REQUIREMENT 4 – Display all players sorted by score
//                  (highest to lowest)
//
//  Logic:
//    Step 1: Get all Player objects from the dictionary values
//            leaderboard.Values → gives us a collection of Player objects
//    Step 2: Sort them by Score descending using LINQ
//            .OrderByDescending(p => p.Score) → highest score first
//    Step 3: Convert to a List so we can loop and use a rank counter
//            .ToList()
//    Step 4: Loop the sorted list and print each player with their rank
//
//  Expected output (with 4 players):
//    ===== Leaderboard (Highest → Lowest) =====
//    #1  Shivaar  — 9999 pts
//    #2  ProGamer — 8200 pts
//    #3  CodeKing — 7650 pts
//    #4  NightOwl — 3100 pts
// ════════════════════════════════════════════════════════════
void DisplaySorted()
{
    Console.WriteLine("\n===== Leaderboard (Highest → Lowest) =====");

    if (leaderboard.Count == 0)
    {
        Console.WriteLine("Leaderboard is empty.");
        return;
    }

    // Step 1 + 2 + 3 combined:
    // leaderboard.Values          → all Player objects (unordered)
    // .OrderByDescending(...)     → sort by Score, biggest first
    // p => p.Score                → lambda: "for each player p, sort by p.Score"
    // .ToList()                   → materialise into a usable List<Player>
    List<Player> sorted = leaderboard.Values
                                     .OrderByDescending(p => p.Score)
                                     .ToList();

    // Step 4: Loop sorted list with a rank counter starting at 1
    int rank = 1;
    foreach (Player p in sorted)
    {
        Console.WriteLine($"#{rank}  {p.Username} — {p.Score} pts");
        // e.g. → #1  Shivaar — 9999 pts
        rank++;  // increment rank for next player
    }
}


// ════════════════════════════════════════════════════════════
//  RUNNING / TESTING THE PROGRAM
// ════════════════════════════════════════════════════════════

// Add 4 players to the leaderboard
// Dictionary after these calls:
//   "Shivaar"  → Player("Shivaar",  4500)
//   "ProGamer" → Player("ProGamer", 8200)
//   "NightOwl" → Player("NightOwl", 3100)
//   "CodeKing" → Player("CodeKing", 7650)
AddPlayer("Shivaar", 4500);
AddPlayer("ProGamer", 8200);
AddPlayer("NightOwl", 3100);
AddPlayer("CodeKing", 7650);

// Test duplicate username check
// → "Player 'Shivaar' already exists. Use UpdateScore to change their score."
AddPlayer("Shivaar", 1111);

// Update Shivaar's score – he grinds hard
// → "'Shivaar' score updated: 4500 → 9999"
UpdateScore("Shivaar", 9999);

// Try updating a player that doesn't exist
// → "Player 'Ghost99' not found."
UpdateScore("Ghost99", 100);

// Show the top player (Shivaar now leads with 9999)
// → 🏆 Top Player: Shivaar with 9999 points
DisplayTopPlayer();

// Show full leaderboard sorted highest to lowest
// Expected:
//   #1  Shivaar  — 9999 pts
//   #2  ProGamer — 8200 pts
//   #3  CodeKing — 7650 pts
//   #4  NightOwl — 3100 pts
DisplaySorted();