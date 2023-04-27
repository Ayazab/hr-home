using CommunityToolkit.Maui.Alerts;

namespace DeskBook.Views;

public partial class EditProfileModeOfWorkPage : ContentPage
{
	public EditProfileModeOfWorkPage()
	{
		InitializeComponent();
	}

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var collectionView = (CollectionView)sender;

        // Check if number of selected items exceed 4
        if (collectionView.SelectedItems.Count > 4)
        {
            // Remove last item from selected items
            var lastSelectedItem = collectionView.SelectedItems.LastOrDefault();
            collectionView.SelectedItems.Remove(lastSelectedItem);

            // Show toast message
            Toast.Make("You can select maximum 4 days", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}