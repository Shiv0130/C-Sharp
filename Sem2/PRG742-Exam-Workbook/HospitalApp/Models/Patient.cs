// =====================================================================================
//  Q2.1  MODEL CLASS & DATA ANNOTATIONS   [15 marks]     Pointer 1: Models & Data Annotations
// =====================================================================================
//
//  LESSON (read this first, it takes 3 minutes)
//  --------------------------------------------
//  Alright, a model is just a normal C# class that describes ONE thing in your database.
//  One class = one table. One property = one column. One object = one row.
//
//  Data annotations are the little [Tags] you stick on top of a property. They do two jobs:
//     1. VALIDATION  -> MVC checks them when a form is posted (ModelState.IsValid).
//     2. DATABASE    -> EF Core uses them to build the table (NOT NULL, max length, keys).
//
//  The ones you need for the exam (all live in System.ComponentModel.DataAnnotations):
//     [Key]                 this property is the primary key
//     [Required]            can't be null / empty
//     [StringLength(100)]   max 100 characters
//     [Range(0, 120)]       number must be between 0 and 120
//     [ForeignKey("Name")]  (lives in System.ComponentModel.DataAnnotations.SCHEMA, a different using!)
//
//  WORKED EXAMPLE (a different entity: Book and Author, one author writes many books)
//  -----------------------------------------------------------------------------------
//      using System.ComponentModel.DataAnnotations;
//      using System.ComponentModel.DataAnnotations.Schema;   // <- needed for [ForeignKey]
//
//      public class Book
//      {
//          [Key]
//          public int BookId { get; set; }
//
//          [Required]
//          [StringLength(150)]
//          public string Title { get; set; }
//
//          [Range(1, 5000)]
//          public int Pages { get; set; }
//
//          [ForeignKey("Author")]          // "Author" = the NAME OF THE NAVIGATION PROPERTY below
//          public int AuthorId { get; set; }    // foreign key column
//
//          public Author Author { get; set; }   // navigation property: lets you do book.Author.Name
//      }
//
//  Read it like a sentence: a Book has a key, a required title, a page count in a range,
//  and it belongs to an Author through AuthorId.
//
//  COMMON TRAPS
//  ------------
//  * Forgetting  using System.ComponentModel.DataAnnotations.Schema;  -> [ForeignKey] goes red.
//    The paper does NOT give you that using. In the exam you have to remember it.
//  * [ForeignKey("Doctor")] takes the navigation property's NAME, so it must match exactly.
//  * [StringLength(100)] is a max. It does not make the field required. You need [Required] too.
//  * Properties need { get; set; }. A bare field like  public int Age;  is NOT a property.
//  * [Range(0, 120)] is on the number. Don't put it on a string.
//
//  THE TASK  (this is how it looks in the exam: write the whole thing yourself)
//  ----------------------------------------------------------------------------
//  Write the C# model class for a Patient. It must have:
//     PatientId   (integer, primary key)
//     FullName    (string, required, maximum length 100)
//     Age         (integer, must be between 0 and 120)
//     DoctorId    (integer, foreign key to Doctor)
//     Doctor      (navigation property of type Doctor)
//
//  HINT (a nudge, not the answer)
//  ------------------------------
//  Five properties, so five blocks. Put the annotation on the line ABOVE its property.
//  Your usings go at the very top of your code, above the namespace line.
//  Done? Run ./check.sh (or check.ps1) and look for the Q2_1 lines.
//
// >>>>> WRITE YOUR ANSWER BELOW THIS LINE (replace the empty shell) <<<<<

namespace HospitalApp.Models;

public class Patient
{
}
