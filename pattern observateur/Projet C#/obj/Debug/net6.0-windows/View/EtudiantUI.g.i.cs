﻿#pragma checksum "..\..\..\..\View\EtudiantUI.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A55E46E73EBAF9EF32E240F16A3F4C52AD937EE8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjetDP;
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


namespace ProjetDP.View {
    
    
    /// <summary>
    /// EtudiantUI
    /// </summary>
    public partial class EtudiantUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIdEtudiant;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNom;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPrenom;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMoyenne;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjouter;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModifier;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSupprimer;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\EtudiantUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvEtudiant;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Etudiant_DP_Observateur;component/view/etudiantui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\EtudiantUI.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\View\EtudiantUI.xaml"
            ((ProjetDP.View.EtudiantUI)(target)).Loaded += new System.Windows.RoutedEventHandler(this.initUI);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtIdEtudiant = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtNom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPrenom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtMoyenne = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnAjouter = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\View\EtudiantUI.xaml"
            this.btnAjouter.Click += new System.Windows.RoutedEventHandler(this.btnAjouterClic);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnModifier = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\View\EtudiantUI.xaml"
            this.btnModifier.Click += new System.Windows.RoutedEventHandler(this.btnModfiierClic);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSupprimer = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\View\EtudiantUI.xaml"
            this.btnSupprimer.Click += new System.Windows.RoutedEventHandler(this.btnSupprimerClic);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lsvEtudiant = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

