# Q1.3 Data Management: ViewBag vs TempData  [5 marks]
*Pointer 7: Data Management*

## Lesson

Both are ways to carry a little data from a controller to a view. The difference is **how long it lives.**

| | ViewBag | TempData |
|---|---|---|
| What is it | a dynamic wrapper around `ViewData` | a dictionary stored between requests (cookie or session) |
| Lifetime | **this one request only** | survives **one redirect** (until the next request reads it) |
| Typical use | feed a dropdown list, a page title, extra labels | a "saved successfully!" message after a redirect |

Why does it matter? After a successful POST you `RedirectToAction("Index")`. A redirect is a **brand new request**, so the
ViewBag from the old one is gone. TempData is still there, the next page reads it and then it is removed.

```csharp
// controller (POST, then redirect)
TempData["SuccessMessage"] = "Book saved!";
return RedirectToAction("Index");

// view (the page after the redirect)
@if (TempData["SuccessMessage"] != null) { <div>@TempData["SuccessMessage"]</div> }
```

```csharp
// ViewBag example: filling a dropdown for the SAME request
ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "Name");
return View();
```

**Traps:**
- Using ViewBag for a message, then redirecting. The message vanishes.
- TempData is **read-once**: once displayed it is deleted (`TempData.Keep()` or `Peek()` keeps it).
- "ViewBag is for the view, TempData is for the next page" is a handy one-liner.

## Question

Explain the difference between ViewBag and TempData in ASP.NET Core MVC. Provide a short example scenario of when you would
use TempData instead of ViewBag.

## My answer

ViewBag is a dynamic wrapper around ViewData that passes data from a controller to its view for the current request only. When the request ends, or you redirect, the data is lost.

TempData stores data so that it survives a redirect: it is kept until the next request reads it and is then removed (unless TempData.Keep() or Peek() is used). It is stored using a cookie or session.

Scenario for TempData: after a user submits the Create Patient form, the POST action saves the patient, sets TempData["SuccessMessage"] = "Patient created successfully!" and redirects to Index. The Index view reads and shows the message. ViewBag would not work here because the redirect is a new request.

## Self-check rubric

- [ ] ViewBag: controller to view, only for the current request (lost on redirect)
- [ ] ViewBag is dynamic / wraps ViewData
- [ ] TempData: survives a redirect, available on the next request
- [ ] TempData is removed once read (unless Keep/Peek)
- [ ] Gives a scenario: e.g. a success message after a POST followed by a redirect
