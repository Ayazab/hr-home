using HR_One.HttpModel;
using HR_One.ViewModel;
using HR_One.ViewModel.Emp;

namespace HR_One.Views;

public partial class EmployeeDetailsPage : ContentPage
{
	private EmployeeViewModel _viewModel;
	public EmployeeDetailsPage()
	{
		InitializeComponent();
		_viewModel = (EmployeeViewModel)BindingContext;
		_ = _viewModel.GetEmployeeListAsync();
		_viewModel.EmployeeDetailEvent += EmployeeDetailEventHandler;
	}

    private async void EmployeeDetailEventHandler(object sender, EmployeeDetails e)
    {
		await Navigation.PushAsync(new EmployeeDetailPage(_viewModel.SelectedItem));
    }
}