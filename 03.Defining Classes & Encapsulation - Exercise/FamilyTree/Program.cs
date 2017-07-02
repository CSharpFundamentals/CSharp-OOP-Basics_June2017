namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var allPeople = new List<Person>();
            var searchedPerson = Console.ReadLine();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                if (inputLine.Contains("-"))
                {
                    var tokens = inputLine
                        .Split('-')
                        .Select(x => x.Trim())
                        .ToArray();

                    var parentParam = tokens[0];
                    var childParam = tokens[1];

                    var parent = new Person();
                    if (parentParam.Contains("/"))
                    {
                        parent.BirthDate = parentParam;
                    }
                    else
                    {
                        parent.Name = parentParam;
                    }

                    var child = new Person();
                    if (childParam.Contains("/"))
                    {
                        child.BirthDate = childParam;
                    }
                    else
                    {
                        child.Name = childParam;
                    }

                    AddParentIfMissing(allPeople, parent);

                    if (parent.Name != null)
                    {
                        allPeople.FirstOrDefault(p => p.Name == parent.Name).AddChild(child);
                    }
                    else
                    {
                        allPeople.FirstOrDefault(p => p.BirthDate == parent.BirthDate).AddChild(child);
                    }
                }
                else
                {
                    var tokens = inputLine.Split(' ');

                    var name = $"{tokens[0]} {tokens[1]}";
                    var date = tokens[2];
                    var added = false;

                    for (int i = 0; i < allPeople.Count; i++)
                    {
                        if (allPeople[i].Name == name)
                        {
                            allPeople[i].BirthDate = date;
                            added = true;
                        }

                        if (allPeople[i].BirthDate == date)
                        {
                            allPeople[i].Name = name;
                            added = true;
                        }

                        allPeople[i].AddChildrenInfo(name,date);
                    }

                    if (!added)
                    {
                        allPeople.Add(new Person(name, date));
                    }
                }
            }

            PrintParentsAndChildren(allPeople, searchedPerson);
        }

        private static void PrintParentsAndChildren(List<Person> allPeople, string searchedPersonParam)
        {
            Person personWithTree;
            if (searchedPersonParam.Contains("/"))
            {
                personWithTree = allPeople.FirstOrDefault(p => p.BirthDate == searchedPersonParam);
            }
            else
            {
                personWithTree = allPeople.FirstOrDefault(p => p.Name == searchedPersonParam);
            }

            var result = new StringBuilder();
            result.AppendLine($"{personWithTree.Name} {personWithTree.BirthDate}");

            result.AppendLine("Parents:");
            foreach (var parent in allPeople.Where(p => p.FindChildName(personWithTree.Name) != null))
            {
                result.AppendLine($"{parent.Name} {parent.BirthDate}");
            }

            result.AppendLine("Children:");
            foreach (var child in allPeople.FirstOrDefault(p => p.Name == personWithTree.Name).Children)
            {
                result.AppendLine($"{child.Name} {child.BirthDate}");
            }

            Console.WriteLine(result);
        }

        private static void AddParentIfMissing(List<Person> allPeople, Person parent)
        {
            if (parent.Name != null && allPeople.Any(p => p.Name == parent.Name))
            {
                return;
            }

            if (parent.BirthDate != null && allPeople.Any(p => p.BirthDate == parent.BirthDate))
            {
                return;
            }

            allPeople.Add(parent);
        }
    }
}
