using ZooManagment;
using ZooManagment.Entities;
using ZooManagment.Persistence.Animals;
using ZooManagment.Persistence.Sections;
using ZooManagment.Persistence.Tickets;
using ZooManagment.Persistence.Zooes;

var context = new EFDataContext();
var zooRepository = new EFZooRepository(context);
var sectionRepository = new EFSectionRepository(context);
var animalRepository = new EFAnimalRepository(context);
var ticketRepository = new EFTicketRepository(context);





var isExitFromOption = false;
while (isExitFromOption == false)
{
    var option = GetInt("0-Exit \n" +
                        "1-Zoos\n" +
                        "2-Sections\n" +
                        "3-Animal\n" +
                        "4-Ticket\n" +
                        "5-Show zoos with animals\n" +
                        "6-ShowZoosWithSectionsWithTickets");
    switch (option)
    {
        case 0:
            isExitFromOption = true;
            break;
        case 1:
            {
                var isExitFromZooOption = false;

                while (isExitFromZooOption == false)
                {

                    var ZooOption = GetInt("0-Exit\n" +
                                           "1-Creat\n" +
                                           "2-Read\n" +
                                           "3-Update\n" +
                                           "4-Delete");
                    switch (ZooOption)
                    {
                        case 0:
                            isExitFromZooOption = true;
                            break;
                        case 1:
                            {
                                CreatZoo();

                            }
                            break;
                        case 2:
                            {
                                ShowZoos();

                            }
                            break;
                        case 3:
                            {
                                EditZoo();
                            }
                            break;
                        case 4:
                            {
                                DeleteZoo();
                            }
                            break;
                    }
                }

            }
            break;

        case 2:
            {
                var isExitFromSectionOption = false;
                while (isExitFromSectionOption == false)
                {
                    var sectionOption = GetInt("0-Exit\n" +
                                           "1-Creat\n" +
                                           "2-Read\n" +
                                           "3-Update\n" +
                                           "4-Delete");
                    switch (sectionOption)
                    {
                        case 0:
                            isExitFromSectionOption = true;
                            break;
                        case 1:
                            CreatSection();
                            break;
                        case 2:
                            ShowSectionsWithAnimals();
                            break;
                        case 3:
                            EditSection();
                            break;
                        case 4:
                            DeleteSection();
                            break;





                    }





                }

            }break;



        case 3:
            {
                var isExitFromAnimalOption = false;
                while (isExitFromAnimalOption == false)
                {
                    var animalOption = GetInt("0-Exit\n" +
                                           "1-Creat\n" +
                                           "2-Read\n");
                    switch (animalOption)
                    {
                        case 0:
                            isExitFromAnimalOption = true;
                            break;
                        case 1:
                            AddAnimal();
                            break;
                        case 2:
                            ShowAllAnimals();
                            break;
                     
                    }





                }

            }
            break;

        case 4:
            {
                var isExitFromTicketOption = false;
                while (isExitFromTicketOption == false)
                {
                    var ticketOption = GetInt("0-Exit\n" +
                                           "1-Creat\n" +
                                           "2-Read\n");
                    switch (ticketOption)
                    {
                        case 0:
                            isExitFromTicketOption = true;
                            break;
                        case 1:
                            CreatTicket();
                            break;
                        case 2:
                            ShowAllAnimals();
                            break;

                    }

                }

            }
            break;
        case 5:
            ShowZoosWithAnimals();
            break;
        case 6:
            ShowZoosWithSectionsWithTickets();
            break;




    }
}
//----------------------------------Services-----------------------------------------------\\
//----zoo----//
void CreatZoo()
{
    var title = GetString("pls enter title of zoo");
    var address = GetString("pls enter Address of zoo");
    var zoo = new Zoo(title, address);
    zooRepository.Add(zoo);
    context.SaveChanges();

}
void ShowZoos()
{
    var zoos = zooRepository.GetAll();
    foreach (var zoo in zoos)
        Console.WriteLine($"ID:{zoo.Id}\n" +
                          $"Title : {zoo.Title}\n" +
                          $"Address : {zoo.Address}");

}

void EditZoo()
{
    ShowZoos();
    var zooId = GetInt("pls select zoo id for edit");
    var zoo = zooRepository.GetById(zooId);
    zoo.Title = GetString("pls enter new title");
    zoo.Address = GetString("pls snter new address");
    context.SaveChanges();

}
void DeleteZoo()
{
    ShowZoos();
    var zooId = GetInt("pls select zoo id for Delete");
    var zoo = zooRepository.GetById(zooId);
    zooRepository.Delete(zoo);
    context.SaveChanges();
}
void ShowZoosWithAnimals()
{
    var zoosDto = zooRepository.GetAllZoosWithAnimals();
    foreach(var zoo in zoosDto)
    {
        foreach(var name in zoosDto.Select(_=>_.AnimalName).ToList())
        Console.WriteLine($"ID : {zoo.Id}\n" +
                          $"zoo title{zoo.Title}\n" +
                          $"zoo address : {zoo.Address}\n" +
                          $"animal name : {name}");
    }
}

void ShowZoosWithSectionsWithTickets()
{
    var result = zooRepository.GetZoosAndSectionsAndTickets();
   
}

//--------section----//
void CreatSection()
{
    var erea = GetDecimal("pls enter erea of section");
    var animalCount = GetInt("pls enter number of animal");
    var description = GetString("pls put a desciption for section");
    var section = new Section(erea, animalCount, description);
    ShowZoos();
    var zooId = GetInt("pls select a zoo for adding this section to it");
    section.ZooId = zooId;
    ShowAllAnimals();
    var animalId = GetInt("pls select an animal for section");
    section.AnimalId = animalId;
    sectionRepository.Add(section);
    context.SaveChanges();

}
void ShowSectionsWithAnimals()
{
    var sections = sectionRepository.GetAll();
    foreach (var section in sections)
        Console.WriteLine($"ID: {section.Id}\n" +
                          $"Erea : {section.Erea}\n" +
                          $"description : {section.Description}\n" +
                          $"Animal Type : {section.AnimalName}\n" +
                          $"Animal Count :{section.AnimalCount}");
}

void EditSection()
{
    ShowSectionsWithAnimals();
    int sectionId = GetInt("pls select a section for Edit ");
    var section = sectionRepository.GetById(sectionId);
    section.Description = GetString("pls enter new description for section");
    section.Erea = GetDecimal("pls enter new erea for section");
    section.AnimalCount = GetInt("pls enter new count for animal");
    section.Animal.Name = GetString("pls enter new animal type");
    context.SaveChanges();
}
void DeleteSection()
{
    ShowSectionsWithAnimals();
    int sectionId = GetInt("pls select a section for Delete ");
    var section = sectionRepository.GetById(sectionId);
    sectionRepository.Delete(section);
    context.SaveChanges();


}

//------animal------//
void AddAnimal()
{
    var name = GetString("pls enter type of animal ");
    var animal = new Animal(name);

    animalRepository.Add(animal);

    context.SaveChanges();

}
void ShowAllAnimals()
{
    var animals = animalRepository.GetAll();
    foreach(var animal in animals)
    {
        Console.WriteLine($"ID : {animal.Id}\n" +
                          $"Type : {animal.Name} ");
    }
}

//-------ticket------//

void CreatTicket()
{
    var count = GetInt("pls enter ccount of ticket");
    var cost = GetInt("pls enter cost of ticket");
    var ticket = new Ticket(cost,count);
    ShowSectionsWithAnimals();
    var sectionId = GetInt("pls select section of ticket");
    ticket.SectionId = sectionId;
    ticketRepository.Add(ticket);
    context.SaveChanges();

}















//---------------------------Get Int , get string--------------------\\
string GetString(string message)
{
    Console.WriteLine(message);
    var value = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(value))
    {

        Console.WriteLine("u entered null or white space.pls try again");
        value = Console.ReadLine();
    }

    return value;
}
int GetInt(string message)
{
    Console.WriteLine(message);
    int value = 0;
    var isValid = false;
    while (!isValid)
    {
        var input = Console.ReadLine();
        if (int.TryParse(input, out value))
        {
            isValid = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer:");
        }
    }
    return value;
}
decimal GetDecimal(string message)
{
    Console.WriteLine(message);
    decimal value = 0;
    var isValid = false;
    while (!isValid)
    {
        var input = Console.ReadLine();
        if (decimal.TryParse(input, out value))
        {
            isValid = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer:");
        }
    }
    return value;
}

