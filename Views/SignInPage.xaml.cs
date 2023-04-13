
using CommunityToolkit.Maui.Alerts;
using HR_One.Model;
using HR_One.ViewModel.SignIn;

namespace HR_One.Views;

public partial class SignInPage : ContentPage
{
	private SignInViewModel _viewModel;
	public SignInPage()
	{
		InitializeComponent();
		_viewModel = (SignInViewModel)BindingContext;
		_viewModel.SignInEvent += SignInEventHandler;
	}

    private void SignInEventHandler(object sender, Results e)
    {
		if (e.IsSuccess)
		{
            Toast.Make("Welcome " + _viewModel.username, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            Navigation.PushAsync(new DashboardPage());
            var firstPage = Navigation.NavigationStack.ElementAtOrDefault(0);
            if (firstPage != null)
            {
                Navigation.RemovePage(firstPage);
            }
        }
		else
		{
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();		
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new SignUpPage());
    }
}