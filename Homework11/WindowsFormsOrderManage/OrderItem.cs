using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderManage
{
    //订单明细
    [Serializable]
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        public int ProductAmount { get; set; }

        public int OrderId { get; set; } //自动识别为外键
        public Order Order { get; set; }  //多对一关联

        //重写Equals方法比较订单明细不使其重复
        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   OrderItemId == item.OrderItemId &&
                   ProductName == item.ProductName &&
                   ProductPrice == item.ProductPrice &&
                   ProductAmount == item.ProductAmount &&
                   OrderId == item.OrderId &&
                   EqualityComparer<Order>.Default.Equals(Order, item.Order);
        }

        public override int GetHashCode()
        {
            var hashCode = 525988058;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + ProductPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + ProductAmount.GetHashCode();
            return hashCode;
        }

        public override string ToString() =>
            $"Product Name: \t{ProductName}\nProduct Price: \tCNY￥{ProductPrice}\nProduct Amount: {ProductAmount}";
    }
}
