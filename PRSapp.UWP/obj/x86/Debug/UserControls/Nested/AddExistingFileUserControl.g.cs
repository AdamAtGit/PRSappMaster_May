﻿#pragma checksum "C:\Users\Flazz\source\repos\FebOn\00MarchRepo\PRSapp\PRSapp.UWP\UserControls\Nested\AddExistingFileUserControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D6CCECAEFE08FC5E1C2C9F02F67C8447"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PRSapp.UWP.UserControls.Nested
{
    partial class AddExistingFileUserControl : 
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
            case 2: // UserControls\Nested\AddExistingFileUserControl.xaml line 56
                {
                    this.BtnFromExistingVideoChosen = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnFromExistingVideoChosen).Click += this.BtnFromExistingVideoChosen_Click;
                }
                break;
            case 3: // UserControls\Nested\AddExistingFileUserControl.xaml line 49
                {
                    this.BtnFromExistingAudioChosen = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnFromExistingAudioChosen).Click += this.BtnFromExistingAudioChosen_Click;
                }
                break;
            case 4: // UserControls\Nested\AddExistingFileUserControl.xaml line 42
                {
                    this.BtnFromExistingTTSChosen = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnFromExistingTTSChosen).Click += this.BtnFromExistingTTSChosen_Click;
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

