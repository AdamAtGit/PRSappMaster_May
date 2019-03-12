using PRSapp.UWP.UserControls.AppFx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PRSapp.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageParmPass1 : Page
    {
        RepeaterUserControl RepeaterUserControl = new RepeaterUserControl();

        public PageParmPass1()
        {
            this.InitializeComponent();

            // Register UCs Click event handler in the parent page
            var repeaterUserControl = new RepeaterUserControl();
            repeaterUserControl.BtnRepeatMediaOutAsyncClick += repeaterUserControl.BtnRepeatMediaOutAsync_Click;
            BtnPage1RepeatMediaOutAsync.Click += repeaterUserControl.BtnRepeatMediaOutAsync_Click;
        }


        private void NavBacktoMain_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }    

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var repeaterUserControl = new RepeaterUserControl();
            //RepeaterUserControl RepeaterUserControl = new RepeaterUserControl();
        }


    }
}
