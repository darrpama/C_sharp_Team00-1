namespace rush00.Data.Models
{
    public class HabitCheck
    {
        public HabitCheck(DateTime date, bool isChecked)
        {
            _date = date;
            _isChecked = isChecked;
        }

        public bool IsChecked {
            get { return _isChecked; }
            private set { _isChecked = value; }
        }
        public void SetState() { _isChecked = !_isChecked; }

        public int Id { get; set; }
        public DateTime Date { get { return _date; } }
        private readonly DateTime _date;
        private bool _isChecked;
    }
}