using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOrderManage
{
    public partial class Form1 : Form
    {
        public OrderService OS;
        public long QueryOrderID { get; set; }
        public string QueryProductName { get; set; }
        public string QueryCustomerName { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbQueryType.SelectedIndex = 0;
            OS = new OrderService();
            orderBindingSource.DataSource = OS.OrderList;
            QueryOrderID = 0;
            QueryProductName = "";
            QueryCustomerName = "";
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            if(addOrder.ShowDialog() == DialogResult.OK)
            {
                OS.AddOrder(addOrder.NewOrder);
                orderBindingSource.DataSource = OS.OrderList;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            OS.RemoveOrder(orderBindingSource.Current as Order);
            orderBindingSource.ResetBindings(false);
        }

        private void btnModifyOrder_Click(object sender, EventArgs e)
        {
            ModifyOrder modifyOrder = new ModifyOrder(orderBindingSource.Current as Order);
            if(modifyOrder.ShowDialog() == DialogResult.OK)
            {
                OS.ModifyOrder(orderBindingSource.Current as Order, modifyOrder.NewOrder);
                orderBindingSource.DataSource = OS.OrderList;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void cmbQueryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbQueryType.SelectedIndex)
            {
                case 0:
                    txtKeyword.DataBindings.Clear();
                    txtKeyword.DataBindings.Add("Text", this, "QueryOrderID");
                    break;
                case 1:
                    txtKeyword.DataBindings.Clear();
                    txtKeyword.DataBindings.Add("Text", this, "QueryProductName");
                    break;
                case 2:
                    txtKeyword.DataBindings.Clear();
                    txtKeyword.DataBindings.Add("Text", this, "QueryCustomerName");
                    break;
                default:
                    break;
            }
        }

        private void btnQueryOrder_Click(object sender, EventArgs e)
        {
            List<Order> newList;
            switch(cmbQueryType.SelectedIndex)
            {
                case 0:
                    Order order = OS.QueryByOrderID(QueryOrderID);
                    newList = new List<Order>();
                    newList.Add(order);
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 1:
                    newList = OS.QueryByProductName(QueryProductName);
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                case 2:
                    newList = OS.QueryByCustomerName(QueryCustomerName);
                    orderBindingSource.DataSource = newList;
                    orderBindingSource.ResetBindings(false);
                    break;
                default:
                    break;
            }
        }

        private void btnShowAllOrders_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = OS.OrderList;
            orderBindingSource.ResetBindings(false);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            OS.Export("orders.xml");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "xml文件（*.xml）|*.xml";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.SafeFileName;
                OS.Import(path);
                orderBindingSource.DataSource = OS.OrderList;
                orderBindingSource.ResetBindings(false);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "xml文件（*.xml）|*.xml";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                OS.Export(path);
            }
        }
    }
}
