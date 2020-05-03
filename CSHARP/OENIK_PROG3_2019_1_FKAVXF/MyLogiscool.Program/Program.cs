// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLogiscool.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using MyLogiscool.Data;
    using MyLogiscool.Logic;
    using MyLogiscool.Repository;

     /// <summary>
     /// Main program.
     /// </summary>
    internal class Program
    {
        /// <summary>
        /// Runs the upper layer of the menu,
        /// exits when number 8 was pressed.
        /// </summary>
        /// <param name="args">Stayed because why not.</param>
        private static void Main(string[] args)
        {
            while (MenuUpperLayer() != "8")
            {
            }

            Console.Clear();
            Console.WriteLine("Goodby");
            Console.ReadLine();
        }

        /// <summary>
        /// Upper layer of the menu,
        /// You can choose here which table do you wanna work in
        /// and you can use the not crud and java methods from here.
        /// </summary>
        private static string MenuUpperLayer()
        {
            Console.Clear();
            Console.WriteLine("Witch table do you want to work in?");
            Console.WriteLine("[1] 'Schools' table");
            Console.WriteLine("[2] 'Owners' table");
            Console.WriteLine("[3] 'Teachers' table");
            Console.WriteLine("[4] List hungarian teachers");
            Console.WriteLine("[5] List the owners who live in the same city as their schools");
            Console.WriteLine("[6] List the owner who has the most teahcers");
            Console.WriteLine("[7] List the owners who are fluent in Java, and the schools they own");
            Console.WriteLine();
            Console.WriteLine("[8] Exit");
            Console.WriteLine();
            Console.Write("Your choice: ");
            string tablechoose = Console.ReadLine();
            MainLogic ml = new MainLogic();
            switch (tablechoose)
            {
                case "1":
                    List<string> schoolFields = new List<string> { "School_Id", "Country", "City", "ZipCode", "Address", "NumberOfChildren" };
                    MenuLowerLayerSchools(ml, schoolFields);
                    break;
                case "2":
                    List<string> ownerFields = new List<string> { "Owner_Id", "Name", "City", "StartYear", "HasPaidThisYear", "IsReplaceable" };
                    MenuLowerLayerOwners(ml, ownerFields);
                    break;
                case "3":
                    List<string> teacherFields = new List<string> { "Teacher_Id", "School_Id", "Name", "Salary", "StartYear", "WellLiked", "CourseNumber", "HealthCare" };
                    MenuLowerLayerTeachers(ml, teacherFields);
                    break;
                case "4":
                    foreach (var item in ml.HungarianTeachers())
                    {
                        Console.WriteLine(item.Teacher_Id + " | " + item.School_Id + " | " + item.Name + " | " + item.Salary + " | " + item.StartYear + " | " + item.WellLiked + " | " + item.CourseNumber + " | " + item.HealthCare);
                    }

                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
                case "5":
                    foreach (var item in ml.OwnerLivesInCityWhereSchoolIs())
                    {
                        Console.WriteLine(item.Owner_Id + " | " + item.Name + " | " + item.City + " | " + item.StartYear + " | " + item.HasPaidThisYear + " | " + item.IsReplaceable);
                    }

                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
                case "6":
                    var retown = ml.OwnerWithMostTeachers();
                    Console.WriteLine(retown.Owner_Id + " | " + retown.Name);
                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
                case "7":
                    var urlString = @"http://localhost:8080/LogiscoolJavaEndPoint/AllLogi";
                    JavaXmlOwners(urlString);
                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
            }
            return tablechoose;
        }

        /// <summary>
        /// You can select Schools CRUD methods here.
        /// </summary>
        /// <param name="ml">Business Logic.</param>
        /// <param name="fields">Field names of the selected table.</param>
        private static void MenuLowerLayerSchools(MainLogic ml, List<string> fields)
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[1] Create");
            Console.WriteLine("[2] Read");
            Console.WriteLine("[3] ReadAll");
            Console.WriteLine("[4] Update");
            Console.WriteLine("[5] Delete");
            Console.WriteLine();
            Console.Write("Your choice: ");
            string crudchoice = Console.ReadLine();
            Console.Clear();
            switch (crudchoice)
            {
                case "1":
                    List<string> createTemp = DataGather(fields.Count, fields);
                    Schools s = new Schools
                    {
                        School_Id = int.Parse(createTemp.ElementAt(0)),
                        Country = createTemp.ElementAt(1),
                        City = createTemp.ElementAt(2),
                        ZipCode = int.Parse(createTemp.ElementAt(3)),
                        Address = createTemp.ElementAt(4),
                        NumberOfChildren = int.Parse(createTemp.ElementAt(5)),
                    };
                    ml.CreateSchools(s);
                    break;
                case "2":
                    int id = IDGather();
                    var readTemp = ml.ReadSchools(id);
                    Console.WriteLine("\n" + readTemp.School_Id + " | " + readTemp.Country + " | " + readTemp.City + " | " + readTemp.ZipCode + " | " + readTemp.Address + " | " + readTemp.NumberOfChildren);
                    break;
                case "3":
                    var schoolLogicTemp = ml.ReadAllSchools();
                    foreach (var item in schoolLogicTemp)
                    {
                        Console.WriteLine(item.School_Id + " | " + item.Country + " | " + item.City + " | " + item.ZipCode + " | " + item.Address + " | " + item.NumberOfChildren);
                    }

                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    var updateTemp = DataGather(fields.Count, fields);
                    Schools s2 = new Schools
                    {
                        School_Id = int.Parse(updateTemp.ElementAt(0)),
                        Country = updateTemp.ElementAt(1),
                        City = updateTemp.ElementAt(2),
                        ZipCode = int.Parse(updateTemp.ElementAt(3)),
                        Address = updateTemp.ElementAt(4),
                        NumberOfChildren = int.Parse(updateTemp.ElementAt(5)),
                    };
                    ml.UpdateSchools(s2);
                    break;
                case "5":
                    var deleteTemp = IDGather();
                    ml.DeleteSchools(deleteTemp);
                    break;
            }
        }

        /// <summary>
        /// You can select Owners CRUD methods here.
        /// </summary>
        /// <param name="ml">Business Logic.</param>
        /// <param name="fields">Field names of the selected table.</param>
        private static void MenuLowerLayerOwners(MainLogic ml, List<string> fields)
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[1] Create");
            Console.WriteLine("[2] Read");
            Console.WriteLine("[3] ReadAll");
            Console.WriteLine("[4] Update");
            Console.WriteLine("[5] Delete");
            Console.WriteLine();
            Console.Write("Your choice: ");
            string crudchoice = Console.ReadLine();
            Console.Clear();
            switch (crudchoice)
            {
                case "1":
                    List<string> createTemp = DataGather(fields.Count, fields);
                    Owners o = new Owners
                    {
                        Owner_Id = int.Parse(createTemp.ElementAt(0)),
                        Name = createTemp.ElementAt(1),
                        City = createTemp.ElementAt(2),
                        StartYear = int.Parse(createTemp.ElementAt(3)),
                        HasPaidThisYear = bool.Parse(createTemp.ElementAt(4)),
                        IsReplaceable =bool.Parse(createTemp.ElementAt(5)),
                    };
                    ml.CreateOwners(o);
                    break;
                case "2":
                    int id = IDGather();
                    var readTemp = ml.ReadOwners(id);
                    Console.WriteLine("\n" + readTemp.Owner_Id + " | " + readTemp.Name + " | " + readTemp.City + " | " + readTemp.StartYear + " | " + readTemp.HasPaidThisYear + " | " + readTemp.IsReplaceable);
                    break;
                case "3":
                    var schoolLogicTemp = ml.ReadAllOwners();
                    foreach (var item in schoolLogicTemp)
                    {
                        Console.WriteLine(item.Owner_Id + " | " + item.Name + " | " + item.City + " | " + item.StartYear + " | " + item.HasPaidThisYear + " | " + item.IsReplaceable);
                    }

                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    var updateTemp = DataGather(fields.Count, fields);
                    Owners o2 = new Owners
                    {
                        Owner_Id = int.Parse(updateTemp.ElementAt(0)),
                        Name = updateTemp.ElementAt(1),
                        City = updateTemp.ElementAt(2),
                        StartYear = int.Parse(updateTemp.ElementAt(3)),
                        HasPaidThisYear = bool.Parse(updateTemp.ElementAt(4)),
                        IsReplaceable = bool.Parse(updateTemp.ElementAt(5)),
                    };
                    ml.UpdateOwners(o2);
                    break;
                case "5":
                    var deleteTemp = IDGather();
                    ml.DeleteOwners(deleteTemp);
                    break;
            }
        }

        /// <summary>
        /// You can select Teachers CRUD methods here.
        /// </summary>
        /// <param name="ml">Business Logic.</param>
        /// <param name="fields">Field names of the selected table.</param>
        private static void MenuLowerLayerTeachers(MainLogic ml, List<string> fields)
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[1] Create");
            Console.WriteLine("[2] Read");
            Console.WriteLine("[3] ReadAll");
            Console.WriteLine("[4] Update");
            Console.WriteLine("[5] Delete");
            Console.WriteLine();
            Console.Write("Your choice: ");
            string crudchoice = Console.ReadLine();
            Console.Clear();
            switch (crudchoice)
            {
                case "1":
                    List<string> createTemp = DataGather(fields.Count, fields);
                    Teachers t = new Teachers
                    {
                        Teacher_Id = int.Parse(createTemp.ElementAt(0)),
                        School_Id = int.Parse(createTemp.ElementAt(1)),
                        Name = createTemp.ElementAt(2),
                        Salary = int.Parse(createTemp.ElementAt(3)),
                        StartYear = int.Parse(createTemp.ElementAt(4)),
                        WellLiked = bool.Parse(createTemp.ElementAt(5)),
                        CourseNumber = int.Parse(createTemp.ElementAt(6)),
                        HealthCare = createTemp.ElementAt(7),
                    };
                    ml.CreateTeachers(t);
                    break;
                case "2":
                    int id = IDGather();
                    var readTemp = ml.ReadTeachers(id);
                    Console.WriteLine(readTemp.Teacher_Id + " | " + readTemp.School_Id + " | " + readTemp.Name + " | " + readTemp.Salary + " | " + readTemp.StartYear + " | " + readTemp.WellLiked + " | " + readTemp.CourseNumber + " | " + readTemp.HealthCare);
                    break;
                case "3":
                    var ownerLogicTemp = ml.ReadAllTeachers();
                    foreach (var item in ownerLogicTemp)
                    {
                        Console.WriteLine(item.Teacher_Id + " | " + item.School_Id + " | " + item.Name + " | " + item.Salary + " | " + item.StartYear + " | " + item.WellLiked + " | " + item.CourseNumber + " | " + item.HealthCare);
                    }

                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    var updateTemp = DataGather(fields.Count, fields);
                    Teachers t2 = new Teachers
                    {
                        Teacher_Id = int.Parse(updateTemp.ElementAt(0)),
                        School_Id = int.Parse(updateTemp.ElementAt(1)),
                        Name = updateTemp.ElementAt(2),
                        Salary = int.Parse(updateTemp.ElementAt(3)),
                        StartYear = int.Parse(updateTemp.ElementAt(4)),
                        WellLiked = bool.Parse(updateTemp.ElementAt(5)),
                        CourseNumber = int.Parse(updateTemp.ElementAt(6)),
                        HealthCare = updateTemp.ElementAt(7),
                    };
                    ml.UpdateTeachers(t2);
                    break;
                case "5":
                    var deleteTemp = IDGather();
                    ml.DeleteTeachers(deleteTemp);
                    break;
            }
        }

        /// <summary>
        /// Gathers the data for Create, Update and Delete CRUD methods.
        /// </summary>
        /// <param name="number">Number of fields.</param>
        /// <param name="fields">Name of fields.</param>
        /// <returns>List of data to the desired table.</returns>
        private static List<string> DataGather(int number, List<string> fields)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < number; i++)
            {
                Console.Write(fields.ElementAt(i) + ": ");
                temp.Add(Console.ReadLine());
            }

            return temp;
        }

        /// <summary>
        /// Gathers the ID for Delete and Read CRUD methods.
        /// </summary>
        /// <returns>The ID.</returns>
        private static int IDGather()
        {
            Console.Write("ID: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Formats the Xml from Java to XDoc and call the JavaConvert method.
        /// </summary>
        /// <param name="url">Url of the Xml.</param>
        private static void JavaXmlOwners(string url)
        {
            var client = new WebClient();
            string temp = client.DownloadString(url);
            XDocument xdoc = XDocument.Parse(temp);
            JavaConvert(xdoc);
        }

        /// <summary>
        /// Writes to console, the Xdox that we converted from the Java endpoint.
        /// </summary>
        /// <param name="xdoc">An XDoc that contains the data from the Java endpoint.</param>
        private static void JavaConvert(XDocument xdoc)
        {
            List<Owners> tempOwnerList = new List<Owners>();
            List<Schools> tempSchoolsList = new List<Schools>();
            foreach (var item in xdoc.Descendants("owners"))
            {
                var tempOwner = new Owners
                {
                    Owner_Id = int.Parse(item.Element("owner_ID").Value),
                    Name = item.Element("name").Value,
                    City = item.Element("city").Value,
                    StartYear = int.Parse(item.Element("startYear").Value),
                    HasPaidThisYear = bool.Parse(item.Element("hasPaidThisYear").Value),
                    IsReplaceable = bool.Parse(item.Element("isReplaceable").Value),
                };
                if (!tempOwnerList.Contains(tempOwner))
                {
                    tempOwnerList.Add(tempOwner);
                }
            }

            foreach (var item2 in xdoc.Descendants("schools"))
                {
                    var tempSchool = new Schools
                    {
                        School_Id = int.Parse(item2.Element("school_ID").Value),
                        Country = item2.Element("country").Value,
                        City = item2.Element("city").Value,
                        ZipCode = int.Parse(item2.Element("zipCode").Value),
                        Address = item2.Element("address").Value,
                        NumberOfChildren = int.Parse(item2.Element("numberOfChildren").Value),
                    };
                    if (!tempSchoolsList.Contains(tempSchool))
                    {
                        tempSchoolsList.Add(tempSchool);
                    }
            }

            foreach (var item in tempOwnerList)
            {
                Console.WriteLine(item.Owner_Id + " | " + item.Name + " | " + item.City + " | " + item.StartYear + " | " + item.HasPaidThisYear + " | " + item.IsReplaceable);
            }

            foreach (var item in tempSchoolsList)
            {
                Console.WriteLine(item.School_Id + " | " + item.Country + " | " + item.City + " | " + item.ZipCode + " | " + item.Address + " | " + item.NumberOfChildren);
            }
        }
    }
}
