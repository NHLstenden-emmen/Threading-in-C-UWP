﻿#pragma checksum "D:\Programming\Github\Threading-in-C-UWP\Threading-in-C-UWP\Forms\MonstersScreenForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E88243B4A989C7E5B396979A5CD011B95A0D1F923AFE07437E02E3F2F8601F4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Threading_in_C_UWP.Forms
{
    partial class MonstersScreenForm : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Forms\MonstersScreenForm.xaml line 12
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.DeleteMonster_Click;
                }
                break;
            case 3: // Forms\MonstersScreenForm.xaml line 13
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.GenerateMonsterButton_Click;
                }
                break;
            case 4: // Forms\MonstersScreenForm.xaml line 14
                {
                    this.AmountOfMonsters = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Forms\MonstersScreenForm.xaml line 15
                {
                    this.SavedMonstersListBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.SavedMonstersListBox).DoubleTapped += this.SavedMonstersListBox_DoubleTapped;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

