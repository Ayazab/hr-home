using CommunityToolkit.Maui.Core.Extensions;
using HR_One.HttpModel;
using HR_One.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HR_One.ViewModel
{
    public class ProjectDetailViewModel : INotifyPropertyChanged
    {
        private ProjectDetails _selectedItem;
        private GetProjectMessageModel _messageModel;
        private string _msg;
        private bool _isRunning;
        private ObservableCollection<MessageDetails> _messageDetails;
        private int _id;
        private string _title;
        private string _body;
        public event EventHandler EditEvent;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

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
        public string EmptyView { get; set; }

        public ProjectDetails SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public string Message
        {
            get => _msg;
            set
            {
                _msg = value;
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
        public ObservableCollection<MessageDetails> MessageDetails
        {
            get => _messageDetails;
            set
            {
                _messageDetails = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditCommand { get; set; }
        public ProjectDetailViewModel()
        {
            _messageModel = new GetProjectMessageModel();
            EditCommand = new Command<MessageDetails>(EditDetails);
        }

        public void EditDetails(MessageDetails messageDetails)
        {
            Id = messageDetails.Id;
            Title = messageDetails.Title;
            Body = messageDetails.Body;
            EditEvent?.Invoke(this, new EventArgs());
        }

        public async Task GetProjectMessageListAsync()
        {
            _messageModel.Id = SelectedItem.Id;
            IsRunning = true;
            await _messageModel.GetProjectMessageDetailsAsync();
            MessageDetails = _messageModel.MessageDetails.ToObservableCollection();
            MessageCount();
            IsRunning= false;

        }

        private void MessageCount()
        {
            var count = MessageDetails.Count();
            if(count == 1)
            {
                Message = count + " Message";
            }
            else if(count > 1)
            {
                Message = count + " Messages";
            }
            else if(MessageDetails == null)
            {
                IsRunning= false;
                EmptyView = "No Message Available!!!";
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    
}
