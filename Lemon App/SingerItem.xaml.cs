﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lemon_App
{
    /// <summary>
    /// SingerItem.xaml 的交互逻辑
    /// </summary>
    public partial class SingerItem : UserControl
    {
        public string img { get; set; }
        public string singer { get; set; }
        public SingerItem(string ig,string sing)
        {
            InitializeComponent();
            img = ig;
            singer = sing;
            name.Text = singer;
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Cache/Singer" + sing + ".jpg"))
            {
                WebClient v = new WebClient();
                v.DownloadFile(new Uri(img), AppDomain.CurrentDomain.BaseDirectory + "Cache/Singer" + sing + ".jpg");
                v.DownloadFileCompleted += delegate { im.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Cache/Singer" + sing + ".jpg", UriKind.Relative))); };
            }
            else im.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Cache/Singer" + sing + ".jpg", UriKind.Relative)));
        }
    }
}
