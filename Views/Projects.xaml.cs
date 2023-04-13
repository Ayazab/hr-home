using HR_One.HttpModel;
using HR_One.ViewModel;
using HR_One.ViewModel.Project;

namespace HR_One.Views;

public partial class ProjectDetailsPage : ContentPage
{
	private ProjectViewModel _viewModel;
	public ProjectDetailsPage()
	{
		InitializeComponent();
		_viewModel = (ProjectViewModel)BindingContext;
		_ = _viewModel.GetProjectListAsync();
		_viewModel.ProjectDetailEvent += ProjectDetailEventHandler;
	}

    private async void ProjectDetailEventHandler(object sender, ProjectDetails e)
    {
        await Navigation.PushAsync(new ProjectDetailPage(_viewModel.SelectedItem));
    }
}