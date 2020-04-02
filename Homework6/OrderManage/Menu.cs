using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage
{
    //用户交互类
    //其他类不涉及用户的交互操作

    class Menu
    {
        public OrderService OS;

        public Menu()
        {
            OS = new OrderService();
            Console.WriteLine("----------------------");
            Console.WriteLine("Order Manage System");
            Console.WriteLine("Author: Wong");
            Console.WriteLine("----------------------");
            ShowMenu();
        }

        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("1.Add order");
            Console.WriteLine("2.Remove order");
            Console.WriteLine("3.Modify order");
            Console.WriteLine("4.Query order");
            Console.WriteLine("5.Show all the orders");
            Console.WriteLine("6.Show Menu");
            Console.WriteLine("7.Exit");
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter your choice[1-7]:");

            int selectNum;

            while(true)
            {
                if(!Int32.TryParse(Console.ReadLine(), out selectNum))
                {
                    Console.WriteLine("Enter your choice[1-7]:");
                    continue;
                }

                switch(selectNum)
                {
                    case 1:
                        long orderID;
                        if(AddOrderByUser(out orderID))
                        {
                            Console.WriteLine($"Add the order #{orderID} successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the order");
                        }

                        break;
                    case 2:
                        if(RemoveOrderByUser())
                        {
                            Console.WriteLine("Remove the order successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to remove the order");
                        }

                        break;
                    case 3:
                        if(ModifyOrderByUser())
                        {
                            Console.WriteLine("Modify the order successfully");
                        }
                        else
                        {
                            Console.WriteLine("No changes have been made");
                        }

                        break;
                    case 4:
                        if(QueryOrderByUser())
                        {
                            Console.WriteLine("Query successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to query the orders");
                        }

                        break;
                    case 5:
                        OS.OrderList.ForEach(x => Console.WriteLine(x));
                        break;
                    case 6:
                        ShowMenu();
                        return;
                    case 7:
                        OS.Export("orders.xml");
                        return;
                }
                Console.WriteLine();
                Console.WriteLine("Enter your choice[1-7]:");
            }
        }

        //用户添加订单
        //返回订单号
        public bool AddOrderByUser(out long orderID)
        {
            orderID = 0;
            Order order = new Order();
            //保存输入的内容
            string enteredContent;
            Console.WriteLine("Please enter the information according to the following requirements(Press 'q' to exit):");

            Console.Write("Customer Name: ");
            while((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }
            order.CustomerName = enteredContent;

            Console.Write("Address: ");
            while((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }
            order.Address = enteredContent;

            //记录添加的订单明细数目
            int changeNum;
            AddOrderItemByUser(order, out changeNum);
            Console.WriteLine($"{changeNum} {(changeNum > 1 ? "order items have" : "order item has")} been added");

            OS.AddOrder(order);
            orderID = order.OrderID;
            return true;
        }

        public bool RemoveOrderByUser()
        {
            long orderID;
            string enteredContent;
            Console.WriteLine("Please enter the order ID of the order you want to remove(Press 'q' to exit):");

            Console.Write("Order ID: ");
            while((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }

            if(!Int64.TryParse(enteredContent, out orderID))
            {
                Console.WriteLine("Error: Invalid format");
                return false;
            }

            try
            {
                OS.RemoveOrder(orderID);
                return true;
            }
            catch(ApplicationException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //用户修改订单信息
        public bool ModifyOrderByUser()
        {
            Order order;
            long orderID;
            string enteredContent;
            Console.WriteLine("Please enter the order ID of the order you want to modify(Press 'q' to exit):");

            Console.Write("Order ID: ");
            while((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }

            if(!Int64.TryParse(enteredContent, out orderID))
            {
                Console.WriteLine("Error: Invalid format");
                return false;
            }

            if((order = OS.QueryByOrderID(orderID)) == null)
            {
                Console.WriteLine("Error: No such order");
                return false;
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("1.Modify Customer Name");
            Console.WriteLine("2.Modify Address");
            Console.WriteLine("3.Add order item");
            Console.WriteLine("4.Remove order item");
            Console.WriteLine("5.Exit");
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter your choice[1-5]:");

            int selectNum;
            int changeNum;      //标记添加和删除的订单明细数目

            while(!Int32.TryParse(Console.ReadLine(), out selectNum) || selectNum < 1 || selectNum > 5)
            {
                Console.WriteLine("Enter your choice[1-5]:");
            }

            switch(selectNum)
            {
                case 1:
                case 2:
                    string modifiedContent;
                    if(InputModifiedContentByUser(out modifiedContent))
                    {
                        OS.ModifyOrder(order, selectNum, modifiedContent);
                        return true;
                    }

                    break;
                case 3:
                    AddOrderItemByUser(order, out changeNum);
                    Console.WriteLine($"{changeNum} {(changeNum > 1 ? "order items have" : "order item has")} been added");

                    //修改了一条及以上订单明细
                    if(changeNum > 0)
                    {
                        return true;
                    }

                    break;
                case 4:
                    RemoveOrderItemByUser(order, out changeNum);
                    Console.WriteLine($"{changeNum} {(changeNum > 1 ? "order items have" : "order item has")} been removed");

                    if(changeNum > 0)
                    {
                        return true;
                    }

                    break;
                case 5:
                    break;
            }

            return false;
        }

        //用户查询订单信息
        public bool QueryOrderByUser()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("1.Query by Order ID");
            Console.WriteLine("2.Query by Product Name");
            Console.WriteLine("3.Query by Customer Name");
            Console.WriteLine("4.Exit");
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter your choice[1-4]:");

            int selectNum;

            while(!Int32.TryParse(Console.ReadLine(), out selectNum) || selectNum < 1 || selectNum > 4)
            {
                Console.WriteLine("Enter your choice[1-4]:");
            }

            //保存返回的查询结果
            Order res;
            List<Order> listRes;

            switch(selectNum)
            {
                case 1:
                    long orderID;
                    if(!InputQueryContentByUser(out orderID))
                    {
                        return false;
                    }
                    res = OS.QueryByOrderID(orderID);

                    Console.WriteLine("Query result:");

                    if(res == null)
                    {
                        Console.WriteLine("No order matches");
                    }
                    else
                    {
                        Console.WriteLine(res);
                    }

                    break;
                case 2:
                    string queryContent;
                    if(!InputQueryContentByUser(out queryContent))
                    {
                        return false;
                    }
                    listRes = OS.QueryByProductName(queryContent);

                    Console.WriteLine("Query result:");

                    if(!listRes.Any())
                    {
                        Console.WriteLine("No order matches");
                    }
                    else
                    {
                        listRes.ForEach(x => Console.WriteLine(x));
                    }

                    break;
                case 3:
                    if(!InputQueryContentByUser(out queryContent))
                    {
                        return false;
                    }
                    listRes = OS.QueryByCustomerName(queryContent);

                    Console.WriteLine("Query result:");

                    if(!listRes.Any())
                    {
                        Console.WriteLine("No order matches");
                    }
                    else
                    {
                        listRes.ForEach(x => Console.WriteLine(x));
                    }

                    break;
                case 4:
                    return false;
            }
            return true;
        }

        //用户添加订单明细
        //changeNum: 记录添加的订单明细数目
        public void AddOrderItemByUser(Order order, out int changeNum)
        {
            changeNum = 0;
            string[] itemContent;
            string enteredContent;
            double tmpPrice;
            int tmpAmount;
            Console.WriteLine("Add order items [ Format: Product Name | Product Price | Product Amount ]: ");
            //循环添加订单明细
            while((enteredContent = Console.ReadLine().Trim()) != "q" && enteredContent != "Q")
            {
                if(enteredContent == "")
                {
                    Console.WriteLine("Input is empty, please enter again");
                    continue;
                }

                itemContent = enteredContent.Split('|');
                //确保订单明细由三项组成
                if(itemContent.Length != 3)
                {
                    Console.WriteLine("Invalid format, please enter again");
                    continue;
                }

                Array.ForEach(itemContent, x => x.Trim());

                if(itemContent[0] == "")
                {
                    Console.WriteLine("Invalid data, please enter again");
                    continue;
                }

                //单价要大于等于零
                if(itemContent[1] == "" || !Double.TryParse(itemContent[1], out tmpPrice) || tmpPrice < 0)
                {
                    Console.WriteLine("Invalid data, please enter again");
                    continue;
                }

                //数量要大于零
                if(itemContent[2] == "" || !Int32.TryParse(itemContent[2], out tmpAmount) || tmpAmount <= 0)
                {
                    Console.WriteLine("Invalid data, please enter again");
                    continue;
                }

                OrderItem orderItem = new OrderItem
                {
                    ProductName = itemContent[0],
                    ProductPrice = tmpPrice,
                    ProductAmount = tmpAmount
                };

                try
                {
                    OS.AddOrderItem(order, orderItem);
                    changeNum++;
                }
                catch(ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //用户删除订单明细
        //changeNum: 记录删除的订单明细数目
        public void RemoveOrderItemByUser(Order order, out int changeNum)
        {
            changeNum = 0;
            string[] itemContent;
            string enteredContent;
            double tmpPrice;
            int tmpAmount;
            Console.WriteLine("Remove order items [ Format: Product Name | Product Price | Product Amount ]: ");
            //循环添加订单明细
            while((enteredContent = Console.ReadLine().Trim()) != "q" && enteredContent != "Q")
            {
                if(enteredContent == "")
                {
                    Console.WriteLine("Input is empty, please enter again");
                    continue;
                }

                itemContent = enteredContent.Split('|');
                //确保订单明细由三项组成
                if(itemContent.Length != 3)
                {
                    Console.WriteLine("Invalid format, please enter again");
                    continue;
                }

                Array.ForEach(itemContent, x => x.Trim());

                if(itemContent[0] == "")
                {
                    Console.WriteLine("Invalid data, please enter again");
                    continue;
                }

                //单价要大于等于零
                if(itemContent[1] == "" || !Double.TryParse(itemContent[1], out tmpPrice) || tmpPrice < 0)
                {
                    Console.WriteLine("Invalid data, please enter again");
                    continue;
                }

                //数量要大于零
                if(itemContent[2] == "" || !Int32.TryParse(itemContent[2], out tmpAmount) || tmpAmount <= 0)
                {
                    Console.WriteLine("Invalid data, please enter again");
                    continue;
                }

                OrderItem orderItem = new OrderItem
                {
                    ProductName = itemContent[0],
                    ProductPrice = tmpPrice,
                    ProductAmount = tmpAmount
                };

                try
                {
                    OS.RemoveOrderItem(order, orderItem);
                    changeNum++;
                }
                catch(ApplicationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //用户输入修改内容
        public bool InputModifiedContentByUser(out string modifiedContent)
        {
            Console.WriteLine("Please enter the content you want to modify(Press 'q' to exit):");

            Console.Write("Modified Content: ");
            while((modifiedContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(modifiedContent == "q" || modifiedContent == "Q")
            {
                return false;
            }

            return true;
        }

        //用户输入查询内容(订单号)
        public bool InputQueryContentByUser(out long orderID)
        {
            orderID = 0;
            string enteredContent;
            Console.WriteLine("Please enter the order ID of the order you want to query(Press 'q' to exit):");

            Console.Write("Order ID: ");
            while((enteredContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(enteredContent == "q" || enteredContent == "Q")
            {
                return false;
            }

            if(!Int64.TryParse(enteredContent, out orderID))
            {
                Console.WriteLine("Error: Invalid format");
                return false;
            }

            return true;
        }

        //用户输入查询内容(商品名称和客户等字段)
        public bool InputQueryContentByUser(out string queryContent)
        {
            Console.WriteLine("Please enter the content you want to query(Press 'q' to exit):");

            Console.Write("Query content: ");
            while((queryContent = Console.ReadLine().Trim()) == "")
            {
                Console.WriteLine("Input is empty, please enter again");
            }
            if(queryContent == "q" || queryContent == "Q")
            {
                return false;
            }

            return true;
        }
    }
}
