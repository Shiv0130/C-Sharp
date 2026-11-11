# B4 (Bonus) Asynchronous Database Operations
*Pointer 7: Data Management (async)*

## Lesson

A database call is *slow* (compared to the CPU). If your code **blocks** while waiting, that thread sits there doing nothing and
can't help anyone else. With **async/await**, the thread is released while the database works, and picked back up when the answer returns.

```csharp
public async Task<IActionResult> Index()                 // async + returns a Task
{
    var books = await _context.Books.ToListAsync();      // await = "wait for this WITHOUT blocking the thread"
    return View(books);
}
```

The pattern:
- Mark the method `async`, change the return type to `Task<...>`.
- Use the **Async version** of the EF call and `await` it: `ToListAsync`, `FirstOrDefaultAsync`, `FindAsync`, `SaveChangesAsync`.
- Result: the web server can handle many more users at once (**scalability**) and stays responsive.

**Traps:**
- Using `async` but forgetting `await`: you get a Task object, not your data.
- Mixing: `SaveChanges()` inside an async method blocks. Use `SaveChangesAsync()`.
- Async does not make a single query faster. It makes the server handle more at once.

## Question

Explain why asynchronous database operations are used in ASP.NET Core MVC controllers. Name the return type of an async action
and give two EF Core async methods.

## My answer

Asynchronous database calls free the thread while it waits for the database instead of blocking it, so the same thread can serve other requests in the meantime. This makes the application more scalable and responsive when many users are connected.

An async action has the return type Task<IActionResult> (marked async) and uses await. EF Core provides async methods such as ToListAsync(), FindAsync() and SaveChangesAsync(), for example: var patients = await _context.Patients.ToListAsync();

## Self-check rubric

- [ ] Explains the thread is not blocked / is freed while waiting for the database
- [ ] Return type is Task (Task<IActionResult>)
- [ ] Names two Async methods, e.g. ToListAsync, SaveChangesAsync, FindAsync
- [ ] Benefit: scalability / responsiveness with many users
