using HR_One.HttpModel;
using HR_One.ViewModel;

namespace HR_One.Views;

public partial class ProjectDetailPage : ContentPage
{
	private ProjectDetailViewModel _viewModel;
	public ProjectDetailPage(HttpModel.ProjectDetails selectedItem)
	{
		InitializeComponent();
		_viewModel = (ProjectDetailViewModel)BindingContext;
		_viewModel.SelectedItem = selectedItem;
		_ = _viewModel.GetProjectMessageListAsync();
		_viewModel.EditEvent += EditEventHandler;
	}

    private async void EditEventHandler(object sender, EventArgs e)
    {
        MessageDetails messageDetails = new()
		{
			Id = _viewModel.Id,
			Title = _viewModel.Title,
			Body= _viewModel.Body,
		};
        await Navigation.PushAsync(new EditMessagePage(messageDetails));
    }

    private async void NewMessage_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddMessagePage());
    }

    
}