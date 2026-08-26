using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ════════════════════════════════════════════════════════════
//  EXERCISE 2 - Hospital Patient System
//  Data Structure used:
//      Dictionary<int, Patient>
//      KEY   = patientId  (e.g. 101)
//      VALUE = a Patient object holding all their details
//
//  Think of it like this:
//      101 → Patient { Id=101, Name="John",  Diagnosis="Flu",         IsCharged=false }
//      102 → Patient { Id=102, Name="Sarah", Diagnosis="Broken Arm",  IsCharged=true  }
//      103 → Patient { Id=103, Name="Ravi",  Diagnosis="Appendicitis",IsCharged=false }
//
//  We use int as the key because patient IDs are numbers,
//  and ints are faster to look up than strings.
// ════════════════════════════════════════════════════════════

namespace Dictionaries
{
    // ── Patient class ────────────────────────────────────────
    // Blueprint for every patient stored in the system.
    // Each patient has 4 pieces of information:
    //   PatientId    – unique number identifying the patient
    //   Name         – patient's full name
    //   Diagnosis    – what they were treated for
    //   IsCharged  – false = still admitted, true = discharged
    public class Patient
    {
        public int PatientId { get; set; }  // e.g. 101
        public string Name { get; set; }  // e.g. "John Dube"
        public string Diagnosis { get; set; }  // e.g. "Flu"
        public bool IsCharged { get; set; }  // false by default (still in hospital)

        // Constructor – runs when you do new Patient(...)
        // isCharged has a default value of false, so you don't HAVE to pass it
        // e.g. new Patient(101, "John", "Flu") → IsCharged will be false automatically
        public Patient(int patientId, string name, string diagnosis, bool isCharged = false)
        {
            PatientId = patientId;
            Name = name;
            Diagnosis = diagnosis;
            IsCharged = isCharged;
        }
    }
}
