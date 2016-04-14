using System;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication
{
    public class Program
    {
        private static bool IsExecuting;
        public static void Main(string[] args)
        {
            ShowMessage("Starting up!");
            
            IsExecuting = true;
            ShowTime();
           
            ShowMessage("Press Enter when complete");
            ReadMessage();
            IsExecuting = false;
            
            Thread.Sleep(2000);
        }
        
        private static void ShowTime()
        {
             Action showTime = ()=>{
                while(IsExecuting)
                {
                    ShowMessage("The Current Time is " + DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
                ShowMessage("Time is done!");
            };
            
            var timeTask = new Task(showTime);
            timeTask.Start();
        }
        
        private static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        private static string ReadMessage()
        {
            return Console.ReadLine();
        }
        
       
    }
}
