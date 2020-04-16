using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsOrderManage
{
    public class OrderService
    {
        public List<Order> OrderList { get; set; }

        public OrderService()
        {
            try
            {
                Import("orders.xml");
            }
            catch(FileNotFoundException)
            {
                OrderList = new List<Order>();      //没有orders.xml文件的话自行初始化OrderList
            }
        }

        public void AddOrder(Order order)
        {
            OrderList.Add(order);
        }

        public void AddOrderItem(Order order, OrderItem orderItem)
        {
            try
            {
                order.AddOrderItem(orderItem);
            }
            catch(ApplicationException e)
            {
                throw e;
            }
        }

        //根据订单号删除订单
        public void RemoveOrder(long orderID)
        {
            //foreach(Order order in OrderList)
            //{
            //    if(order.OrderID == orderID)
            //    {
            //        OrderList.Remove(order);
            //        return;
            //    }
            //}
            Order order = QueryByOrderID(orderID);

            if(order == null)
            {
                throw new ApplicationException("Error: No such order");
            }
            else
            {
                OrderList.Remove(order);
            }
        }

        //根据订单删除订单
        public void RemoveOrder(Order order)
        {
            OrderList.Remove(order);
        }

        public void RemoveOrderItem(Order order, OrderItem orderItem)
        {
            try
            {
                order.RemoveOrderItem(orderItem);
            }
            catch(ApplicationException e)
            {
                throw e;
            }
        }

        //根据订单号和类型修改订单
        //type-1 Modify Customer Name
        //type-2 Modify Address
        //modifiedContent 已修改的内容
        public void ModifyOrder(long orderID, int type, string modifiedContent)
        {
            //处理没有查询到订单的异常
            Order order = QueryByOrderID(orderID);

            if(order == null)
            {
                throw new ApplicationException("Error: No such order");
            }

            switch(type)
            {
                case 1:
                    order.CustomerName = modifiedContent;
                    break;
                case 2:
                    order.Address = modifiedContent;
                    break;
            }
        }

        //根据订单对象和类型修改订单
        //type-1 Modify Customer Name
        //type-2 Modify Address
        //modifiedContent 已修改的内容
        public void ModifyOrder(Order order, int type, string modifiedContent)
        {
            switch(type)
            {
                case 1:
                    order.CustomerName = modifiedContent;
                    break;
                case 2:
                    order.Address = modifiedContent;
                    break;
            }
        }

        //根据订单修改订单
        public void ModifyOrder(Order order, Order newOrder)
        {
            order = newOrder;
        }

        //根据订单号查询订单
        public Order QueryByOrderID(long orderID)
        {
            //var query = from s in OrderList
            //            where s.OrderID == orderID
            //            select s;
            var query = OrderList.Where(x => x.OrderID == orderID).OrderBy(s => s.TotalPrice);

            return query.FirstOrDefault();
        }

        //根据商品名称查询订单
        public List<Order> QueryByProductName(string queryContent)
        {
            var query = OrderList.Where(x => x.OrderItemList.Exists(y => y.ProductName.Contains(queryContent))).OrderBy(s => s.TotalPrice);

            return query.ToList();
        }

        //根据客户查询订单
        public List<Order> QueryByCustomerName(string queryContent)
        {
            //var query = from s in OrderList
            //            where s.CustomerName.Contains(queryContent)
            //            orderby s.TotalPrice
            //            select s;
            var query = OrderList.Where(x => x.CustomerName.Contains(queryContent)).OrderBy(s => s.TotalPrice);

            return query.ToList();
        }

        //默认排序方法，按照订单号排序
        public void SortOrderList()
        {
            OrderList.Sort((x, y) => (int)(x.OrderID - y.OrderID));
        }

        //使用Lambda表达式进行自定义排序
        //例如: SortOrderList((x,y)=> (int)(x.TotalPrice - y.TotalPrice));
        public void SortOrderList(Func<Order, Order, int> sortAction)
        {
            OrderList.Sort((x, y) => sortAction(x, y));
        }

        //将所有的订单序列化为XML文件
        public void Export(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, OrderList);
            }
        }

        //从XML文件中载入订单
        public void Import(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

            try
            {
                using(FileStream fs = new FileStream(path, FileMode.Open))
                {
                    OrderList = (List<Order>)xmlSerializer.Deserialize(fs);
                }
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
        }
    }
}
