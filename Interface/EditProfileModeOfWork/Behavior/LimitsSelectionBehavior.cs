

namespace DeskBook
{
    public class LimitSelectionBehavior : Behavior<CollectionView>
    {
        private EditProfileModeOfWorkViewModel _viewModel;
        public static readonly BindableProperty MaxSelectedItemsProperty =
            BindableProperty.Create(nameof(MaxSelectedItems), typeof(int), typeof(LimitSelectionBehavior), defaultValue: 0);

        public int MaxSelectedItems
        {
            get { return (int)GetValue(MaxSelectedItemsProperty); }
            set { SetValue(MaxSelectedItemsProperty, value); }
        }

        protected override void OnAttachedTo(CollectionView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetachingFrom(CollectionView bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.SelectionChanged -= OnSelectionChanged;
        }

        public LimitSelectionBehavior()
        {
                _viewModel = new EditProfileModeOfWorkViewModel();
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MaxSelectedItems <= 0)
                return;

            var collectionView = (CollectionView)sender;
            var selectedItems = collectionView.SelectedItems;
            if (selectedItems.Count > MaxSelectedItems)
            {
                //_viewModel.IsSelected = false;

                var lastItem = e.PreviousSelection.FirstOrDefault();
                collectionView.SelectedItems.Remove(lastItem);
            }
        }
    }

}
