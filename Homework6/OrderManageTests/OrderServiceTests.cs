using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service;
        OrderItem laptop = new OrderItem
        {
            ProductName = "Laptop",
            ProductPrice = 6999,
            ProductAmount = 1
        };
        OrderItem keyboard = new OrderItem
        {
            ProductName = "Keyboard",
            ProductPrice = 899,
            ProductAmount = 1
        };
        OrderItem mouse = new OrderItem
        {
            ProductName = "Mouse",
            ProductPrice = 268,
            ProductAmount = 1
        };

        [TestInitialize()]
        public void OrderServiceTest()
        {
            service = new OrderService();
            Order order1 = new Order
            {
                CustomerName = "Wong",
                Address = "Wuhan",
            };
            Order order2 = new Order
            {
                CustomerName = "Zhang",
                Address = "Wuhan",
            };
            Order order3 = new Order
            {
                CustomerName = "Fang",
                Address = "Wuhan",
            };
            service.AddOrderItem(order1, laptop);
            service.AddOrderItem(order2, laptop);
            service.AddOrderItem(order2, keyboard);
            service.AddOrderItem(order3, laptop);
            service.AddOrderItem(order3, keyboard);
            service.AddOrderItem(order3, mouse);
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Order order = new Order
            {
                CustomerName = "Test",
                Address = "Wuhan"
            };
            service.AddOrderItem(order, laptop);
            service.AddOrder(order);
            Assert.AreEqual(4, service.OrderList.Count);
            CollectionAssert.Contains(service.OrderList, order);
        }

        [TestMethod()]
        public void AddOrderItemTest()
        {
            service.AddOrderItem(service.OrderList[0], keyboard);
            Assert.AreEqual(2, service.OrderList[0].OrderItemList.Count);
            CollectionAssert.Contains(service.OrderList[0].OrderItemList, keyboard);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void AddOrderItemTest1()
        {
            service.AddOrderItem(service.OrderList[0], laptop);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            service.RemoveOrder(service.OrderList[0].OrderID);
            Assert.AreEqual(2, service.OrderList.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void RemoveOrderTest1()
        {
            service.RemoveOrder(service.OrderList[0].OrderID - 1);
        }

        [TestMethod()]
        public void RemoveOrderItemTest()
        {
            service.RemoveOrderItem(service.OrderList[1], keyboard);
            Assert.AreEqual(1, service.OrderList[1].OrderItemList.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void RemoveOrderItemTest1()
        {
            service.RemoveOrderItem(service.OrderList[0], keyboard);
        }

        [TestMethod()]
        public void ModifyOrderTest()
        {
            service.ModifyOrder(service.OrderList[0].OrderID, 1, "Test");
            Assert.AreEqual("Test", service.OrderList[0].CustomerName);
            service.ModifyOrder(service.OrderList[0].OrderID, 2, "Test");
            Assert.AreEqual("Test", service.OrderList[0].Address);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void ModifyOrderTest1()
        {
            service.ModifyOrder(service.OrderList[0].OrderID - 1, 1, "Test");
        }

        [TestMethod()]
        public void ModifyOrderTest2()
        {
            service.ModifyOrder(service.OrderList[0], 1, "Test");
            Assert.AreEqual("Test", service.OrderList[0].CustomerName);
            service.ModifyOrder(service.OrderList[0], 2, "Test");
            Assert.AreEqual("Test", service.OrderList[0].Address);
        }

        [TestMethod()]
        public void QueryByOrderIDTest()
        {
            Order order = service.QueryByOrderID(service.OrderList[0].OrderID);
            Assert.IsNotNull(order);
            Assert.AreEqual(service.OrderList[0], order);
            order = service.QueryByOrderID(service.OrderList[0].OrderID - 1);
            Assert.IsNull(order);
        }

        [TestMethod()]
        public void QueryByProductNameTest()
        {
            Assert.AreEqual(3, service.QueryByProductName("Laptop").Count);
            Assert.AreEqual(2, service.QueryByProductName("Keyboard").Count);
            Assert.AreEqual(1, service.QueryByProductName("Mouse").Count);
            Assert.AreEqual(0, service.QueryByProductName("Display").Count);
        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Assert.AreEqual(1, service.QueryByCustomerName("Wong").Count);
            Assert.AreEqual(1, service.QueryByCustomerName("Zhang").Count);
            Assert.AreEqual(1, service.QueryByCustomerName("Fang").Count);
            Assert.AreEqual(0, service.QueryByCustomerName("Li").Count);
        }

        [TestMethod()]
        public void SortOrderListTest()
        {
            service.OrderList.Clear();
            Order order1 = new Order
            {
                CustomerName = "Wong",
                Address = "Wuhan",
            };
            Order order2 = new Order
            {
                CustomerName = "Zhang",
                Address = "Wuhan",
            };
            Order order3 = new Order
            {
                CustomerName = "Fang",
                Address = "Wuhan",
            };
            service.AddOrderItem(order1, laptop);
            service.AddOrderItem(order2, laptop);
            service.AddOrderItem(order2, keyboard);
            service.AddOrderItem(order3, laptop);
            service.AddOrderItem(order3, keyboard);
            service.AddOrderItem(order3, mouse);
            service.AddOrder(order2);
            service.AddOrder(order1);
            service.AddOrder(order3);

            List<Order> testList = new List<Order>();
            testList.Add(order1);
            testList.Add(order2);
            testList.Add(order3);

            service.SortOrderList((x, y) => (int)(x.TotalPrice - y.TotalPrice));

            CollectionAssert.AreEqual(testList, service.OrderList);
        }

        [TestMethod()]
        public void ExportTest()
        {
            String path = "temp.xml";
            service.Export(path);
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod()]
        public void ImportTest()
        {
            service.OrderList.Clear();
            service.Import("../../expectedOrders.xml");
            Assert.AreEqual(3, service.OrderList.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ImportTest1()
        {
            service.OrderList.Clear();
            service.Import("ordersNotExist.xml");
        }
    }
}