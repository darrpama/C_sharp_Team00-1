namespace team_00
{
    public class HabitCheck
    {
        public HabitCheck(DateTime date, bool ischecked)
        {
            _date = date;
            _ischecked = ischecked;
        }

        public bool IsChecked {
            get { return _ischecked; }
            private set { _ischecked = value; }
        }
        public void SetState() { _ischecked = !_ischecked; }

        public int Id { get; set; }
        public DateTime Date { get { return _date; } }
        private readonly DateTime _date;
        private bool _ischecked;
    }
}