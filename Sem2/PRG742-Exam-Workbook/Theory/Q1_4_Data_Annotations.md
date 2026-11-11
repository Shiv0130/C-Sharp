# Q1.4 Data Annotations  [5 marks]
*Pointer 1: Models & Data Annotations*

## Lesson

Data annotations are the `[Tags]` on a model's properties. They state the **rules** for the data right where the property lives.
They get used twice:

1. **MVC validation.** When a form posts, MVC checks the rules and fills `ModelState`. `ModelState.IsValid` is false if any rule is broken. The Tag Helpers also show the error messages.
2. **EF Core schema.** EF reads them when it builds the table: `[Required]` becomes NOT NULL, `[StringLength(100)]` becomes a max length, `[Key]` becomes the primary key.

```csharp
public class Book
{
    [Key]                           // primary key
    public int BookId { get; set; }

    [Required]                      // must have a value, can't be null or empty
    [StringLength(150)]             // at most 150 characters
    public string Title { get; set; }

    [Range(1, 5000)]                // must be between 1 and 5000
    public int Pages { get; set; }
}
```

The exam asks for **two examples and what each one enforces.** Use this recipe: *"[Name] enforces ... e.g. ..."*

**Traps:**
- Only listing the attribute names. The marks are for saying what each ENFORCES.
- Forgetting the purpose sentence (validation + database rules) in front.

## Question

What is the purpose of Data Annotations in C# model classes? Provide two examples of validation attributes and explain what
each one enforces.

## My answer

Data annotations are attributes placed on model properties to add validation rules and metadata. MVC checks them when a form is posted (ModelState.IsValid) and EF Core uses them to shape the database table.

1. [Required] enforces that the property must have a value: it cannot be null or empty. In the database the column becomes NOT NULL.
2. [StringLength(100)] enforces a maximum length of 100 characters for the string (and sets the column's max length).
(Another example: [Range(0, 120)] enforces that a number is between 0 and 120.)

## Self-check rubric

- [ ] Purpose: attributes that add validation rules / metadata to model properties
- [ ] Mentions they are checked by MVC (ModelState) and/or used by EF Core for the database
- [ ] Example 1 named, with what it enforces
- [ ] Example 2 (a different one) named, with what it enforces
