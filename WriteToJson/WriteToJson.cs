using FileTypeConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WriteToJson
{
    public class WriteToJson
    {


        public class Documentation
        {
            public List<TypeInfo> Types { get; set; }
        }

        public class TypeInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Input { get; set; }
            public string Output { get; set; }
        }



        public static void GetDocs()
        {

            var types = Assembly.GetExecutingAssembly().GetTypes();

            var documentation = new Documentation()
            {
                Types = new List<TypeInfo>()
            };

            // Group types by type
            var typesByType = types.GroupBy(t => t.IsClass).ToDictionary(g => g.Key, g => g.ToList());

            var classTypes = typesByType[true];

            var otherTypes = typesByType[false];

            // Add class types
            foreach (var type in classTypes)
            {
                var typeAttribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                if (typeAttribute != null)
                {
                    documentation.Types.Add(new TypeInfo()
                    {
                        Name = type.Name,

                        Description = typeAttribute.Description
                    });
                }

                // Get properties
                var properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var propertyAttribute = (DocumentAttribute)property.GetCustomAttribute(typeof(DocumentAttribute));

                    if (propertyAttribute != null)
                    {
                        documentation.Types.Add(new TypeInfo()
                        {
                            Name = property.Name,

                            Description = propertyAttribute.Description
                        });
                    }
                }

                // Get constructors
                var constructors = type.GetConstructors();

                foreach (var constructor in constructors)
                {
                    var constructorAttribute = (DocumentAttribute)constructor.GetCustomAttribute(typeof(DocumentAttribute));

                    if (constructorAttribute != null)
                    {
                        documentation.Types.Add(new TypeInfo()
                        {
                            Name = constructor.Name,

                            Description = constructorAttribute.Description
                        });
                    }
                }
                // Get methods
                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                    var methodAttribute = (DocumentAttribute)method.GetCustomAttribute(typeof(DocumentAttribute));

                    if (methodAttribute != null)
                    {
                        // Concatenate the names and types of the method's parameters into a single string, separated by commas
                        var input = string.Join(",", method.GetParameters().Select(x => x.ParameterType.Name + " " + x.Name));

                        var output = method.ReturnType.Name;

                        documentation.Types.Add(new TypeInfo()
                        {
                            Name = method.Name,

                            Description = methodAttribute.Description,

                            Input = input,

                            Output = output
                        });
                    }
                }
            }

            // Add other types
            foreach (var type in otherTypes)
            {
                var attribute = (DocumentAttribute)type.GetCustomAttribute(typeof(DocumentAttribute));

                if (attribute != null)
                {
                    documentation.Types.Add(new TypeInfo()
                    {
                        Name = type.Name,

                        Description = attribute.Description
                    });
                }
            }

            // Save the documentation to a json file
            SaveAsJsonFormat(documentation, "documentation.json");


            //Read from JSON file to console
            ReadFromJsonFile();
        }









        //serialization method for writing to a JSON file
        public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
        {

            var options = new JsonSerializerOptions
            {


                PropertyNameCaseInsensitive = true,

                PropertyNamingPolicy = null, //Pascal casing

                IncludeFields = true,

                WriteIndented = true,

                NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
            };

            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph, options));



        }



        public static void ReadFromJsonFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var documentation = ReadAsJsonFormat<Documentation>(options, "documentation.json");

            foreach (var type in documentation.Types)
            {
                Console.WriteLine($"Name: {type.Name}");

                Console.WriteLine($"Description: {type.Description}");

                if (!string.IsNullOrEmpty(type.Input))
                {
                    Console.WriteLine($"Input: {type.Input}");
                }

                if (!string.IsNullOrEmpty(type.Output))
                {
                    Console.WriteLine($"Output: {type.Output}");
                }


                Console.WriteLine();
            }

        }



        //deserialization method for the JSON file
        public static T ReadAsJsonFormat<T>(JsonSerializerOptions options, string fileName) => System.Text.Json.JsonSerializer.Deserialize<T>(File.ReadAllText(fileName), options);










    }


    /* public static void SaveAsJsonFormat<T>(T objGraph, string fileName)
     {
         var options = new JsonSerializerOptions
         {
             IncludeFields = true,
             WriteIndented = true
         };
         File.WriteAllText(fileName, JsonSerializer.Serialize(objGraph, options));
     }*/
}

