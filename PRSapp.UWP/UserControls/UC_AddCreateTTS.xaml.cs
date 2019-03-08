using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Media.SpeechSynthesis;
using Windows.Media.Streaming;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Views.UsrControls
{
    public sealed partial class UC_AddCreateTTS : UserControl
    {
        public UC_AddCreateTTS()
        {
            this.InitializeComponent();
        }

        private async void ImgMicrophone_TappedAsync(object sender, TappedRoutedEventArgs e)
        {
            //note** - try using button click first
            //MediaElement mediaElement = new MediaElement();

            //var synthesizer = new SpeechSynthesizer();
            //var stream = await synthesizer.SynthesizeTextToStreamAsync(boxInputTextToSpeak.Text);

            //mediaElement.SetSource(stream, stream.ContentType);
            //mediaElement.Play();
        }

        private async void btnSynthesize_ClickAsync(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            #region sSSML in string var - WIP
 //           string sSSML = < speak version = "\"1.0\"
 //xmlns = "http://www.w3.org/2001/10/synthesis"
 //xml: lang = "en-ES" >
 

 //  < prosody rate = "medium" >
  
 //     < p >
  
 //       < s > Category - IT Stuff </ s >
     
 //          < voice gender = "female" >
      
 //             < s > Title - How to get  s q lite working with u w p Ten </ s >
         
 //              </ voice >
         
 //            </ p >
         
 //            < p >
         
 //              < voice gender = "male" >
          
 //                < s > Problem S q l lite was not working in V s 2017.</ s >
             
 //                  < s > The Data Class was missing from the using.</ s >
                
 //                     < s >using Microsoft ,dot Data . s q l lite.</ s >
                  
 //                     < s > Also,  Microsoft.Data.Sqlite.Internal;</ s >
                    
 //                         </ voice >
                    
 //                         < s ></ s >
                    
 //                         < voice gender = "female" >
                     
 //                          < s > Solution.</ s >
                     
 //                        < s > Manage New - jet package.</ s >
                          
 //                               < s > Include pre - releases.</ s >
                             
 //                              < s > selct browse, for some reason it does not come up in search if you select, installed.</ s >
                                
 //                                < s > Search for Microsoft Dot Data Dot Sqlite </ s >
                                   
 //                                        < s > And install version 1, point, 1 point, 1.</ s >
                                   
 //                                        < s > Then Data became available in the using statement.</ s >                                   
 //                                           </ voice >                                   
 //                                         </ p >                                     
 //                                       </ prosody >
 //                                     </ speak >";
                    #endregion
        //    MediaElement mediaElement = new MediaElement();

        //    var synthesizer = new SpeechSynthesizer();
        //    var stream = await synthesizer.SynthesizeTextToStreamAsync(boxInputTextToSpeak.Text);
        ///*var stream = await synthesizer.SynthesizeSsmlToStreamAsync(sSSML)*/;

       
        //    mediaElement.SetSource(stream, stream.ContentType);
        //    mediaElement.Play();
        }
    }
}