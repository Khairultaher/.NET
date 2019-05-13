using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Data context = new Data();

            #region Simple Query
            Console.WriteLine("---Simple Query-------------------------------------------");
            var result1 = from order in context.OrderMasters
                          where order.OrderDate < DateTime.Now.AddDays(-100)
                          select order;

            var lresult1 = context.OrderMasters
                           .Where(a => a.OrderDate < DateTime.Now.AddDays(-100))
                           .Select(s => s);

            Console.WriteLine(string.Format("OrderNo \t OrderDate"));
            foreach (var item in result1)
            {
                Console.WriteLine(string.Format("{0}\t{1}", item.OrderNo, item.OrderDate));

            }
            #endregion

            #region Join with single field
            Console.WriteLine("---Join with single field-------------------------------------------");
            var result2 = from order in context.OrderMasters
                          join orderdetail in context.OrderDetails on order.OrderId equals orderdetail.OrderId
                          //where order.OrderDate < DateTime.Now.AddDays(-10)
                          select new
                          {
                              order.OrderNo,
                              orderdetail.ProductName,
                              order.OrderDate
                          };

            var lresult2 = context.OrderMasters
                           .Join(context.OrderDetails,
                                 od => od.OrderId,
                                 o => o.OrderId,
                                (o, od) => new
                            {
                                o.OrderNo,
                                od.ProductName,
                                o.OrderDate
                            })
                //.Where(a => a.OrderDate < DateTime.Now.AddDays(-100))
                           .Select(s => s);

            Console.WriteLine(string.Format("OrderNo \t OrderDate \t Product"));
            foreach (var item in lresult2)
            {
                Console.WriteLine(string.Format("{0}\t{1}\t{2}", item.OrderNo, item.OrderDate, item.ProductName));

            }
            #endregion

            #region Join with multiple field
            Console.WriteLine("---Join with multi field-------------------------------------------");
            var result3 = from order in context.OrderMasters
                          join orderdetail in context.OrderDetails
                          on new { order.OrderId, order.UserId } equals new { orderdetail.OrderId, orderdetail.UserId }
                          //where order.OrderDate < DateTime.Now.AddDays(-10)
                          select new
                          {
                              order.OrderNo,
                              orderdetail.ProductName,
                              order.OrderDate,
                              order.UserId
                          };

            var lresult3 = context.OrderMasters
                            .Join(context.OrderDetails,
                            od => new { od.OrderId, od.UserId },
                            o => new { o.OrderId, o.UserId },
                            (o, od) => new
                            {
                                o.OrderNo ,
                                od.ProductName,
                                o.OrderDate,
                                o.UserId
                            })
                //.Where(a => a.OrderDate < DateTime.Now.AddDays(-100))
                           .Select(s => s);

            Console.WriteLine(string.Format("OrderNo \t OrderDate \t UserId \t Product"));
            foreach (var item in lresult3)
            {
                Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", item.OrderNo, item.OrderDate, item.UserId, item.ProductName));

            }
            #endregion

            #region Left Join
            var leftJOin = (from u in context.Users
                            join o in context.OrderMasters on u.UserId equals o.UserId into usrOrd

                            from uo in usrOrd.DefaultIfEmpty()
                            select new
                            {
                                u.UserId,
                                u.UserName,
                                uo

                            }).Where(w=>w.uo == null);
                           #endregion

            #region group by
            Console.WriteLine("---group by-------------------------------------------");
            var result4 = from orderdetail in context.OrderDetails
                          where orderdetail.UnitPrice > 1000
                          group orderdetail by orderdetail.OrderId into grp
                          orderby grp.Key
                          select grp;

            var lresult4 = context.OrderDetails
                           .GroupBy(orderdetail => orderdetail.OrderId)
                           .OrderBy(d => d.Key);

            Console.WriteLine(string.Format("Order Id"));
            foreach (var item in lresult4)
            {
                Console.WriteLine(string.Format("{0}", item.Key));

            }
            #endregion

            #region group by with multiple fields
            Console.WriteLine("---group by with multiple fields-------------------------------------------");
            var result5 = from orderdetail in context.OrderDetails
                          where orderdetail.UnitPrice > 1000
                          group orderdetail by new { orderdetail.OrderId, orderdetail.UserId } into grp
                          orderby grp.Key.OrderId
                          select grp;

            var lresult5 = context.OrderDetails
                           .GroupBy(orderdetail => new { orderdetail.OrderId, orderdetail.UserId })
                           .OrderBy(d => d.Key.OrderId)
                           .Select(s => s);

            Console.WriteLine(string.Format("Order Id \t User Id"));
            foreach (var item in lresult5)
            {
                Console.WriteLine(string.Format("{0} \t {1}", item.Key.OrderId, item.Key.UserId));

            }
            #endregion

            #region group join (used for hierarchy result)
            Console.WriteLine("---groupjoin-------------------------------------------");
            var result6 = from order in context.OrderMasters
                          join orderdetail in context.OrderDetails
                          on order.OrderId equals orderdetail.OrderId
                          into grp
                          //where order.OrderDate < DateTime.Now.AddDays(-10)
                          select new
                          {
                              Order = order,
                              OrderD = grp
                          };

            var lresult6 = context.OrderMasters
                            .GroupJoin(context.OrderDetails,
                            od => od.OrderId,
                            o => o.OrderId,
                            (o, od) => new
                            {
                                Order = o
                               ,
                                OrderD = od
                                //,o.OrderDate
                            })
                //.Where(a => a.OrderDate < DateTime.Now.AddDays(-100))
                           .Select(s => s);


            foreach (var item in lresult6)
            {
                Console.WriteLine(string.Format("=> Order No: {0}", item.Order.OrderNo));
                Console.WriteLine(string.Format("Qty \t Price \t Product"));
                foreach (var i in item.OrderD)
                {
                    Console.WriteLine(string.Format("{0} \t {1} \t {2}", i.Qty, i.UnitPrice, i.ProductName));
                }


            }
            #endregion

            #region Aggregate function
            Console.WriteLine("---Aggregate function-------------------------------------------");
            var result7 = from orderdetail in context.OrderDetails
                          join order in context.OrderMasters on orderdetail.OrderId equals order.OrderId
                          group orderdetail by new { orderdetail.OrderId, order.OrderNo } into grp
                          orderby grp.Key.OrderNo
                          select new { OrderNo = grp.Key.OrderNo, TotalAmt = grp.Sum(f => (f.UnitPrice * f.Qty)) };

            var lresult7 = context.OrderDetails
                           .Join(context.OrderMasters
                           , orderdetail => orderdetail.OrderId
                           , order => order.OrderId
                           , (orderdetail, order) => new { order, orderdetail })
                           .GroupBy(od => new { od.orderdetail.OrderId, od.order.OrderNo })
                           .OrderBy(d => d.Key.OrderNo)
                           .Select(grp => new { OrderNo = grp.Key.OrderId, TotalAmt = grp.Sum(f => (f.orderdetail.UnitPrice * f.orderdetail.Qty)) });

            Console.WriteLine(string.Format("OrderNo \t TotalAmt"));
            foreach (var item in result7)
            {
                Console.WriteLine(string.Format("{0} \t {1}", item.OrderNo, item.TotalAmt));

            }
            
            #endregion

            #region Union
            var union = (from o in context.OrderMasters
                         where o.OrderId == 1
                         select o
                        ).Union(
                        from o in context.OrderMasters
                        where o.OrderId == 2
                        select o
                        );


            var unionAll = (from o in context.OrderMasters
                         //where o.OrderId == 1
                         select o
                        ).Concat(
                        from o in context.OrderMasters
                        where o.OrderId == 2
                        select o
                        );

            #endregion

            Console.ReadLine();
        }
    }
}

