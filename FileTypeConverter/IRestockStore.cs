using System;
using System.Collections.Generic;
using System.Text;

namespace FileTypeConverter
{
    [Document("This is an interface for RestockStore", Input = "int newProduct", Output = "none")]
    internal interface IRestockStore
    {
        void RestockStore(int newProduct);
    }
}
