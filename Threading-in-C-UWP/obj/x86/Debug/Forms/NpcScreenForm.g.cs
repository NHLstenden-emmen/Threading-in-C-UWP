﻿#pragma checksum "D:\Programming\Github\Threading-in-C-UWP\Threading-in-C-UWP\Forms\NpcScreenForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A75F7FA629FE676DD092D82A8A6F0E1BED6F2C75C3F5F9D53706279E43D7AA47"
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
    partial class NpcScreenForm : 
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
            case 2: // Forms\NpcScreenForm.xaml line 12
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.DeleteNPC_Click;
                }
                break;
            case 3: // Forms\NpcScreenForm.xaml line 13
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.GenerateNPCButton_Click;
                }
                break;
            case 4: // Forms\NpcScreenForm.xaml line 14
                {
                    this.AmountOfNPCs = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // Forms\NpcScreenForm.xaml line 15
                {
                    this.SavedNpcsListBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.SavedNpcsListBox).DoubleTapped += this.SavedNPCsListBox_DoubleTapped;
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

