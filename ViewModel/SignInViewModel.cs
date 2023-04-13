using CommunityToolkit.Maui.Alerts;
using HR_One.Database;
using HR_One.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel.SignIn
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private string _username;
        private EmployeeDatabase _employeeDatabase;
        public event EventHandler<Results> SignInEvent;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }
        public SignInViewModel()
        {
            _employeeDatabase = new EmployeeDatabase();
            _employeeDatabase.CreateEmployeeDatabase();
            _ = _employeeDatabase.CreateEmployeeTableAsync();
            LoginCommand = new Command(Validation);
        }

        private void Validation()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                Toast.Make("Please enter Email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                Toast.Make("Please enter password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                _ = LoginDetailsAsync();
            }
        }
        public async Task LoginDetailsAsync()
        {
            _employeeDatabase.Email = Email;
            _employeeDatabase.Password = Password;
            var result = await _employeeDatabase.GetUserInfo();
            username = _employeeDatabase.Username;
            SignInEvent?.Invoke(this, result);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
