﻿#pragma checksum "..\..\Main.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "08E4046C7BCCAD2DEE2C7D1F3CB0D99E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApplication1;


namespace WpfApplication1 {
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchbtn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uptbtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button apmbtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button billbtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button regbtn;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frame1;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutbtn;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button chBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Main.xaml"
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
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.searchbtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Main.xaml"
            this.searchbtn.Click += new System.Windows.RoutedEventHandler(this.SearchBtnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.uptbtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\Main.xaml"
            this.uptbtn.Click += new System.Windows.RoutedEventHandler(this.updatebtnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.apmbtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\Main.xaml"
            this.apmbtn.Click += new System.Windows.RoutedEventHandler(this.apmBtnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.billbtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Main.xaml"
            this.billbtn.Click += new System.Windows.RoutedEventHandler(this.billBtnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.regbtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Main.xaml"
            this.regbtn.Click += new System.Windows.RoutedEventHandler(this.RegBtnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.frame1 = ((System.Windows.Controls.Frame)(target));
            return;
            case 8:
            this.logoutbtn = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\Main.xaml"
            this.logoutbtn.Click += new System.Windows.RoutedEventHandler(this.logoutbtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.chBtn = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\Main.xaml"
            this.chBtn.Click += new System.Windows.RoutedEventHandler(this.chBtnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

