class pgm{
    public static void Main(string[] args){
	int count = 0;
	int guess;

        Random randGen = new Random();
        int target = rand.Next(1000);

	Console.WriteLine("Target is: {0}",target);

	while(true){
		Console.WriteLine("Guess:");
		count++;
		guess = Int32.Parse(Console.ReadLine())
		if(guess == target) {
                	Console.WriteLine("Correct\n");
			break;
		}
		if(target > guess){
			Console.WriteLine("Too small");
		} else {
			Console.WriteLine("Too large");
		}
	}
	Console.WriteLine("Count:{0}",count);
}