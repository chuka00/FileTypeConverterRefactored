using System;
using System.Collections.Generic;
using System.Text;

namespace FileTypeConverter
{
    [Document("This class represents a Super Market", Input = " string Name, string Location, int Number of workers, int Number of products", Output = "none")]
    class SuperMarket : IRestockStore
    {
        string _name;
        String _location;
        private int _numberOfWorkers;
        private int _numOfProducts;

        [Document("This constructor initializes a new SuperMarket", Input = "string name, String location, int numberOfWorkers, int numOfProducts", Output = "none")]
        public SuperMarket(string name, String location, int numberOfWorkers, int numOfProducts)
        {
            string _name = name;
            string _location = location;
            _numberOfWorkers = numberOfWorkers;
            _numOfProducts = numOfProducts;
        }

        [Document("This method add a specified number of newProduct into the store", Input = "int newProduct", Output = "none")]
        public void RestockStore(int newProduct)
        {
            _numOfProducts += newProduct;
        }


        [Document("This method gets the inventory of the store", Input = "none", Output = "int representing the items in the store")]
        public int GetInventory()
        {
            return _numOfProducts;
        }
    }

    [Document("These are the types of items available in our store")]
    public enum StoreItemType
    {
        Diary = 1,
        Electronics,
        Alcohol
    }
}
