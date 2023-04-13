using HR_One.ViewModel.SignUp;

namespace HR_One.Views;

public partial class SignUpPage : ContentPage
{
	private SignUpViewModel _viewModel;
	public SignUpPage()
	{
		InitializeComponent();
		_viewModel = (SignUpViewModel)BindingContext;
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new SignInPage());
    }
}