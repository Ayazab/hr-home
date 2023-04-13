using CommunityToolkit.Maui.Alerts;
using HR_One.Model;
using HR_One.ViewModel;

namespace HR_One.Views;

public partial class AddMessagePage : ContentPage
{
	private AddMessageViewModel _viewModel;
	public AddMessagePage()
	{
		InitializeComponent();
		_viewModel = (AddMessageViewModel)BindingContext;
		_viewModel.AddEvent += AddEventHandler;
	}

    private async void AddEventHandler(object sender, Results e)
    {
		if (e.IsSuccess)
		{
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            _viewModel.Title = string.Empty;
            _viewModel.Body = string.Empty;
        }
        else
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}