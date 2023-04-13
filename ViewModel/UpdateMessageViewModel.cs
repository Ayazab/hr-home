using CommunityToolkit.Maui.Alerts;
using HR_One.HttpModel;
using HR_One.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HR_One.ViewModel
{
    public class UpdateMessageViewModel : INotifyPropertyChanged
    {
        public event EventHandler<Results> UpdateEvent;
        
        private UpdateMessageModel _updateMessageModel;
        private MessageDetails _messageDetails;

        private int _id;
        private string _title;
        private string _body;

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
        public MessageDetails MessageDetails
        {
            get => _messageDetails;
            set
            {
                _messageDetails = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateMessageCommand { get; private set; }
        public UpdateMessageViewModel()
        {
            _updateMessageModel= new UpdateMessageModel();
            UpdateMessageCommand = new Command(() => { _ = UpdateMessageDetails(MessageDetails); }); 
        }

        public async Task UpdateMessageDetails(MessageDetails messageDetails)
        {
            

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
                _updateMessageModel.Id = Id;
                _updateMessageModel.Title = Title;
                _updateMessageModel.Body = Body;
                var result = await _updateMessageModel.UpdateMessageDetailsAsync();
                UpdateEvent?.Invoke(this, result);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}