using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace SummerProject.DependencyProperties
{
    public class FunctionChoosePanel : StackPanel
    {
        private PackIcon _packIcon;
        private TextBlock _textBlock;

        public PackIconKind ButtonIcon
        {
            get => (PackIconKind) GetValue(ChangeIconProperty);
            set => SetValue(ChangeIconProperty, value);
        }

        public string FunctionName
        {
            get => (string) GetValue(ChangeFunctionNameProperty);
            set => SetValue(ChangeFunctionNameProperty, value);
        }

        public static DependencyProperty ChangeIconProperty = DependencyProperty.Register("ChangeIcon",
            typeof(PackIconKind), typeof(FunctionChoosePanel),
            new PropertyMetadata(PackIconKind.ViewDashboard, IconChanged));

        public static DependencyProperty ChangeFunctionNameProperty = DependencyProperty.Register("ChangeFunctionName",
            typeof(string), typeof(FunctionChoosePanel), new PropertyMetadata("Function Name", FunctionNameChanged));

        private static void FunctionNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var functionChooseButton = d as FunctionChoosePanel;
            Debug.Assert(functionChooseButton != null, nameof(functionChooseButton) + " != null");
            functionChooseButton._textBlock.Text = functionChooseButton.FunctionName;
        }

        private static void IconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var functionChooseButton = d as FunctionChoosePanel;
            Debug.Assert(functionChooseButton != null, nameof(functionChooseButton) + " != null");
            functionChooseButton._packIcon.Kind = functionChooseButton.ButtonIcon;
        }

        public FunctionChoosePanel()
        {
            //var stackPanel=new StackPanel();
            // this.Background =Brushes.Transparent; /*(SolidColorBrush)new BrushConverter().ConvertFromString("#FF29837E");*/
            // this.Foreground = Brushes.White;
            // this.BorderBrush = Brushes.Transparent;
//            this.Width = 190;
//            this.Height = 50;
            // this.Content = stackPanel;

            this.Orientation = Orientation.Horizontal;

            _packIcon = new PackIcon()
            {
                Kind = ButtonIcon,
                Width = 25,
                Height = 25,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment,
                Foreground = Brushes.White
            };

            _textBlock = new TextBlock()
            {
                Text = FunctionName,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(15, 0, 0, 0),
                Foreground = Brushes.White
            };

            this.Children.Add(_packIcon);
            this.Children.Add(_textBlock);
        }
    }
}