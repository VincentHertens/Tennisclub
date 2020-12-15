﻿#pragma checksum "..\..\..\..\Views\RoleView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6B7D2CA30AF02BEDACF541F08AA52498C50D99EB"
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
using System.Windows.Controls.Ribbon;
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
using Tennisclub_WPF.Validations;
using Tennisclub_WPF.Views;


namespace Tennisclub_WPF.Views {
    
    
    /// <summary>
    /// RoleView
    /// </summary>
    public partial class RoleView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\Views\RoleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RolesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Views\RoleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ManagementGrid;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Views\RoleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ManagementNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Views\RoleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddRoleBtn;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\Views\RoleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateRoleBtn;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\Views\RoleView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewRoleBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Tennisclub_WPF;component/views/roleview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\RoleView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RolesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.ManagementGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.ManagementNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddRoleBtn = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\..\Views\RoleView.xaml"
            this.AddRoleBtn.Click += new System.Windows.RoutedEventHandler(this.AddRoleBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UpdateRoleBtn = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\..\Views\RoleView.xaml"
            this.UpdateRoleBtn.Click += new System.Windows.RoutedEventHandler(this.UpdateRoleBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NewRoleBtn = ((System.Windows.Controls.Button)(target));
            
            #line 159 "..\..\..\..\Views\RoleView.xaml"
            this.NewRoleBtn.Click += new System.Windows.RoutedEventHandler(this.NewRoleBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

