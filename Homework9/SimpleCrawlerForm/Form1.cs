using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCrawlerForm
{
    public partial class Form1 : Form
    {
        public List<DownloadInfo> DownloadInfos { get; set; }
        SimpleCrawler simpleCrawler = new SimpleCrawler();
        Thread thread = null;   //如果不用线程会卡顿

        public Form1()
        {
            InitializeComponent();
            DownloadInfos = new List<DownloadInfo>();
            infoBindingSource.DataSource = DownloadInfos;
            simpleCrawler.CrawlerStopped += SimpleCrawler_CrawlerStopped;
            simpleCrawler.DownloadCompleted += SimpleCrawler_DownloadCompleted;
        }

        private void SimpleCrawler_DownloadCompleted(string url, string info)
        {
            DownloadInfos.Add(new DownloadInfo { Id = DownloadInfos.Count + 1, Url = url, Status = info });
            Action action = () => infoBindingSource.ResetBindings(false);
            if(this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void SimpleCrawler_CrawlerStopped()
        {
            Action action = () => MessageBox.Show("爬行结束！");
            if(this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DownloadInfos.Clear();
            simpleCrawler.StartURL = txtUrl.Text;

            Match match = Regex.Match(simpleCrawler.StartURL, SimpleCrawler.urlParseRegex);
            if(match.Length == 0) return;
            string host = match.Groups["host"].Value;
            simpleCrawler.HostFilter = "^" + host + "$";
            simpleCrawler.FileFilter = ".html?$";

            if(thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(simpleCrawler.Crawl);
            thread.Start();
        }
    }
}
