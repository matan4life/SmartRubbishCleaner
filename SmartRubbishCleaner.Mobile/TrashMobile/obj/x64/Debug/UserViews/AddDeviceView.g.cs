﻿#pragma checksum "D:\NURE\3 курс 1 семестр\АРКПЗ\Yurii\TrashMobile\TrashMobile\TrashMobile\UserViews\AddDeviceView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DED516BB25B607D39802A406BBD64BE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrashMobile.UserViews
{
    partial class AddDeviceView : 
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
            case 2: // UserViews\AddDeviceView.xaml line 57
                {
                    this.ButtonClose = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButtonClose).Click += this.Close;
                }
                break;
            case 3: // UserViews\AddDeviceView.xaml line 16
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // UserViews\AddDeviceView.xaml line 23
                {
                    this.Radius = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // UserViews\AddDeviceView.xaml line 31
                {
                    this.Wieght = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // UserViews\AddDeviceView.xaml line 39
                {
                    this.Volume = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // UserViews\AddDeviceView.xaml line 47
                {
                    this.SaveButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveButton).Click += this.Close;
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

