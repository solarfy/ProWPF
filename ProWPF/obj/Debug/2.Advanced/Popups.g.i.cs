﻿#pragma checksum "..\..\..\2.Advanced\Popups.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "009D5E9F8AA97330D878C3AEE19D5A85331439D7D31574CDD3A2053F5C8A2223"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using ProWPF.Advanced;
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


namespace ProWPF.Advanced {
    
    
    /// <summary>
    /// Popups
    /// </summary>
    public partial class Popups : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\2.Advanced\Popups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run runMouseOver;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\2.Advanced\Popups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\2.Advanced\Popups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupNone;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\2.Advanced\Popups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupFade;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\2.Advanced\Popups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupScroll;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\2.Advanced\Popups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupSlide;
        
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
            System.Uri resourceLocater = new System.Uri("/ProWPF;component/2.advanced/popups.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\2.Advanced\Popups.xaml"
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
            
            #line 21 "..\..\..\2.Advanced\Popups.xaml"
            ((System.Windows.Documents.Run)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OpenPopup_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.runMouseOver = ((System.Windows.Documents.Run)(target));
            return;
            case 3:
            this.popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 4:
            
            #line 30 "..\..\..\2.Advanced\Popups.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OpenNonePopup_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 31 "..\..\..\2.Advanced\Popups.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OpenFadePopup_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 32 "..\..\..\2.Advanced\Popups.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OpenScrollPopup_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 33 "..\..\..\2.Advanced\Popups.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OpenSlidePopup_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.popupNone = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 9:
            this.popupFade = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            this.popupScroll = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 11:
            this.popupSlide = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
