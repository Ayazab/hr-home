using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.Project
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProjectDetails> _projectDetails;
        private GetProjectModel _projectModel;
        private bool _isRunning;
        private bool _isVisible;
        private ProjectDetails _selectedItem;
        public event EventHandler<ProjectDetails> ProjectDetailEvent;
        public ObservableCollection<ProjectDetails> ProjectDetails
        {
            get => _projectDetails;
            set
            {
                _projectDetails = value;
                OnPropertyChanged();
            }
        }
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public ProjectDetails SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectionChangeCommand { get; private set; }
        public ProjectViewModel()
        {
            _projectModel= new GetProjectModel();
            SelectionChangeCommand = new Command(ShowProjectDetails);
        }

        private void ShowProjectDetails(object obj)
        {
            ProjectDetailEvent?.Invoke(this, SelectedItem);
        }

        public async Task GetProjectListAsync()
        {
            IsRunning = true;
            IsVisible = false;
            await _projectModel.GetProjectDetailsAsync();
            ProjectDetails = _projectModel.ProjectDetails.ToObservableCollection();
            IsRunning = false;
            IsVisible = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
