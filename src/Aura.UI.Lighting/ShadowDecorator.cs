﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Lighting
{
    public class ShadowDecorator : Border
    {
         public readonly static AttachedProperty<bool> VisibleProperty =
            AvaloniaProperty.RegisterAttached<ShadowDecorator, Control, bool>("Visible", false);

        public static bool GetVisible(Control control) => control.GetValue(VisibleProperty);
        public static void SetVisible(Control control, bool value) => control.SetValue(VisibleProperty, value);

        /// <summary>
        /// Defines the Shadow that decorates the control
        /// </summary>
        public static readonly AttachedProperty<BoxShadows> ShadowProperty =
            AvaloniaProperty.RegisterAttached<ShadowDecorator, Control, BoxShadows>(
                "Shadow", Shadows.DefaultShadow, true, BindingMode.TwoWay);

        public static BoxShadows GetShadow(Control element) => element.GetValue(ShadowProperty);
        public static void SetShadow(Control element, BoxShadows value) => element.SetValue(ShadowProperty, value);

        /// <summary>
        /// Defines the CornerRadius of the Shadow
        /// </summary>
        public static readonly AttachedProperty<CornerRadius> ShadowCornerRadiusProperty =
            AvaloniaProperty.RegisterAttached<ShadowDecorator, Control, CornerRadius>(
                "ShadowCornerRadius", new CornerRadius(0), true, BindingMode.TwoWay);

        public static CornerRadius GetShadowCornerRadius(Control element) => element.GetValue(ShadowCornerRadiusProperty);
        public static void SetShadowCornerRadius(Control element, CornerRadius value) => element.SetValue(ShadowCornerRadiusProperty, value);

        public static readonly AttachedProperty<Border> CurrentProperty = 
            AvaloniaProperty.RegisterAttached<ShadowDecorator, Control, Border>("Current");
        public static Border GetCurrent(Control control) => control.GetValue(CurrentProperty);
        public static void SetCurrent(Control control, Border value) => control.SetValue(CurrentProperty, value);

        static ShadowDecorator()
        {
            //var app = Application.Current;

            //if(app is IClassicDesktopStyleApplicationLifetime c)
            //{
            //    c.MainWindow.TemplateApplied += (s, e) =>
            //    {
                    
            //    };
            //}
            //else if(app is ISingleViewApplicationLifetime s)
            //{

            //}
            //ShadowProperty.Changed.AddClassHandler<Control>(ShadowDecoratorService.Current.ShadowChanged);
            //ShadowCornerRadiusProperty.Changed.AddClassHandler<Control>(ShadowDecoratorService.Current.ShadowCornerRadiusChanged);

            VisibleProperty.Changed.Subscribe(ShadowDecoratorService.Current.VisibleChanged);
            ShadowProperty.Changed.Subscribe(ShadowDecoratorService.Current.ShadowChanged);
            ShadowCornerRadiusProperty.Changed.Subscribe(ShadowDecoratorService.Current.ShadowCornerRadiusChanged);

            

            Debug.WriteLine("subscriptions added");
        }
    } 
}
