using Lab4.Objects;

    public static class AddLaborerExtension
    {
           
        public static void AddLaborer(this ChoreWorkforce myWorkforce, string name, int age, int difficulty)
        {
            myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = name, Age = age, Difficulty = difficulty });
        }


    }

    public static class AddRandomLaborerExtension
    {
        static string[] malePetNames = [ "Rufus", "Bear", "Dakota", "Fido",
                        "Vanya", "Samuel", "Koani", "Volodya",
                        "Prince", "Yiska", "Billy" ];    
        public static void AddRandomLaborer(this ChoreWorkforce myWorkforce)
        {
            var rand = new Random();
            int name = rand.Next(11);
            int age = rand.Next(19);
            int difficulty = rand.Next(1, 11);
            ChoreLaborer newlaborer = new ChoreLaborer(){   Name = malePetNames[name], Age = age, Difficulty = difficulty };
            if(difficulty == 10)
            {
                newlaborer = null;
            }
            myWorkforce.Laborers.Add(newlaborer);
        }
    }