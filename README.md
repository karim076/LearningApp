# Stappen plan
## voorbereiding
Je moet ook zelf een database aanmaken in phpMyAdmin of HeidiSQL, en zorg ervoor dat je apache aan staat zodat je database op een localhost staat om te werken.
## Maak eerst een DbContext
![alt text](https://github.com/karim076/LearningApp/blob/main/Images/Context.PNG)
## Maak daarna jouw class(jouw tabellen)
Dit vind je in de Models mapje 
## Hoe maak je een one To many relationship
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
Met``` public Building Building { get; set; } ``` en ``` public ICollection<Employees> Workers { get; set; } = null;```
maken we de relatie one to many.
## Nu ga je jouw models migrate
Om je models(classes) te migrate ga je in je Package Manager Console of je gaat bij Tools/NuGet Package Manager/Package Manager Console en kun je een commando's uitvoeren en de commando die we uitvoeren is: 
```
Add-Migration MyFirstMigration
```
En daarna dit commando:
```
Update-Database
```
## Nu maken we een listview om daar in onze data te weergeven
Voorbeeld die wordt gebruikt in het app zelf:
```
<ListView x:Name="lv_building">
   <ListView.ItemTemplate>
      <DataTemplate x:DataType="local:Building">
         <StackPanel Orientation="Horizontal">
            <TextBlock Text="{Binding BuildingName}" />

             <ListView ItemsSource="{Binding Workers}">
               <ListView.ItemTemplate>
                  <DataTemplate x:DataType="local:Employees">
                     <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}" />
                        <TextBlock Text="{Binding Last_Name}" />
                     </StackPanel>
                   </DataTemplate>
                </ListView.ItemTemplate>
              </ListView>

          </StackPanel>
       </DataTemplate>
   </ListView.ItemTemplate>
</ListView>
```
Wat we hier doen is we krijgen de data via code behind met een Itemsource en om alle workers te laten zien van elk gebouw doe je zo:
```
using (var context = new learnContext())
{
   var LoadedBuilding = context.Building   .ToList();
   context.Employees.ToList();
   lv_building.ItemsSource = LoadedBuilding            
}
```
We hallen alle buildings op en plaatsen dat in LoadedBuilding en daarna halen we employees op dit is belangerijk je slaat em niet op maar je roept wel de data of als je dit niet worden de Employees niet getoond, en als laats voegen we de LoadedBuilding in het listview.
# Einde
## Extra seeding
Om snel je te testen kun je jouw database seeden hier een voorbeeld:
```
// seeding database
Building A = new Building { BuildingName = "Gebouw A"};
Building B = new Building { BuildingName = "Gebouw A"};
            
Employees Employee_One = new Employees { Name = "Sam", Last_Name = "Ports", Building = A };
Employees Employee_Two = new Employees { Name = "Harry Potter", Last_Name = "Potter", Building = A };
Employees Employee_Three = new Employees { Name = "Karim", Last_Name = "Alkichouhi", Building = B };
```
Dit doe je bij het eerste keer starten van je programma en daarna commenten om niet de date dubble te laten staan in het database
