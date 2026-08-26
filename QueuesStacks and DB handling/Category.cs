using System.Collections.Generic;

/// <summary>
/// Represents the parent entity in a one-to-many data relationship.
/// </summary>
public class Category
{
    // Auto-implemented properties storing category metadata
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation Property: Explicitly defines a collection holding related child 'Product' records.
    // Instantiated directly as an empty 'List<Product>' to safely prevent code-breaking NullReferenceExceptions when adding items.
    public ICollection<Product> Proudcts { get; set; } = new List<Product>();
}