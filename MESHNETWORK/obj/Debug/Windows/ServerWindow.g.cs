﻿#pragma checksum "..\..\..\Windows\ServerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3A3FB761AEFDB033AEF68D061BA8B1918298B1AB970958059B4323B9E22E3510"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MESHNETWORK.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MESHNETWORK.Windows {
    
    
    /// <summary>
    /// ServerWindow
    /// </summary>
    public partial class ServerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\Windows\ServerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListNets;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Windows\ServerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox UsersList;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Windows\ServerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameNet;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Windows\ServerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Count;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Windows\ServerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Author;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Windows\ServerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowShares;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MESHNETWORK;component/windows/serverwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ServerWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\Windows\ServerWindow.xaml"
            ((MESHNETWORK.Windows.ServerWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ListNets = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            
            #line 54 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNet_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 55 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveNet_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 56 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DowlandNet_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UsersList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            
            #line 66 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShareReader_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 67 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShareWriter_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 68 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Revoke_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 73 "..\..\..\Windows\ServerWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowAll_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.NameNet = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Count = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.Author = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.ShowShares = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Windows\ServerWindow.xaml"
            this.ShowShares.Click += new System.Windows.RoutedEventHandler(this.ShowShares_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

