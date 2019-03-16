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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PRSapp.UWP.UserControls.Nested
{
    public sealed partial class DateButtonUC : UserControl
    {
        //\\ Code Set -  Pass data from User Control to Parent page in Windows Phone 8.1
        // Create a delegate on the user control, that can encapsulate a method
        // that takes no input and returns a DateTime type.
        public delegate void ChildControlDelegate(DateTime dtCurrentDateTime);
        //Declare an event on the user control, that is of the delegate type that we created.
        public event ChildControlDelegate GetDataFromChild;

        public DateButtonUC()
        {
            this.InitializeComponent();
        }

        //\\ Code Set -  Pass data from User Control to Parent page in Windows Phone 8.1
        //Next, when the button click functionality is done, we explicitly execute the event,
        //by calling the GetDataFromChild event, passing the required data.
        private void DateTime_Click(object sender, RoutedEventArgs e)
        {
            //Simplified Delegate Invocation
            GetDataFromChild?.Invoke(DateTime.Now);
            //Below before - Simplified Delegate Invocation
            //if (GetDataFromChild != null)
            //{
            //    GetDataFromChild(DateTime.Now);
            //}
        }
    }
}