﻿#pragma checksum "..\..\staffReg.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A1328175BA6D56D764CEEE830420A36D"
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
    /// staffReg
    /// </summary>
    public partial class staffReg : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox S_Name;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox S_Address;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox S_Pno;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton S_Male;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton S_Female;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button staffRegAddbtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button staffRegClosebtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox S_Age;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\staffReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker S_Date;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/staffreg.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\staffReg.xaml"
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
            this.S_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.S_Address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.S_Pno = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.S_Male = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.S_Female = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.staffRegAddbtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\staffReg.xaml"
            this.staffRegAddbtn.Click += new System.Windows.RoutedEventHandler(this.staffRegAddbtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.staffRegClosebtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\staffReg.xaml"
            this.staffRegClosebtn.Click += new System.Windows.RoutedEventHandler(this.staffRegClosebtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.S_Age = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.S_Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

