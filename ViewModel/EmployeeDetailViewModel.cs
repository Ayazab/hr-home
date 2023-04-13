using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HR_One.ViewModel
{
    public class EmployeeDetailViewModel : INotifyPropertyChanged
    {
        private EmployeeDetails _employeeDetail;
        private ProjectDetails _selectedItem;
        private GetEmployeeProjectModel _employeeProjectModel;
        private string _genderImage;
        private bool _isRunning;
        private ObservableCollection<ProjectDetails> _employeeProjectDetails;
        public EmployeeDetails EmployeeDetail
        {
            get => _employeeDetail;
            set
            {
                _employeeDetail = value;
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
        public ObservableCollection<ProjectDetails> EmployeeProjectDetails
        {
            get => _employeeProjectDetails;
            set
            {
                _employeeProjectDetails = value;
                OnPropertyChanged();
            }
        }
        public string GenderImage
        {
            get => _genderImage;
            set
            {
                _genderImage = value;
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

        public EmployeeDetailViewModel()
        {
            _employeeProjectModel = new GetEmployeeProjectModel();
        }

        public async Task GetEmployeeProjectListAsync()
        {
            _employeeProjectModel.Id = EmployeeDetail.Id;
            IsRunning = true;
            var result = await _employeeProjectModel.GetProjectDetailsAsync();
            EmployeeProjectDetails = _employeeProjectModel.ProjectDetails.ToObservableCollection();
            IsRunning = false;
        }
        public void GenderImageChange()
        {
            if(EmployeeDetail.Gender == "Male")
            {
                GenderImage = "male_employee";
            }
            else
            {
                GenderImage = "female_employee";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
