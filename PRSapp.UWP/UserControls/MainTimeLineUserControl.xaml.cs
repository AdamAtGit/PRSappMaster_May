using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PRSapp.UWP.UserControls.Nested;
using Windows.Devices.Enumeration;

namespace PRSapp.UWP.UserControls
{
    public sealed partial class MainTimeLineUserControl : UserControl
    {
        public MainTimeLineUserControl()
        {
            this.InitializeComponent();

            ////Wire
            //BtnChooseCreateExist1.Click +=
            //    new RoutedEventHandler(BtnChooseCreateExist_Click);
        }

        private void BtnChooseCreateExist_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate nested user control
            ////UserControl menuUc = new UserControl();

            //menuUc.SetValue(Grid.SetColumn(this, 2));
            //EditWrapperPanel.Visibility = Visibility.Visible;
            //EditWrapperPanel.SetValue(Grid.RowSpanProperty, 2);
            //ShowTitlesPanel.Height = 630;
            //ShowTitlesPanel.SetValue(Grid.RowSpanProperty, 2);
            //ShowTitlesListView.Height = 500;

            //Grid.Column="2" Grid.Row="1" 
            //Grid.ColumnSpan = "2" Grid.RowSpan = "2"

        }
    }
}
