using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    class Order
    {
        public long OrderID { get; private set; }
        public DateTime OrderTime { get; private set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; private set; }      //总价
        public List<OrderItem> OrderItemList;

        public Order()
        {
            OrderTime = DateTime.Now;
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            OrderID = Convert.ToInt64(ts.TotalSeconds);     //使用时间戳作为订单号
            OrderItemList = new List<OrderItem>();
            TotalPrice = 0;
        }

        //添加明细
        public void AddOrderItem(OrderItem orderItem)
        {
            foreach(OrderItem item in OrderItemList)
            {
                if(item.Equals(orderItem))
                {
                    throw new DataException("Error: Adding a repeat order item is not allowed");
                }
            }

            OrderItemList.Add(orderItem);
            TotalPrice += orderItem.ProductPrice * orderItem.ProductAmount;
        }

        //删除明细
        public void RemoveOrderItem(OrderItem orderItem)
        {
            if(!OrderItemList.Remove(orderItem))
            {
                throw new DataException("Error: No such order item");
            }

            TotalPrice -= orderItem.ProductPrice * orderItem.ProductAmount;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("---------------------------------------------------\n");
            stringBuilder.Append($"Order ID: \t{OrderID}\n");
            stringBuilder.Append($"Order Time: \t{OrderTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            stringBuilder.Append($"Customer Name: \t{CustomerName}\n");
            stringBuilder.Append($"Address: \t{Address}\n");
            stringBuilder.Append("---------------------------------------------------\n");
            stringBuilder.Append("Order Details\n");
            foreach(OrderItem item in OrderItemList)
            {
                stringBuilder.Append("--------------------------\n");
                stringBuilder.Append($"{item}\n");
            }
            stringBuilder.Append("--------------------------\n");
            stringBuilder.Append($"Total Price: \tCNY￥{TotalPrice}\n");
            stringBuilder.Append("---------------------------------------------------");
            return stringBuilder.ToString();
        }
    }
}
