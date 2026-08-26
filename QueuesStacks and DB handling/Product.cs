using System;

/// <summary>
/// Represents the child entity containing properties mapped back to a specific parent category.
/// </summary>
public class Product
{
    // Auto-implemented primary key identifier field
    public int Id { get; set; }

    // The '?' character marks these string fields as explicitly "Nullable" string properties,
    // signaling to the compiler that saving null or empty variables inside these data slots is expected and handled.
    public string? Name { get; set; }

    public string? Description { get; set; }

    // Foreign Key Reference/Navigation Property linking this specific individual product instance directly back to its single parent Category object.
    public Category Category { get; set; }
}