using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CylinderProgressDemo.Controls;

public partial class CylinderProgress : UserControl
{
    bool _hasAppliedTemplate = false;

    /// <summary>
    ///   Define our value property
    /// </summary>
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value),
        typeof(double),
        typeof(CylinderProgress),
        new PropertyMetadata(0d, OnValueChanged));
    public double Value
    {
        get { return (double)this.GetValue(ValueProperty); }
        set { this.SetValue(ValueProperty, value); }
    }
    static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var cp = d as CylinderProgress;
        if (cp != null && e.NewValue != null)
        {
            try
            {
                double target = 0;
                if (cp.MaxValue <= cp.MinValue || cp.MaxValue <= 0)
                {
                    Debug.WriteLine($"[WARNING] MaxValue cannot be less than MinValue.");
                    cp.MaxValue = cp.MinValue + 1;
                    target = cp.MaxValue;
                }
                else if ((double)e.NewValue > cp.MaxValue)
                {
                    Debug.WriteLine($"[WARNING] Value cannot be greater than MaxValue.");
                    target = cp.MaxValue;
                }
                else if ((double)e.NewValue < cp.MinValue)
                {
                    Debug.WriteLine($"[WARNING] Value cannot be less than MinValue.");
                    target = cp.MinValue;
                }
                else
                {
                    target = (double)e.NewValue;
                }

                // Control height and maximum value can be independent.
                target = (cp.Height / cp.MaxValue) * target;
                //Debug.WriteLine($"[INFO] e.NewValue is {(double)e.NewValue}, converted target to {target}");
                var dba = new DoubleAnimation
                {
                    Duration = TimeSpan.FromMilliseconds(500),
                    FillBehavior = FillBehavior.HoldEnd,
                    To = target,
                    From = cp.cylinderBottom.ActualHeight,
                    EasingFunction = new SineEase()
                };
                cp.cylinderBottom.BeginAnimation(Rectangle.HeightProperty, dba);
                cp.cylinderTop.BeginAnimation(Rectangle.HeightProperty, dba);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ERROR] OnValueChanged: {ex.Message}");
            }
        }
    }

    /// <summary>
    ///   Define our max value property
    /// </summary>
    public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
        nameof(MaxValue),
        typeof(double),
        typeof(CylinderProgress),
        new PropertyMetadata(250d, OnMaxValueChanged));
    public double MaxValue
    {
        get { return (double)this.GetValue(MaxValueProperty); }
        set { this.SetValue(MaxValueProperty, value); }
    }
    static void OnMaxValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var cp = d as CylinderProgress;
        if (cp != null && e.NewValue != null)
        {
            //cp.rect.Height = (double)e.NewValue;
        }
    }

    /// <summary>
    ///   Define our min value property
    /// </summary>
    public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
        nameof(MinValue),
        typeof(double),
        typeof(CylinderProgress),
        new PropertyMetadata(10d, OnMinValueChanged));
    public double MinValue
    {
        get { return (double)this.GetValue(MinValueProperty); }
        set { this.SetValue(MinValueProperty, value); }
    }
    static void OnMinValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var cp = d as CylinderProgress;
        if (cp != null && e.NewValue != null)
        {
            //cp.rect.Height = (double)e.NewValue;
        }
    }

    /// <summary>
    ///   Define our fill brush property
    /// </summary>
    public static readonly DependencyProperty FillBrushProperty = DependencyProperty.Register(
        nameof(FillBrush),
        typeof(Brush),
        typeof(CylinderProgress),
        new PropertyMetadata(new SolidColorBrush(Colors.DodgerBlue)));
    public Brush FillBrush
    {
        get { return (Brush)this.GetValue(FillBrushProperty); }
        set { this.SetValue(FillBrushProperty, value); }
    }

    /// <summary>
    ///   Define our cylinder width property
    /// </summary>
    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
        nameof(Width),
        typeof(double),
        typeof(CylinderProgress),
        new PropertyMetadata(50d, OnWidthChanged));
    public double Width
    {
        get { return (double)this.GetValue(WidthProperty); }
        set { this.SetValue(WidthProperty, value); }
    }
    static void OnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var cp = d as CylinderProgress;
        if (cp != null && e.NewValue != null)
        {
            //cp.rect.Width = (double)e.NewValue;
        }
    }

    /// <summary>
    ///   Define our cylinder height property
    /// </summary>
    public static readonly DependencyProperty HeightProperty = DependencyProperty.Register(
        nameof(Height),
        typeof(double),
        typeof(CylinderProgress),
        new PropertyMetadata(250d, OnHeightChanged));

    public double Height
    {
        get { return (double)this.GetValue(HeightProperty); }
        set { this.SetValue(HeightProperty, value); }
    }
    static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var cp = d as CylinderProgress;
        if (cp != null && e.NewValue != null)
        {
            //cp.rect.Height = (double)e.NewValue;
        }
    }

    public CylinderProgress()
    {
        InitializeComponent();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _hasAppliedTemplate = true;
        Debug.WriteLine($"[INFO] {nameof(CylinderProgress)} template has been applied.");
    }
}
