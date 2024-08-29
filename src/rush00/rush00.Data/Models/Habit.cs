namespace rush00.Data.Models
{
    public class Habit
    {
        public Habit() { }
        public Habit(string? title, string? motivation, int numDays, DateTimeOffset startDate)
        {
            Title = title;
            Motivation = motivation;
            NumDays = numDays;
            Checks = new(NumDays);
            for (int i = 0; i < NumDays; ++i)
            {
                Checks.Add(new HabitCheck(startDate.Date.AddDays(i), false));
            }
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Motivation { get; set; }
        public int NumDays { get; set; }
        public List<HabitCheck>? Checks { get; set; }
        public bool IsFinished { 
            get 
            {
                DateTime endDate = DateTime.Now.AddDays(NumDays - 1);
                return Checks != null && (DateTime.Now > endDate || Checks.All(check => check.IsChecked) || Checks.Last().IsChecked);
            } 
        }
        
    }
}