using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PRSapp.UWP.SpeechClasses
{
    //This below static class is an extension method for MediaElement
   public static class RepeatersMediaElementExtensions
    {
        public static readonly MediaElement UIMediaElement;

        public static async Task Play_Stream_Async(
          //? this MediaElement mediaElement,
          this MediaElement UIMediaElement,
          IRandomAccessStream stream,
          bool disposeStream = true)
        {
            // bool is irrelevant here, just using this to flag task completion.
            TaskCompletionSource<bool> taskCompleted = new TaskCompletionSource<bool>();

            // Note that the MediaElement needs to be in the UI tree for events
            // like MediaEnded to fire.
            RoutedEventHandler endOfPlayHandler = (s, e) =>
            {
                if (disposeStream)
                {
                    stream.Dispose();
                }
                taskCompleted.SetResult(true);
            };
            UIMediaElement.MediaEnded += endOfPlayHandler;

            UIMediaElement.SetSource(stream, string.Empty);
            UIMediaElement.Play();

            bool isValid = await taskCompleted.Task;
            UIMediaElement.MediaEnded -= endOfPlayHandler;
        }
    }
}
 