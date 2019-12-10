using System.Windows;
using System.Windows.Controls;

namespace WmiCodeCreator.View.Components
{
    /// <summary>
    /// Interaction logic for Headline.xaml
    /// </summary>
    public partial class Headline : UserControl
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Headline"/>
        /// </summary>
        public Headline()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The dependency property of <see cref="HeaderText"/>
        /// </summary>
        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register(
            nameof(HeaderText), typeof(string), typeof(Headline), new PropertyMetadata("HEADERTEXT"));

        /// <summary>
        /// Gets or sets the header text
        /// </summary>
        public string HeaderText
        {
            get => (string) GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }

        /// <summary>
        /// The dependency property of <see cref="HeaderFontWeight"/>
        /// </summary>
        public static readonly DependencyProperty HeaderFontWeightProperty = DependencyProperty.Register(
            nameof(HeaderFontWeight), typeof(FontWeight), typeof(Headline), new PropertyMetadata(FontWeights.DemiBold));

        /// <summary>
        /// Gets or sets the font weight
        /// </summary>
        public FontWeight HeaderFontWeight
        {
            get => (FontWeight) GetValue(HeaderFontWeightProperty);
            set => SetValue(HeaderFontWeightProperty, value);
        }

        /// <summary>
        /// The dependency property of <see cref="HeaderFontStyle"/>
        /// </summary>
        public static readonly DependencyProperty HeaderFontStyleProperty = DependencyProperty.Register(
            nameof(HeaderFontStyle), typeof(FontStyle), typeof(Headline), new PropertyMetadata(FontStyles.Normal));

        /// <summary>
        /// Gets or sets the font style
        /// </summary>
        public FontStyle HeaderFontStyle
        {
            get => (FontStyle) GetValue(HeaderFontStyleProperty);
            set => SetValue(HeaderFontStyleProperty, value);
        }

        /// <summary>
        /// The dependency property of <see cref="ShowIcon"/>
        /// </summary>
        public static readonly DependencyProperty ShowIconProperty = DependencyProperty.Register(
            nameof(ShowIcon), typeof(bool), typeof(Headline), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets the value which indicates if the icon should be shown
        /// </summary>
        public bool ShowIcon
        {
            get => (bool) GetValue(ShowIconProperty);
            set => SetValue(ShowIconProperty, value);
        }
    }
}
