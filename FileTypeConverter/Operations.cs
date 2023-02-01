using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace FileTypeConverter
{


    public class Operations
    {
        
        public static void WelcomeMsg()
        {
            Console.WriteLine("\n****************FileTypeConverter****************\n" + "\nOperations to perform...\n" + "Press 1 to convert the documentation to JSON format\n" +
                            "Press 2 to convert the documentation to PDF format\n" + "Press 3 to convert the documentation to TXT format\n" + "Press 4 to exit the app");

            
        }
        public static void Start()
        {
            try
            {
            //comeback: Console.WriteLine("Kindly make your selection....");
                WelcomeMsg();

                var option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Created Successfully!");
                        Console.Clear();
                        WriteToJson.GetDocs();
                        NextStep();
                        break;
                    case 2:
                        Console.WriteLine("Created Successfully!");
                        Console.Clear();
                        WriteToPDF.CreateAndReadPDF();
                        NextStep();
                        break;
                    case 3:
                        Console.WriteLine("Created Successfully!");
                        Console.Clear();
                        WriteToText.CreateAndWrite();
                        NextStep();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid selection, Kindly try again");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid selection, Kindly try again");
            }

        }
        public static void NextStep()
        {
        comebackhere: Console.WriteLine("\n press 1 to exit or 2 to continue");

            try
            {
                var newOption = int.Parse(Console.ReadLine());

                switch (newOption)
                {
                    case 1:

                        Environment.Exit(0);

                        break;

                    case 2:
                        Console.Clear();

                        Start();

                        //goto comeback;


                        break;


                    default:

                        Console.WriteLine("please enter a valid option");

                        goto comebackhere;


                        break;


                }

            }
            catch
            {
                Console.WriteLine("please enter a valid option");

                goto comebackhere;
            }

        }


        public static string GetDocs()
        {

            var types = Assembly.GetExecutingAssembly().GetTypes();


            string documentation = "";


            foreach (var type in types)
            {

                if (type.IsClass)
                {

                    var typeAttribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                    // If the class has the DocumentAttribute, add its documentation to the string

                    if (typeAttribute != null)
                    {
                        documentation += "Class: " + type.Name + "\n";

                        documentation += "Description: " + typeAttribute.Description + "\n";

                        documentation += "Input: " + typeAttribute.Input + "\n";

                        documentation += "Output: " + typeAttribute.Output + "\n\n";
                    }


                    var constructors = type.GetConstructors();


                    foreach (var constructor in constructors)
                    {

                        var constructorAttribute = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                        // If the constructor has the DocumentAttribute, add its documentation to the string

                        if (constructorAttribute != null)
                        {
                            documentation += "Constructor: " + constructor.Name + "\n";

                            documentation += "Description: " + constructorAttribute.Description + "\n";

                            documentation += "Input: " + constructorAttribute.Input + "\n";

                            documentation += "Output: " + constructorAttribute.Output + "\n\n";
                        }
                    }


                    var properties = type.GetProperties();


                    foreach (var property in properties)
                    {

                        var propertyAttribute = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                        // If the property has the DocumentAttribute, add its documentation to the string

                        if (propertyAttribute != null)
                        {
                            documentation += "Property: " + property.Name + "\n";

                            documentation += "Description: " + propertyAttribute.Description + "\n";

                            documentation += "Input: " + propertyAttribute.Input + "\n";

                            documentation += "Output: " + propertyAttribute.Output + "\n\n";
                        }
                    }
                }
                // Check if the type is an Enum

                else if (type.IsEnum)
                {
                    var typeattribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                    if (typeattribute != null)
                    {
                        documentation += "Enum: " + type.Name + "\n";

                        documentation += "Description: " + typeattribute.Description + "\n\n\n";
                    }
                }


                // Check if the type is an Interface
                else if (type.IsInterface)
                {
                    documentation += "Interface: " + type.Name + "\n\n";
                }
            }


            return documentation;
        }



        /* public readonly static StringBuilder Data = new StringBuilder();
         //public static List<ObjectData> @ObjectData { get; set; } = new List<ObjectData>();
         public static void GetDocs()
         {
             var assembly = Assembly.GetExecutingAssembly();

             Utility.PrintColorMessage(ConsoleColor.DarkCyan, "Assembly name: " + assembly.FullName);

             Console.WriteLine();

             Type[] types = assembly.GetTypes();



             foreach (Type type in types)
             {
                 DisplayType(type);

                 DisplayConstructor(type);

                 DisplayProperties(type);

                 DisplayMethods(type);

                 Console.WriteLine();

             }



         }



         private static void DisplayMethods(Type type)
         {
             var methods = type.GetMethods();

             foreach (var method in methods)
             {
                 var documentattribute = (DocumentAttribute)method.GetCustomAttribute(typeof(DocumentAttribute));

                 if (documentattribute != null)
                 {
                     Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Method: " + method.Name);

                     Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Description: " + documentattribute.Description);

                     if (!string.IsNullOrEmpty(documentattribute.Input))
                     {
                         Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Input: " + documentattribute.Input);
                     }

                     if (!string.IsNullOrEmpty(documentattribute.Output))
                     {
                         Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Output: " + documentattribute.Output + "\n");
                     }
                 }
             }
         }





         // Display properties

         private static void DisplayProperties(Type type)
         {

             var properties = type.GetProperties();

             foreach (var property in properties)
             {
                 //Gets custom attribute  to property variable. The returned attribute is then being assigned to the documentattribute variable.
                 var documentattribute = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                 if (documentattribute != null)
                 {
                     Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Property: " + property.Name);

                     Utility.PrintColorMessage(ConsoleColor.Cyan, "\t Description: " + documentattribute.Description + "\n");
                 }


             }
         }


         //// Display constructors
         private static void DisplayConstructor(Type type)
         {

             var constructors = type.GetConstructors();

             foreach (var constructor in constructors)
             {
                 var documentattribute = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                 if (documentattribute != null)
                 {
                     Utility.PrintColorMessage(ConsoleColor.Cyan, "\t Constructor: " + constructor.Name);

                     Utility.PrintColorMessage(ConsoleColor.Cyan, "\t Description: " + documentattribute.Description);

                     if (!string.IsNullOrEmpty(documentattribute.Input))
                     {
                         Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Input: " + documentattribute.Input);
                     }

                     if (!string.IsNullOrEmpty(documentattribute.Output))
                     {
                         Utility.PrintColorMessage(ConsoleColor.Yellow, "\t Output: " + documentattribute.Output + "\n");
                     }
                 }

             }
         }

         private static void DisplayType(Type type)
         {
             var documentAttribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

             if (documentAttribute != null && type.IsClass)
             {
                 Utility.PrintColorMessage(ConsoleColor.Yellow, "Class: " + type.Name);

                 Utility.PrintColorMessage(ConsoleColor.Yellow, "Description: " + documentAttribute.Description);

                 Console.WriteLine();

             }
             else if (documentAttribute != null && type.IsEnum)
             {
                 Utility.PrintColorMessage(ConsoleColor.Cyan, "Enum: " + type.Name);

                 Utility.PrintColorMessage(ConsoleColor.Cyan, "Description: " + documentAttribute.Description + "\n");

                 Console.WriteLine();
             }
             else if (documentAttribute != null && type.IsInterface)
             {
                 Utility.PrintColorMessage(ConsoleColor.Cyan, "Interface: " + type.Name);

                 Utility.PrintColorMessage(ConsoleColor.Cyan, "Description: " + documentAttribute.Description + "\n");
             }
         }*/
    }
}
