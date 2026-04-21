using class_polymorphism;

/* 1.Abstraction
 * abstarct class Person
 * Hides implementatin details and forces subclasses to define DisplayRole()
 * 
 * 2. Encapsulation
 * private string name
 * Access controlled via public string Name {get; set;}
 * 
 * 
 * 3. Inheritance 
 * Student: Person
 * Teacher: Person
 * 
 * 4. Polymorphism
 * 
 * override DisplayRole()
 * Same method behaves differently depending on the object
 */

//Polymorphism in action
Person p1 = new Student();
p1.SetName("Shivaar");

Person p2 = new Teacher();
p2.SetName("Lunga");

p1.DisplayRole();

p2.DisplayRole();