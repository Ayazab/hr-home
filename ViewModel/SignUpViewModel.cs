using CommunityToolkit.Maui.Alerts;
using HR_One.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace HR_One.ViewModel.SignUp
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _username;
        private string _password;
        private string _confirmPassword;
        private EmployeeDatabase _employeeDatabase;

        //string EmailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\r\n";
        //^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
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
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }


        public ICommand RegisterCommand { get; private set; }
        public SignUpViewModel()
        {
            _employeeDatabase = new EmployeeDatabase();
            _employeeDatabase.CreateEmployeeDatabase();
            _ = _employeeDatabase.CreateEmployeeTableAsync();
            _ = _employeeDatabase.GetEmployeeListAsync();
            RegisterCommand = new Command(Validation);
        }

        private void Validation()
        {
            bool isValid = IsValidEmail(Email);

            if (string.IsNullOrWhiteSpace(Email))
            {
                Toast.Make("Please enter Email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            //else if (Regex.IsMatch(Email, EmailPattern))
            else if(isValid == false)
            {
                Toast.Make("Please enter valid Email", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (_employeeDatabase.SignUpDetails.Where(x=>x.Email == Email).Count()>0)
            {
                Toast.Make("Email is already registered", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Username))
            {
                Toast.Make("Please enter username", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                Toast.Make("Please enter password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (Password.Length < 6 || Password.Length > 12)
            {
                Toast.Make("Password must contain 6-12 characters", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (ConfirmPassword != Password)
            {
                Toast.Make("Password doesn't match", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                Toast.Make("User registered successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                _ = RegisterDetailsAsync();
            }


        }

        private async Task RegisterDetailsAsync()
        {
            _employeeDatabase.Email = Email;
            _employeeDatabase.Password = Password;
            _employeeDatabase.Username = Username;
            var result = await _employeeDatabase.InsertEmployeeRecordAsync();
            Email = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
