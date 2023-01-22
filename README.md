## Stappen plan
# Maak eerst een DbContext
![alt text](https://github.com/karim076/LearningApp/blob/main/Images/Context.PNG)
# Maak daarna jouw class(jouw tabellen)
Dit vind je in de Models mapje 
# Hoe maak je een one To many relationship
Een voorbeeld die we hier gebruiken is een gebouw waar meerdere mensen in werken dus Gebouw A Has many workers en een Employee belongs to Building
Hier staat een voorbeeld:
```
internal class Building
{
   public int Id { get; set; }
   public string BuildingName { get; set; }
   
   public ICollection<Employees> Workers { get; set; } = null; // has many employees
}

```
```
internal class Building
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string Last_Name { get; set; }
   
   public Building Building { get; set; } // Belongs to a Building
}

```
