using HR_One.HttpModel;
using HR_One.ViewModel;
using HR_One.ViewModel.Emp;

namespace HR_One.Views;

public partial class EmployeeDetailPage : ContentPage
{
	private EmployeeDetailViewModel _viewModel;
	public EmployeeDetailPage(EmployeeDetails employeeDetail)
	{
		InitializeComponent();
		_viewModel = (EmployeeDetailViewModel)BindingContext;
		_viewModel.EmployeeDetail= employeeDetail;
		
		_viewModel.GenderImageChange();
		_ = _viewModel.GetEmployeeProjectListAsync();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new ProjectDetailPage(_viewModel.SelectedItem));
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
		
    }
}