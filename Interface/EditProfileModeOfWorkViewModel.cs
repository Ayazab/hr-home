using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DeskBook
{
    public class EditProfileModeOfWorkViewModel : BaseViewModel
    {

        private EditProfileModeOfWorkModel _selectedDay;
        private string _selectedOption;
        private bool _isHybridSelected;
        private bool _isSelected;

        public List<string> Options { get; set; }
        public ObservableCollection<EditProfileModeOfWorkModel> HybridModeDaysDetails { get; set; }
        

        public EditProfileModeOfWorkModel SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                _selectedDay = value;
                OnPropertyChanged();
            }
        }


        public string SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
                OnPropertyChanged();
                IsHybridSelected = _selectedOption == "Hybrid";
            }
        }

        public bool IsHybridSelected
        {
            get => _isHybridSelected;
            set
            {
                _isHybridSelected = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        
        public EditProfileModeOfWorkViewModel()
        {

            HybridModeDaysDetails = new ObservableCollection<EditProfileModeOfWorkModel>
            {
            new EditProfileModeOfWorkModel()
            {
                Day = "MON",

            },
            new EditProfileModeOfWorkModel()
            {
                Day = "TUE"
            },
            new EditProfileModeOfWorkModel()
            {
                Day = "WED"
            },
            new EditProfileModeOfWorkModel()
            {
                Day = "THU"
            },
            new EditProfileModeOfWorkModel()
            {
                Day = "FRI"
            }
            };


            foreach (var item in HybridModeDaysDetails)
            {
                item.BgColor = Color.FromArgb("#E5E7EA");
            }

            Options = new List<string>
            {
                "Regular",
                "Hybrid",
                "Work From Home"
            };
        }
    }
}
