#pragma checksum "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "269A8F8E3C56F3BDD7AE9FA55147AAEC3874C9AB8E887DD1243FC6AA3368A14E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using ProWPF.ShapeAndAnimation;
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


namespace ProWPF.ShapeAndAnimation {
    
    
    /// <summary>
    /// AdvancedAnimation
    /// </summary>
    public partial class AdvancedAnimation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 346 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayer;
        
        #line default
        #line hidden
        
        
        #line 348 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border;
        
        #line default
        #line hidden
        
        
        #line 405 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayVisual;
        
        #line default
        #line hidden
        
        
        #line 407 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderDocument;
        
        #line default
        #line hidden
        
        
        #line 412 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectBlocked;
        
        #line default
        #line hidden
        
        
        #line 415 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectVisual;
        
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
            System.Uri resourceLocater = new System.Uri("/ProWPF;component/3.shapeandanimation/advancedanimation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
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
            
            #line 309 "..\..\..\3.ShapeAndAnimation\AdvancedAnimation.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).CurrentTimeInvalidated += new System.EventHandler(this.SlideVisual_CurrentTimeInvalidated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPlayer = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.border = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.btnPlayVisual = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.borderDocument = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.rectBlocked = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.rectVisual = ((System.Windows.Shapes.Rectangle)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

