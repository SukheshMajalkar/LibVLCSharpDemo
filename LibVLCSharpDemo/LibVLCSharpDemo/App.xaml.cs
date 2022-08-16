using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LibVLCSharpDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Core.Initialize(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LibVlc", "win-x86"));
        }
       
    }
}
