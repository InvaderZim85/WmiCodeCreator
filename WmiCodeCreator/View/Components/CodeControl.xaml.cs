using System.Windows;
using System.Windows.Controls;

namespace WmiCodeCreator.View.Components
{
    /// <summary>
    /// Interaction logic for CodeControl.xaml
    /// </summary>
    public partial class CodeControl : UserControl
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CodeControl"/>
        /// </summary>
        public CodeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The dependency property of <see cref="SourceCode"/>
        /// </summary>
        public static readonly DependencyProperty SourceCodeProperty = DependencyProperty.Register(
            nameof(SourceCode), typeof(string), typeof(CodeControl), new PropertyMetadata(default(string)));

        /// <summary>
        /// Gets or sets the source code
        /// </summary>
        public string SourceCode
        {
            get => (string) GetValue(SourceCodeProperty);
            set
            {
                SetValue(SourceCodeProperty, value);
                CodeEditorControl.Text = value;
            }
        }
    }
}
