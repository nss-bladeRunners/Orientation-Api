using OrientationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationAPI.Services
{
    public static class OrderPlacement
    {
        public static int AddLineItem(LineItemDto lineItem)
        {
            if (CheckForAvailableProduct(lineItem.ProductId) && CheckForOpenOrder(lineItem.OrderId))
            {
                var repo = new LineItemRepository(); 
                var dbResult = repo.Create(lineItem);
                if (dbResult == 1) return DecrementQuantity(lineItem.ProductId); 
            }
            return 0; 
        }

        private static bool CheckForAvailableProduct(int productId)
        {
            var repo = new ProductRepository();
            var stock = repo.GetQuantityInStock(productId);
            return (stock > 0) ? true : false;  
        }

        private static bool CheckForOpenOrder(int orderId)
        {
            var repo = new OrderRepository();
            var isClosed = repo.GetIsClosedStatus(orderId);
            return (isClosed == 0) ? true : false;
        }

        private static int DecrementQuantity(int productId)
        {
            var repo = new ProductRepository();
            return repo.DecrementQuanity(productId);
        }
    }
}