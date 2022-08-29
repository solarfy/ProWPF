using System;
using System.Windows;
using System.Collections.Generic;
using StoreDataBase;

namespace ProWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Static
        
        private static StoreDB storeDB = new StoreDB();        
        public static StoreDB StoreDB 
        { 
            get => storeDB; 
        }

        #endregion

        private string startupPath = "MainWindow.xaml"; 

        //窗口间交互
        public List<Advanced.DocumentViewer> Documents { get; set; } = new List<Advanced.DocumentViewer>() { };
        
        protected override void OnStartup(StartupEventArgs e)
        {
            //string description = Chapters.GetChapterDescription(nameof(Chapters.RoutingStrategy));
            startupPath = Chapters.Startup;
            this.StartupUri = new Uri(startupPath, UriKind.Relative);
            base.OnStartup(e);            
        }      
    }
}
