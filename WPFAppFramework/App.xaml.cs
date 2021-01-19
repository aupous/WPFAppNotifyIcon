using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Forms = System.Windows.Forms;

namespace WPFAppFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Forms.NotifyIcon _notifyIcon;
        private MainWindow mainWindow;

        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            base.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            _notifyIcon.Icon = new System.Drawing.Icon(@"../../icon.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.Click += NotifyIcon_Click;

            _notifyIcon.ContextMenu = new Forms.ContextMenu();
            _notifyIcon.ContextMenu.MenuItems.Add(new Forms.MenuItem("Thoát", OnExitClicked));
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (this.mainWindow == null || this.mainWindow.IsClosed)
            {
                this.mainWindow = new MainWindow();
                this.mainWindow.Show();
                this.mainWindow.Focus();
            } else
            {
                this.mainWindow.WindowState = WindowState.Normal;
                this.mainWindow.Activate();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnExit(e);
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            base.Shutdown();
        }
}
}
