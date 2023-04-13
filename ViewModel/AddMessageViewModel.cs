using CommunityToolkit.Maui.Alerts;
using HR_One.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel
{
    public class AddMessageViewModel : INotifyPropertyChanged
    {
        public event EventHandler<Results> AddEvent;
        private AddMessageModel _addMessageModel;
        private string _title;
        private string _body;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Body
        {
            get => _body;
            set
            {
                _body = value;
                OnPropertyChanged();
            }
        }

        
        public ICommand AddMessageCommand { get; private set; }

        public AddMessageViewModel()
        {
            _addMessageModel = new AddMessageModel();
            AddMessageCommand = new Command(() => { _ = AddMessageDetails(); });
        }

        public async Task AddMessageDetails()
        {
            _addMessageModel.Title = Title;
            _addMessageModel.Body = Body;

            if (string.IsNullOrWhiteSpace(Title))
            {
                _ = Toast.Make("Please enter title", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Body))
            {
                _ = Toast.Make("Body can not be empty", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                var result = await _addMessageModel.AddMessageDetailsAsync();
                AddEvent?.Invoke(this, result);
            }
        }

        /*private void Validation()
        {

        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
