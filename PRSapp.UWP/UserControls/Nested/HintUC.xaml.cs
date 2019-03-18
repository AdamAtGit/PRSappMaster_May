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
    public sealed partial class HintUC : UserControl
    {
        public delegate void ChildHintUCDelegate(Boolean IsHintVisible);
        public event ChildHintUCDelegate GetDataFromHintUcChild;

        public HintUC()
        {
            this.InitializeComponent();
            BtnUcShowHideHint.Click += new RoutedEventHandler(BtnUcShowHideHint_Click);
        }

        public void BtnUcShowHideHint_Click(object sender, RoutedEventArgs e)
        {
            bool isHintVisible;
            if(stpHint.Visibility == Visibility.Visible)
            {
                stpHint.Visibility = Visibility.Collapsed;
                BtnUcShowHideHint.Content = "Show Hint";
                isHintVisible = false;
                GetDataFromHintUcChild?.Invoke(isHintVisible);
            }
            else
            {
                stpHint.Visibility = Visibility.Visible;
                BtnUcShowHideHint.Content = "Hide Hint";
                isHintVisible = true;
                GetDataFromHintUcChild?.Invoke(isHintVisible);
            }
        }


    }
}
