namespace StackTyoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<Command> undo = new();
            Stack<Command> redo = new();

            string line;
            while (true)
            {
                Console.Write("Url ('exit' to quit): ");
                line = Console.ReadLine()!.ToLower();
                if (line == "exit") break;
                if(line == "back")
                {
                    if (undo.Count > 0)
                    {
                        redo.Push(undo.Pop());
                    }
                    else continue;
                }
                else if (line == "forword")
                {
                    if (redo.Count > 0)
                    {
                        undo.Push(redo.Pop());
                    }
                    else continue;
                }
                else
                {
                    // add url to undo list
                    undo.Push(new Command(line));
                }
                Console.Clear();
                Print("Back", undo);
                Print("Forword", redo);
            }

            // Peek
            /*
            Stack<int> numbers = new Stack<int>(new List<int> { 1, 2, 3 });

            while(numbers.Count > 0)
            {
                var n = numbers.Peek();

                Console.WriteLine(n);
            } 
             */
        }

        static void Print(string name, Stack<Command> command)
        {
            Console.WriteLine($"{name} history");
            Console.BackgroundColor = name.ToLower() ==  "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
            foreach (Command item in command)
            {
                Console.WriteLine($"\t{item}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    class Command(string url)
    {
        private readonly DateTime _createdAt = DateTime.Now;
        private readonly string _url = url;
        public override string ToString()
        {
            return $"[{_createdAt:yyyy-MM-dd hh:mm}] {_url}";
        }
    }
}