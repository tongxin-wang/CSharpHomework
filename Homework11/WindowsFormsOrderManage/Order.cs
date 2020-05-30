using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderManage
{
    [Serializable]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }      //总价
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderTime = DateTime.Now;
            OrderItems = new List<OrderItem>();
            TotalPrice = 0;
        }

        //添加明细
        public void AddOrderItem(OrderItem orderItem)
        {
            foreach(OrderItem item in OrderItems)
            {
                if(item.Equals(orderItem))
                {
                    throw new ApplicationException("Error: Adding a repeat order item is not allowed");
                }
            }

            OrderItems.Add(orderItem);
            TotalPrice += orderItem.ProductPrice * orderItem.ProductAmount;
        }

        //删除明细
        public void RemoveOrderItem(OrderItem orderItem)
        {
            if(!OrderItems.Remove(orderItem))
            {
                throw new ApplicationException("Error: No such order item");
            }

            TotalPrice -= orderItem.ProductPrice * orderItem.ProductAmount;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("---------------------------------------------------\n");
            stringBuilder.Append($"Order ID: \t{OrderId}\n");
            stringBuilder.Append($"Order Time: \t{OrderTime.ToString("yyyy-MM-dd HH:mm:ss")}\n");
            stringBuilder.Append($"Customer Name: \t{CustomerName}\n");
            stringBuilder.Append($"Address: \t{Address}\n");
            stringBuilder.Append("---------------------------------------------------\n");
            stringBuilder.Append("Order Details\n");
            foreach(OrderItem item in OrderItems)
            {
                stringBuilder.Append("--------------------------\n");
                stringBuilder.Append($"{item}\n");
            }
            stringBuilder.Append("--------------------------\n");
            stringBuilder.Append($"Total Price: \tCNY￥{TotalPrice}\n");
            stringBuilder.Append("---------------------------------------------------");
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderId == order.OrderId &&
                   OrderTime == order.OrderTime &&
                   CustomerName == order.CustomerName &&
                   Address == order.Address &&
                   TotalPrice == order.TotalPrice &&
                   EqualityComparer<List<OrderItem>>.Default.Equals(OrderItems, order.OrderItems);
        }

        public override int GetHashCode()
        {
            var hashCode = -765576449;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + OrderTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            return hashCode;
        }
    }
}
