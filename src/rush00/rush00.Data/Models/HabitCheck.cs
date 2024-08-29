using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace rush00.Data.Models
{
    public class HabitCheck : INotifyPropertyChanged
    {
        public HabitCheck(DateTime date, bool isChecked)
        {
            Date = date;
            IsChecked = isChecked;
        }
        
        [Key]
        public int Id { get; set; }
        
        public int HabitId { get; set; }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}