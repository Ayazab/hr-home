using CommunityToolkit.Maui.Alerts;
using HR_One.Model;
using HR_One.ViewModel;

namespace HR_One.Views;

public partial class EditMessagePage : ContentPage
{
	private UpdateMessageViewModel _viewModel;
	public EditMessagePage(HttpModel.MessageDetails messageDetails)
	{
		InitializeComponent();
		_viewModel = (UpdateMessageViewModel)BindingContext;
        _viewModel.MessageDetails = messageDetails;
		_viewModel.UpdateEvent += UpdateEventHandler;
	}

    private async void UpdateEventHandler(object sender, Results e)
    {
        if (e.IsSuccess)
        {
            await Navigation.PopAsync();
            _ = Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            _ = Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}