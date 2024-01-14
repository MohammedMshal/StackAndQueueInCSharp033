namespace QueueType
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<PrintingJob> printingJobs = new Queue<PrintingJob>();
            printingJobs.Enqueue(new PrintingJob("documentation.docx", 2));
            printingJobs.Enqueue(new PrintingJob("user-stories.pdf", 6));
            printingJobs.Enqueue(new PrintingJob("report.xlsx", 6));
            printingJobs.Enqueue(new PrintingJob("payroll.report", 5));
            printingJobs.Enqueue(new PrintingJob("budget.xlsx", 4));
            printingJobs.Enqueue(new PrintingJob("algorithm.ppt", 1));

            Random rnd = new();
            while (printingJobs.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var job = printingJobs.Dequeue();
                Console.WriteLine($"printing ... [{job}]");
                System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);
                Console.WriteLine($"Current  After while Queue Count: {printingJobs.Count}");
            }

            // use try 
            /*
             Queue<int> numbers = new Queue<int>();

            if(numbers.TryPeek(out int n))
            {
                Console.WriteLine(n);

            }

            Console.ReadKey();
             */

        } // end main
    }

    class PrintingJob(string file, int copies)
    {
        private readonly string _file = file;
        private readonly int _copies = copies;
        public override string ToString()
        {
            return $"{_file} x {_copies}";
        }
    }
}