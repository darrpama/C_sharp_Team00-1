namespace team_00
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
        public string Title { get; private set; }
        public string Motivation {  get; private set; }
        public int NumDays { get; private set; }
        public List<HabitCheck> Checks { get; private set; }
        public bool IsFinihed { 
            get 
            {
                DateTime endDate = DateTime.Now.AddDays(NumDays - 1);
                return DateTime.Now > endDate || Checks.All(check => check.IsChecked);
            } 
        }
        
    }
}