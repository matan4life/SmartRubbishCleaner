﻿#pragma checksum "D:\NURE\3 курс 1 семестр\АРКПЗ\Yurii\TrashMobile\TrashMobile\TrashMobile\Views\AuthorizationView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "64090037B428060543F6BEFDD1A352A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrashMobile.Views
{
    partial class AuthorizationView : 
        global::Windows.UI.Xaml.Controls.Page, 
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
            case 2: // Views\AuthorizationView.xaml line 11
                {
                    this.MainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\AuthorizationView.xaml line 13
                {
                    this.RegisterGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // Views\AuthorizationView.xaml line 51
                {
                    this.SignUpButton = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                    ((global::Windows.UI.Xaml.Controls.HyperlinkButton)this.SignUpButton).Click += this.NavigateToRegistration;
                }
                break;
            case 5: // Views\AuthorizationView.xaml line 23
                {
                    this.LoginTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Views\AuthorizationView.xaml line 30
                {
                    this.PasswordTextBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7: // Views\AuthorizationView.xaml line 38
                {
                    this.RememberPasswordCheckBox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 8: // Views\AuthorizationView.xaml line 44
                {
                    this.SignInButton = (global::Windows.UI.Xaml.Controls.Button)(target);
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
