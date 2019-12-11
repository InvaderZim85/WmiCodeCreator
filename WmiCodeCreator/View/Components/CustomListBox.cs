using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace WmiCodeCreator.View.Components
{
    /// <summary>
    /// Provides a custom list box which supports the multiple selection of items
    /// </summary>
    internal class CustomListBox : ListBox
    {
        /// <summary>
        /// The dependency property of <see cref="SelectedItemsList"/>
        /// </summary>
        public static readonly DependencyProperty SelectedItemsListProperty = DependencyProperty.Register(
            nameof(SelectedItemsList), typeof(IList), typeof(CustomListBox), new PropertyMetadata(default(IList)));

        /// <summary>
        /// Gets or sets the TODO
        /// </summary>
        public IList SelectedItemsList
        {
            get => (IList) GetValue(SelectedItemsListProperty);
            set => SetValue(SelectedItemsListProperty, value);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CustomListBox"/>
        /// </summary>
        public CustomListBox()
        {
            SelectionChanged += CustomListBox_SelectionChanged;
        }

        /// <summary>
        /// Occurs when the user changes the selection
        /// </summary>
        private void CustomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItemsList == null)
                return;

            SelectedItemsList.Clear();
            foreach (var item in SelectedItems)
            {
                SelectedItemsList.Add(item);
            }
        }
    }
}
