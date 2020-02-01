using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using P2FixAnAppDotNetCode.Models;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts() //Here, the brackets [] were removed and everything was refactored with the List syntax, including the Collections.Generic
        { //This happened in several other places where "Go to Definition" and "Go to Implementation" hotkeys turned specially useful.

            // TODO change the return type from array to List<T> and propagate the change
            // thoughout the application
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id) // Here we follow the same logic behind the foreach in AddItem method.
        {
            foreach (Product product in GetAllProducts()) //for each product in GetAllProducts we compare product.Id with the id being passed.
            {
                if (product.Id == id) // here is the product.Id being compared with the passed id in line 34
                {
                    return product; // If it matches, return the product. If it doesn't, return null, meaning product doesn't exist.
                }

            };                   
            // TODO implement the method
            return null; //This will result in the original error, except it only happens if we give a mystery id we do not have as opposed to any id regardless.
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            
            foreach (var productDecrementor in GetAllProducts()) // replace var with List<Product> to see what happens if anything***
            {
                if (productDecrementor.Id == cart.)  //Figure out what I have to compare it to
                {
                    _productRepository.UpdateProductStocks(productDecrementor.Id, 1); //Hover over and the method states to need productId and quantityToRemove, both int
                }
            }
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
        }
    }
}
