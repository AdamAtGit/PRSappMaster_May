using PRSapp.UWP.UserControls.AppFx;
using PRSapp.UWP.UserControls.Nested;
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
        PrompterUC PrompterUC = new PrompterUC();

      

        public PageParmPass1()
        {
            this.InitializeComponent();
           

            // Register UCs Click event handler in the parent page
            var prompterUC = new PrompterUC();
            prompterUC.BtnRepeatMediaOutAsyncClick += prompterUC.BtnRepeatMediaOutAsync_Click;
            BtnPage1RepeatMediaOutAsync.Click += prompterUC.BtnRepeatMediaOutAsync_Click;

            var hintUC = new HintUC();         

            var responseUC = new ResponseUC();
            responseUC.BtnRepeatMediaOutAsync2Click += responseUC.BtnRepeatMediaOutAsync_Click;
            BtnPage1RepeatMediaOutAsync2.Click += responseUC.BtnRepeatMediaOutAsync_Click;

            //Make so parent Run button invokes  
             BtnPlayController.Click += RunPlayListsSets_Click;
           // PrompterUC.BtnRepeatMediaOutAsyncClick += prompterUC.BtnRepeatMediaOutAsync_Click;
           // BtnPage1RepeatMediaOutAsync.Click += prompterUC.BtnRepeatMediaOutAsync_Click;

        }

     
        public void RunPlayListsSets_Click(object sender, RoutedEventArgs e)
        {
            var prompterUC = new PrompterUC();
            var hinterUC = new HintUC();
            var responseUC = new ResponseUC();

            prompterUC.BtnRepeatMediaOutAsync_Click(sender, new RoutedEventArgs());
            //todo hinterUC.' '(sender, new RoutedEventArgs());
            responseUC.BtnRepeatMediaOutAsync_Click(this, new RoutedEventArgs());
        }

        private void NavBacktoMain_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var prompterUC = new PrompterUC();         
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // base.OnNavigatedTo(e); 
            boxSignedInUser.Text = "Hi, " +  e.Parameter.ToString();


            //\\ Code Set - Pass data from User Control to Parent page in Windows Phone 8.1
            //Our main page will subscribe to the event that we created on the user control, 
            //to get notification of when the event is fired on the user control.
            uChild.GetDataFromChild += new DateButtonUC.ChildControlDelegate(UChild_GetDataFromChild);
            uChildHint.GetDataFromHintUcChild += new HintUC.ChildHintUCDelegate(HintUC_GetDataFromHintUcChild);
        }

        private void HintUC_GetDataFromHintUcChild(Boolean IsHintVisible)
        {
            Boolean isHintVisible = IsHintVisible;
            boxIsHintVisible.Text = isHintVisible.ToString();
            //boxPage1DateTime.Text = dt.ToShortTimeString();
        }

        //\\ Code Set - Pass data from User Control to Parent page
        private void UChild_GetDataFromChild(DateTime dtCurrentDateTime)
        {
            DateTime dt = dtCurrentDateTime;
            boxPage1DateTime.Text = dt.ToShortTimeString();
        }

    }
}
