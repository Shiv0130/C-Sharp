# B1 (Bonus) ERD & Relationships
*Pointer 3: Database Relationships (ERDs, navigation properties, one-to-many, many-to-many, composite keys)*

## Lesson

An **ERD** (Entity Relationship Diagram) is a picture of your tables (entities), their columns, and how they connect.
Boxes = tables. Lines = relationships. Mark `PK` on primary keys and `FK` on foreign keys.

**Relationship types:**
- **One-to-many (1 to \*)**: one author writes many books. The *many* side holds the foreign key (`Book.AuthorId`).
  In C#: `Book.Author` (one) and `Author.Books` (a list). These are the *navigation properties*.
- **Many-to-many (\* to \*)**: a book can be in many categories, a category holds many books. A database can't do this directly, so you add a **join table** (`BookCategory`) with two foreign keys. Its primary key is the two together, a **composite key**.

Text ERD for Book world (you can draw yours the same way, ASCII is fine):

```
 Author               Book                      BookCategory           Category
+-----------+       +-------------+           +--------------+       +-------------+
| PK AuthorId|1----*| PK BookId   |1-------*  | PK,FK BookId |*-----1| PK CategoryId|
|    Name    |      |    Title    |           | PK,FK CategoryId|    |    Name      |
+-----------+       | FK AuthorId |           +--------------+       +-------------+
                    +-------------+
```

Reading the lines: `1----*` = one on the left, many on the right.

**Traps:**
- Putting the FK on the wrong side. It always sits on the MANY side.
- Forgetting the join table for many-to-many.
- Not saying which columns are PK and FK.

## Question

Draw (in text or ASCII) an ERD for HospitalApp with **Doctor**, **Patient** and the joining table **DoctorPatient**. Mark PKs
and FKs and show the cardinality. Then say in one or two sentences what kind of relationships these are and how the join table's key is built.

## My answer

```
 Doctor                   Patient                   DoctorPatient
+----------------+      +------------------+      +-------------------+
| PK DoctorId    |1----*| PK PatientId     |      | PK,FK DoctorId    |
|    Name        |      |    FullName      |      | PK,FK PatientId   |
|    Specialty   |      |    Age           |      +-------------------+
+----------------+      | FK DoctorId      |
   1                    +------------------+
   |                           1
   *                           |
   +------ DoctorPatient *-----+
```
(Doctor 1 --- * DoctorPatient * --- 1 Patient)

Doctor to Patient through Patient.DoctorId is a one-to-many relationship: one doctor has many patients, and the foreign key sits on the many side. DoctorPatient is the joining table that models a many-to-many relationship (a doctor sees many patients and a patient sees many doctors). Its primary key is a composite key made of DoctorId + PatientId, and each of those is also a foreign key.

## Self-check rubric

- [ ] Shows the entities Doctor and Patient (and DoctorPatient)
- [ ] PKs marked
- [ ] FKs marked (Patient.DoctorId, and both ids in DoctorPatient)
- [ ] States/draws one-to-many (one Doctor has many Patients, 1 to *)
- [ ] States many-to-many is done with a join table (DoctorPatient)
- [ ] Says the join table's key is a composite key of both ids
