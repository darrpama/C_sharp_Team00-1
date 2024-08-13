namespace rush00.Data.Models
{
    public class HabitCheck
    {
        public HabitCheck(DateTime date, bool isChecked)
        {
            Date = date;
            IsChecked = isChecked;
        }

        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public DateTime Date { get; set; }
    }
}