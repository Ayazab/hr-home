using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HR_One.ViewModel.Emp
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EmployeeDetails> _employeeDetails;
        private GetEmployeeModel _employeeModel;
        private bool _isRunning;
        private bool _isVisible;
        private EmployeeDetails _selectedItem;
        public event EventHandler<EmployeeDetails> EmployeeDetailEvent;
        public ObservableCollection<EmployeeDetails> EmployeeDetails
        {
            get => _employeeDetails;
            set
            {
                _employeeDetails = value;
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
        public EmployeeDetails SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionChangeCommand { get; private set; }
        public EmployeeViewModel()
        {
            _employeeModel = new GetEmployeeModel();           
            SelectionChangeCommand = new Command(ShowEmployeeDetails);
        }

        private void ShowEmployeeDetails()
        {
            EmployeeDetailEvent?.Invoke(this, SelectedItem);
        }
        public async Task GetEmployeeListAsync()
        {
            IsRunning = true;
            IsVisible = false;
            var result = await _employeeModel.GetEmployeeDetailsAsync();
            EmployeeDetails = _employeeModel.EmployeeDetails.ToObservableCollection();
            IsRunning = false;
            IsVisible=true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
