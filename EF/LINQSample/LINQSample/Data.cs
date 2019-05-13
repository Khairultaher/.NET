using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    public class Data
    {

        public List<User> Users
        {
            get;
            set;
        }

        public List<OrderMaster> OrderMasters
        {
            get;
            set;
        }

        public List<OrderDetail> OrderDetails
        {
            get;
            set;
        }

        public Data()
        {
            Users = new List<User>()
            {
                 new User(){ UserId = 101,UserName = "User A"}
                ,new User(){ UserId = 102,UserName = "User B"}
                ,new User(){ UserId = 103,UserName = "User C"}
            };

            OrderMasters = new List<OrderMaster>()
            {
                new OrderMaster(){  OrderId = 1, OrderDate = DateTime.Parse("2016-10-2"), OrderNo = "C1001", ShippingAddress = "Mumbai", TotalPrice = 2000, UserId = 101 }
               ,new OrderMaster(){  OrderId = 2, OrderDate = DateTime.Parse("2017-10-12"), OrderNo = "C1002", ShippingAddress = "Delhi", TotalPrice = 3950, UserId = 102 }
              
            };

            OrderDetails = new List<OrderDetail>()
            {
                  new OrderDetail(){ OrderDetailId = 1, OrderId = 1, UnitPrice = 1500, ProductId = 1, ProductName = "Shirt",  Qty = 1, UserId = 101 }
                , new OrderDetail(){ OrderDetailId = 2, OrderId = 1, UnitPrice = 200, ProductId = 2, ProductName = "Tie",  Qty = 1, UserId = 101 }
                , new OrderDetail(){ OrderDetailId = 3, OrderId = 1, UnitPrice = 300, ProductId = 3, ProductName = "Tee",  Qty = 1, UserId = 101 }
                , new OrderDetail(){ OrderDetailId = 4, OrderId = 1, UnitPrice = 150, ProductId = 4, ProductName = "Handkerchief",  Qty = 2, UserId = 101 }
                , new OrderDetail(){ OrderDetailId = 5, OrderId = 2, UnitPrice = 1000, ProductId = 5, ProductName = "Jeans",  Qty = 1, UserId = 102 }
                , new OrderDetail(){ OrderDetailId = 6, OrderId = 2, UnitPrice = 500, ProductId = 6, ProductName = "Tee",  Qty = 1, UserId = 102 }
                , new OrderDetail(){ OrderDetailId = 7, OrderId = 2, UnitPrice = 400, ProductId = 7, ProductName = "Shirt",  Qty = 5, UserId = 102 }
                , new OrderDetail(){ OrderDetailId = 8, OrderId = 2, UnitPrice = 150, ProductId = 4, ProductName = "Handkerchief",  Qty = 3, UserId = 102 }
            };
        }

    }
}
