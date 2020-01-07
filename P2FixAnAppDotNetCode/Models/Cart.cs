using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> _cartLines = new List<CartLine>(); // This will will retain the CartLines, this is the "Cart"
        /// <summary>
        /// Read-only property for dispaly only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            //return new List<CartLine>(); //Here it used to return a brand new list of empty Cartline
            return _cartLines; // _cartLines it just returns _cartLines from line 11 that is storing our List of Cartline

        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            //NEW Todo does product already exist in the cart? If it does increase it's quantity of the item by "1" in the cart
            //If it doesn't exist in the cart, just add it
            // TODO implement the method


            FindProductInCartLines(product.Id); //returns product in cart if one is found
            CartLine cartItem = new CartLine(); // I need to create a new Cartline because I need to add it to a List of CartLine
            
            cartItem.Product = product;
            cartItem.Quantity = quantity;
            
           _cartLines.Add(cartItem);

            //var test = GetCartLineList(); To test population
                 }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            return 0.0;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            //var product = GetCartLineList().FirstOrDefault(p => p.Product.Id == productId); //we're creating a lambda expression to look for the product id within the object
            //return null;
            foreach (var cartItem in GetCartLineList()) {
                if (cartItem.Product.Id == productId)
                {

                    return cartItem.Product;
                }
                /*
                 We return the cartline list and check each cartItem one by one comparing them with productId
                 if productId is true, we return the product in the cart
                */
            }
            return null; //return nothing if nothing is found
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine //contains three properties
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
