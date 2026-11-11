# Q1.1 RESTful Principles & HTTP Methods  [5 marks]
*Pointer 8: Web APIs (theory)*

## Lesson

Alright, here's the idea. When two programs talk over the web (your phone app and a server, say), they need rules.
**REST** is a popular set of rules for designing a web API. Instead of weird function calls, you treat everything as a
**resource** (a patient, a book, an order) that has a **URL**, and you use plain **HTTP methods** to say what you want to do with it.

```
GET     /api/books        -> give me all the books                 (READ)
GET     /api/books/7      -> give me book number 7                 (READ)
POST    /api/books        -> here's a new book, please add it      (CREATE)
PUT     /api/books/7      -> replace book 7 with this version      (UPDATE)
DELETE  /api/books/7      -> remove book 7                         (DELETE)
```

That mapping is basically **CRUD** (Create, Read, Update, Delete) over the web. Learn the four pairs, they are a free 4 marks.

**Statelessness** is the big word. It means: *the server does not remember you between requests.* Every request has to carry
everything the server needs to answer it (the URL, the data, and who you are, for example a token). The server treats each
request as brand new. Why is that good? Servers stay simple, and you can add more servers because any one of them can answer any request.

**Tiny example (Book world):** you ask `GET /api/books/7`. The server answers and forgets you. Next you ask `DELETE /api/books/7`.
The server does not think "ah, same person who just looked at book 7". It only looks at what that second request contains.

**Traps:**
- Mixing up PUT and POST. POST = create new. PUT = update/replace an existing one.
- Saying statelessness means "no database". Wrong: the server can still store data. It just doesn't store *your session* between calls.
- Writing only "REST is an API". Say it is an *architectural style* built on resources, URLs and HTTP methods.

## Question

Explain the concept of RESTful architecture in Web APIs. Your answer must state the meaning of "Statelessness" and match the
HTTP methods (GET, POST, PUT, DELETE) to their corresponding CRUD operations.

## My answer

<!-- Type your answer here, in your own words. Write it like you would in the exam. No peeking at the rubric below until you are done. -->

## Self-check rubric
Tick these off honestly after you've written your answer. The marker looks for the ideas, not the exact words.

- [ ] Says REST is an architectural style / design approach for web APIs, built on resources and URLs
- [ ] Defines statelessness: each request contains all the information needed
- [ ] ...and the server does not remember the client between requests
- [ ] GET matched to Read
- [ ] POST matched to Create
- [ ] PUT matched to Update
- [ ] DELETE matched to Delete
