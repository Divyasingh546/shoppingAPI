using Microsoft.AspNetCore.SignalR;

namespace shoppingAPI_inMemoryCollection.Models
{
    public class Products
    {
        #region Properties
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public string pDescription { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }
        #endregion

        #region Data
        static List<Products> pList = new List<Products>()
        {
            new Products() {pId=101,pName="Pepsi",pCategory="Cold-Drink",pDescription="Cool black color water to kill the thurst",pIsInStock=true,pPrice=70},
            new Products() {pId=102,pName="IPhone",pCategory="Smart Phone",pDescription="Make Smart calls and videos",pIsInStock=true,pPrice=150000},
            new Products() {pId=103,pName="Fanta",pCategory="Cold-Drink",pDescription="Cool orange color water to kill the thurst",pIsInStock=false,pPrice=90},
            new Products() {pId=104,pName="Maggie",pCategory="Fast-Food",pDescription="Quick Junk food",pIsInStock=true,pPrice=150},
            new Products() {pId=105,pName="Dell Lattitude",pCategory="Electronics",pDescription="Attend a training",pIsInStock=true,pPrice=75000},
            new Products() {pId=106,pName="Air-Pods",pCategory="Electronics",pDescription="Listen Well",pIsInStock=true,pPrice=26000},
            new Products() {pId=107,pName="Boat Headphones",pCategory="Electronics",pDescription="Listen Well",pIsInStock=false,pPrice=3500},
            new Products() {pId=108,pName="Fossil Q",pCategory="Electronics",pDescription="Check the time",pIsInStock=true,pPrice=35000},
            new Products() {pId=109,pName="Samsung AC",pCategory="Electronics",pDescription="Feel Cold",pIsInStock=false,pPrice=48000},


        };
        #endregion

        #region Products
        public List<Products> GetAllProducts()
        {
            return pList;
        }

      
        public Products GetProductById(int pid)
        {
            var prod = pList.Find(p => p.pId == pid);
            if(prod!= null)
            {
                return prod;
            }
            else
            {
                throw new Exception("Product Not found");
            }
        }
        public List<Products>GetProductsByCategory(string category)
        {
            var products = pList.FindAll(p => p.pCategory == category);
            if (products.Count > 0)
            {
                return products;
            }
            else
            {
                throw new Exception("No Product for this category");
            }
        }

        public List<Products>GetProductsIsInStock(bool yesorno)
        {
            var products=pList.FindAll(p =>p.pIsInStock == yesorno);
            if(products.Count > 0)
            {
                return products;
            }
            else
            {
                throw new Exception("Please pass yes or no only");
            }
        }
        #endregion

        #region Methods
        public string AddNewProduct(Products newProduct)
        {
            pList.Add(newProduct);
            return "Product Added Successfully";
        }
        public string UpdateProduct(Products changes)
        {
            var prod = pList.Find(p => p.pId == changes.pId);
            if (prod != null)
            {
                prod.pName = changes.pName;
                prod.pCategory = changes.pCategory;
                prod.pPrice = changes.pPrice;
                prod.pIsInStock = changes.pIsInStock;
                return "Product Updated Successfully";
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public string DeleteProduct(int pid)
        {
            var prod = pList.Find(p => p.pId == pid);
            if(prod!= null)
            {
                pList.Remove(prod);
                return "Product Deleted Successfully";

            }
            else
            {
                throw new Exception("Product Not found");
            }
        }
        #endregion
    }
}
