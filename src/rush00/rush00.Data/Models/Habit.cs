namespace rush00.Data.Models
{
    public class Habit
    {
        public Habit(string title, string motivation, int numDays)
        {
            Title = title;
            Motivation = motivation;
            NumDays = numDays;
            Checks = new(NumDays);
            for (int i = 0; i < NumDays; ++i)
            {
                Checks.Add(new HabitCheck(DateTime.Now.AddDays(i), false));
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Motivation { get; set; }
        public int NumDays { get; set; }
        public List<HabitCheck>? Checks { get; private set; }
        public bool IsFinihed { 
            get 
            {
                DateTime endDate = DateTime.Now.AddDays(NumDays - 1);
                return DateTime.Now > endDate || Checks.All(check => check.IsChecked);
            } 
        }
        
    }
}