using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ════════════════════════════════════════════════════════════
//  EXERCISE 1 - Company Departments
//  Data Structure used:
//      Dictionary<string, List<StaffMember>>
//      KEY   = department name  (e.g. "IT")
//      VALUE = a List of StaffMember objects in that dept
//
//  Think of it like this:
//      "IT"      → [ Shivaar(Developer), Aiden(Analyst) ]
//      "HR"      → [ Priya(HR Manager)                  ]
//      "Finance" → [ Rohan(Accountant)                  ]
// ════════════════════════════════════════════════════════════

namespace Dictionaries
{
    // ── StaffMember class ────────────────────────────────────
    // This is the blueprint for each employee object.
    // Every employee has a Name and a Position.
    // We use auto-properties { get; set; } so values can be
    // read and changed from outside the class.
    public class StaffMember
    {
        public string Name { get; set; }  // e.g. "Shivaar"
        public string Position { get; set; }  // e.g. "Developer"

        // Constructor: runs when you do new StaffMember(...)
        // It receives the values and stores them in the properties above
        public StaffMember(string name, string position)
        {
            Name = name;      // assign the parameter to the property
            Position = position;
        }
    }
}
