using System;
using System.Collections.Generic;
using System.Text;

namespace FileTypeConverter
{
    [AttributeUsage(AttributeTargets.All)]
    public class DocumentAttribute : Attribute
    {

        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }

        public DocumentAttribute(string description)
        {
            Description = description;
        }

        public DocumentAttribute(string description, string input, string output)
        {
            Description = description;
            Input = input;
            Output = output;
        }



    }
}
