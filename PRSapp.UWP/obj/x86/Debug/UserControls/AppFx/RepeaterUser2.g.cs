﻿#pragma checksum "C:\Users\Flazz\source\repos\FebOn\00MarchRepo\PRSapp\PRSapp.UWP\UserControls\AppFx\RepeaterUser2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "90B5CA5E0637D58393BF90A7D2255F40"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRSapp.UWP.UserControls.AppFx
{
    partial class RepeaterUserControl2 : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // UserControls\AppFx\RepeaterUser2.xaml line 76
                {
                    this.stpStatus = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // UserControls\AppFx\RepeaterUser2.xaml line 85
                {
                    this.stpSpeechSettings = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // UserControls\AppFx\RepeaterUser2.xaml line 108
                {
                    this.SdrSpeakAsyncProgress = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 5: // UserControls\AppFx\RepeaterUser2.xaml line 113
                {
                    this.BtnStopAsync = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnStopAsync).Click += this.BtnStopPauseRepeatMediaOutAsync_Click;
                }
                break;
            case 6: // UserControls\AppFx\RepeaterUser2.xaml line 116
                {
                    this.stpMediaOut = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7: // UserControls\AppFx\RepeaterUser2.xaml line 123
                {
                    this.BtnSpeechRecogWeatherSearch = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnSpeechRecogWeatherSearch).Click += this.BtnSpeechRecogWeatherSearchAsync_Click;
                }
                break;
            case 8: // UserControls\AppFx\RepeaterUser2.xaml line 136
                {
                    this.imgSpeakerOut = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9: // UserControls\AppFx\RepeaterUser2.xaml line 92
                {
                    this.cboVoiceGender = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cboVoiceGender).SelectionChanged += this.cboVoiceGender_SelectionChanged;
                }
                break;
            case 10: // UserControls\AppFx\RepeaterUser2.xaml line 80
                {
                    this.tbStatus = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // UserControls\AppFx\RepeaterUser2.xaml line 63
                {
                    this.BtnRepeatMediaOutAsync = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnRepeatMediaOutAsync).Click += this.BtnRepeatMediaOutAsync_Click;
                }
                break;
            case 12: // UserControls\AppFx\RepeaterUser2.xaml line 66
                {
                    this.BtnStopPauseRepeatMediaOutAsync = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnStopPauseRepeatMediaOutAsync).Click += this.BtnStopPauseRepeatMediaOutAsync_Click;
                }
                break;
            case 13: // UserControls\AppFx\RepeaterUser2.xaml line 69
                {
                    this.TgsRepeats = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                }
                break;
            case 14: // UserControls\AppFx\RepeaterUser2.xaml line 70
                {
                    this.boxRepetitions = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // UserControls\AppFx\RepeaterUser2.xaml line 71
                {
                    this.boxInterval = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // UserControls\AppFx\RepeaterUser2.xaml line 72
                {
                    this.uiMediaElement = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 17: // UserControls\AppFx\RepeaterUser2.xaml line 38
                {
                    this.btnRecognitionTtsRawBigAsync = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 18: // UserControls\AppFx\RepeaterUser2.xaml line 46
                {
                    this.tbRecogStatus = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // UserControls\AppFx\RepeaterUser2.xaml line 50
                {
                    this.boxTtsRawBig = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20: // UserControls\AppFx\RepeaterUser2.xaml line 42
                {
                    this.imgMicrophoneTapped = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 21: // UserControls\AppFx\RepeaterUser2.xaml line 21
                {
                    this.tgsCommandModeOn = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                }
                break;
            case 22: // UserControls\AppFx\RepeaterUser2.xaml line 29
                {
                    this.TbTitleName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

