# 📚 Library Management App

## 📌 Layihə haqqında

**Library Management App** kitabxana idarəetməsini modelləşdirən sadə C# Console layihəsidir.

Bu layihənin əsas məqsədi **Object-Oriented Programming (OOP)** prinsiplərini praktiki şəkildə tətbiq etmək və C# dilində class-lar, obyektlər, collection-lar və access modifier-lərlə işləmə bacarığını inkişaf etdirməkdir.

Layihədə əsasən aşağıdakı mövzulardan istifadə olunur:

* Class və Object
* Constructor
* Property
* Inheritance
* Encapsulation
* `List<T>`
* Access Modifiers
* Method-lar
* OOP prinsipləri

---

## 🛠 İstifadə olunan texnologiyalar

* **C#**
* **.NET**
* **Console Application**
* **Visual Studio / JetBrains Rider**

---

## 📂 Layihənin strukturu

```text
LibraryManagementApp
│
├── Models
│   ├── BaseEntity.cs
│   ├── Book.cs
│   └── Library.cs
│
├── Utils
│   └── Enums
│
├── Program.cs
│
└── README.md
```

---

## 🧩 Class-lar

### BaseEntity

`BaseEntity` layihədəki əsas model class-ları üçün ortaq xüsusiyyətləri saxlamaq məqsədilə yaradılmış base class-dır.

Məsələn:

```csharp
public class BaseEntity
{
    public int Id { get; set; }
}
```

`Book` və `Library` class-ları `BaseEntity` class-ından miras ala bilər.

---

## 📖 Book class-ı

`Book` class-ı kitabxanada yerləşən kitabları təmsil edir.

### Property-lər

```csharp
public string Name { get; set; }
public string AuthorName { get; set; }
public int PageCount { get; set; }
public bool IsDeleted { get; set; }
```

Burada:

* `Name` — kitabın adını saxlayır
* `AuthorName` — müəllifin adını saxlayır
* `PageCount` — kitabın səhifə sayını saxlayır
* `IsDeleted` — kitabın silinib-silinmədiyini göstərir

---

### Constructor

```csharp
public Book(string name, string authorName, int pageCount)
{
    Name = name;
    AuthorName = authorName;
    PageCount = pageCount;
}
```

Constructor vasitəsilə yeni `Book` obyekti yaradılarkən kitabın məlumatları təyin olunur.

Məsələn:

```csharp
Book book = new Book(
    "1984",
    "George Orwell",
    328
);
```

---

## ℹ️ ShowInfo metodu

`ShowInfo()` metodu kitab haqqında məlumatları Console-da göstərmək üçün istifadə olunur.

```csharp
public void ShowInfo()
{
    Console.WriteLine(
        $"Name: {Name} | AuthorName: {AuthorName} | PageCount: {PageCount}"
    );
}
```

Nəticə:

```text
Name: 1984 | AuthorName: George Orwell | PageCount: 328
```

---

# 🏛 Library class-ı

`Library` class-ı kitabxananı təmsil edir.

Kitabxananın daxilində saxlanıla biləcək kitabların maksimum sayı `BookLimit` property-si ilə müəyyən edilir.

```csharp
public int BookLimit { get; set; }
```

---

## 📚 Books list-i

Kitablar `List<Book>` daxilində saxlanılır.

```csharp
private List<Book> Books { get; set; } = new();
```

Burada `Books` list-i **private** olaraq yaradılıb.

Bu o deməkdir ki, `Books` list-inə `Library` class-ından kənardan birbaşa müdaxilə etmək mümkün deyil.

Məsələn:

```csharp
library.Books.Add(book);
```

❌ Bu kod işləməyəcək, çünki `Books` private-dır.

Kitab əlavə etmək üçün `Library` class-ının daxilində ayrıca metod yaradılmalıdır.

Məsələn:

```csharp
public void AddBook(Book book)
{
    Books.Add(book);
}
```

Bu yanaşma **Encapsulation** prinsipinə uyğundur.

---

## 🔐 Encapsulation

Layihədə istifadə olunan əsas OOP prinsiplərindən biri **Encapsulation**-dır.

Encapsulation obyekt daxilindəki məlumatların birbaşa dəyişdirilməsinin qarşısını almağa imkan verir.

Məsələn, aşağıdakı yanaşma düzgün hesab edilmir:

```csharp
public List<Book> Books { get; set; }
```

Çünki bu halda proqramın başqa hissələrindən `Books` list-inə birbaşa müdaxilə etmək mümkündür.

Daha düzgün yanaşma:

```csharp
private List<Book> Books { get; set; } = new();
```

Beləliklə kitablarla bağlı bütün əməliyyatlar `Library` class-ının metodları vasitəsilə idarə olunur.

---

## 🧬 Inheritance

Layihədə inheritance prinsipindən də istifadə olunur.

Məsələn:

```csharp
public class Book : BaseEntity
```

və

```csharp
public class Library : BaseEntity
```

Beləliklə həm `Book`, həm də `Library` `BaseEntity` class-ında olan ortaq xüsusiyyətlərdən istifadə edə bilir.

---

## 🏗 Library Constructor

`Library` obyekti yaradılarkən kitab limiti təyin edilir.

```csharp
public Library(int bookLimit)
{
    BookLimit = bookLimit;
}
```

Məsələn:

```csharp
Library library = new Library(10);
```

Bu zaman maksimum **10 kitab** saxlaya bilən kitabxana yaradılır.

---

# 🧠 Layihədə istifadə olunan OOP prinsipləri

## 1. Encapsulation

Məlumatların birbaşa dəyişdirilməsinin qarşısını almaq üçün `private` access modifier-dən istifadə olunur.

```csharp
private List<Book> Books { get; set; } = new();
```

---

## 2. Inheritance

`Book` və `Library` kimi class-lar `BaseEntity` class-ından ortaq xüsusiyyətləri miras alır.

```csharp
public class Book : BaseEntity
```

---

## 3. Abstraction

Kitabxananın daxili işləmə prinsipi istifadəçidən gizlədilir.

Məsələn, istifadəçi `Books` list-i ilə birbaşa işləmək əvəzinə metodlardan istifadə edir.

```csharp
library.AddBook(book);
```

---

# 💻 İstifadə nümunəsi

```csharp
Book book1 = new Book(
    "1984",
    "George Orwell",
    328
);

Book book2 = new Book(
    "The Little Prince",
    "Antoine de Saint-Exupéry",
    96
);

Library library = new Library(10);

book1.ShowInfo();
book2.ShowInfo();
```

Console nəticəsi:

```text
Name: 1984 | AuthorName: George Orwell | PageCount: 328
Name: The Little Prince | AuthorName: Antoine de Saint-Exupéry | PageCount: 96
```

---

# 🎯 Layihənin məqsədləri

Bu layihənin əsas məqsədləri:

* C# dilində class və object anlayışlarını mənimsəmək
* Constructor-larla işləməyi öyrənmək
* `List<T>` ilə işləmək
* Access Modifier-ləri düzgün istifadə etmək
* Encapsulation prinsipini tətbiq etmək
* Inheritance prinsipini tətbiq etmək
* Class-lar arasında əlaqə yaratmaq
* Səliqəli və oxunaqlı kod yazmaq
* Real layihəyə bənzər struktur qurmaq

---

# 🚀 Gələcəkdə əlavə edilə biləcək funksiyalar

Layihə inkişaf etdirilərək aşağıdakı funksiyalar əlavə oluna bilər:

* Kitab əlavə etmək
* Kitab silmək
* Kitabı ID-yə görə tapmaq
* Kitab adına görə axtarış etmək
* Bütün kitabları göstərmək
* Kitab limitini yoxlamaq
* Silinmiş kitabları idarə etmək
* Custom Exception-lardan istifadə etmək

Məsələn:

```csharp
AddBook(Book book)

RemoveBook(int id)

GetBookById(int id)

GetAllBooks()

SearchBooks(string searchText)
```

---

# ✅ Nəticə

**Library Management App** layihəsi C# dilində OOP prinsiplərini praktiki şəkildə tətbiq etmək üçün hazırlanmışdır.

Layihə vasitəsilə:

* Encapsulation
* Inheritance
* Class-lar
* Object-lər
* Constructor-lar
* List-lər
* Access Modifier-lər
* Method-lar

kimi əsas proqramlaşdırma anlayışları tətbiq olunur.

Layihənin əsas məqsədi yalnız işləyən proqram yaratmaq deyil, eyni zamanda kodun:

* səliqəli,
* oxunaqlı,
* strukturlaşdırılmış,
* idarəolunan

şəkildə yazılmasıdır.

---

### 👨‍💻 C# OOP Home Task

**Layihə:** Library Management App
**Proqramlaşdırma dili:** C#
**Platforma:** .NET Console Application


# 👨‍💻 Müəllif

**Nurlan Suleymanov**

GitHub:
[Profil linki](https://github.com/nurlanssu-dev)
