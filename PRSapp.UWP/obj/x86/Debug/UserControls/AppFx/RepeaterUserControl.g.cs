﻿#pragma checksum "C:\Users\Flazz\source\repos\FebOn\00MarchRepo\PRSapp\PRSapp.UWP\UserControls\AppFx\RepeaterUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9314D2F9C34EE3885010EF9D3D6AF266"
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
    partial class RepeaterUserControl : 
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
            case 2: // UserControls\AppFx\RepeaterUserControl.xaml line 82
                {
                    this.stpStatus = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // UserControls\AppFx\RepeaterUserControl.xaml line 91
                {
                    this.stpSpeechSettings = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // UserControls\AppFx\RepeaterUserControl.xaml line 114
                {
                    this.SdrSpeakAsyncProgress = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 5: // UserControls\AppFx\RepeaterUserControl.xaml line 119
                {
                    this.BtnStopAsync = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnStopAsync).Click += this.BtnStopPauseRepeatMediaOutAsync_Click;
                }
                break;
            case 6: // UserControls\AppFx\RepeaterUserControl.xaml line 122
                {
                    this.stpMediaOut = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7: // UserControls\AppFx\RepeaterUserControl.xaml line 129
                {
                    this.BtnSpeechRecogWeatherSearch = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnSpeechRecogWeatherSearch).Click += this.BtnSpeechRecogWeatherSearchAsync_Click;
                }
                break;
            case 8: // UserControls\AppFx\RepeaterUserControl.xaml line 142
                {
                    this.imgSpeakerOut = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9: // UserControls\AppFx\RepeaterUserControl.xaml line 98
                {
                    this.cboVoiceGender = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cboVoiceGender).SelectionChanged += this.cboVoiceGender_SelectionChanged;
                }
                break;
            case 10: // UserControls\AppFx\RepeaterUserControl.xaml line 86
                {
                    this.tbStatus = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // UserControls\AppFx\RepeaterUserControl.xaml line 69
                {
                    this.BtnRepeatMediaOutAsync = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnRepeatMediaOutAsync).Click += this.BtnRepeatMediaOutAsync_Click;
                }
                break;
            case 12: // UserControls\AppFx\RepeaterUserControl.xaml line 72
                {
                    this.BtnStopPauseRepeatMediaOutAsync = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnStopPauseRepeatMediaOutAsync).Click += this.BtnStopPauseRepeatMediaOutAsync_Click;
                }
                break;
            case 13: // UserControls\AppFx\RepeaterUserControl.xaml line 75
                {
                    this.TgsRepeats = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                }
                break;
            case 14: // UserControls\AppFx\RepeaterUserControl.xaml line 76
                {
                    this.boxRepetitions = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // UserControls\AppFx\RepeaterUserControl.xaml line 77
                {
                    this.boxInterval = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // UserControls\AppFx\RepeaterUserControl.xaml line 78
                {
                    this.uiMediaElement = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                }
                break;
            case 17: // UserControls\AppFx\RepeaterUserControl.xaml line 42
                {
                    this.btnRecognitionTtsRawBigAsync = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 18: // UserControls\AppFx\RepeaterUserControl.xaml line 50
                {
                    this.tbRecogStatus = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // UserControls\AppFx\RepeaterUserControl.xaml line 54
                {
                    this.boxTtsRawBig = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20: // UserControls\AppFx\RepeaterUserControl.xaml line 46
                {
                    this.imgMicrophoneTapped = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 21: // UserControls\AppFx\RepeaterUserControl.xaml line 26
                {
                    this.tgsCommandModeOn = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                }
                break;
            case 22: // UserControls\AppFx\RepeaterUserControl.xaml line 33
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

