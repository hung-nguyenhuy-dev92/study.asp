using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiApp.Helpers
{
    public class Strings
    {
        /*internal static async Task<string> Async1(string value)
        {
            await Task.Delay(3000);
            return value;
        }*/

        public static async Task<string> Async1(string value)
        {
            await Task.Delay(3000);
            return value;
        }

        public static async Task TestWaitOrWhenAll()
        {
            /*var t1 = Task.Run(async () =>
            {
                Console.WriteLine("task 1");
                *//*await Task.Delay(3000);*//*
                Thread.Sleep(2000);
                Console.WriteLine("task 1 sau");
            });
            var t2 = Task.Run(() => Console.WriteLine("task 2"));
            var t3 = Task.Run(() => Console.WriteLine("task 3"));*/
            // lưu ý: WhenAll sẽ có kết quả trả về, còn WaitAll thì không thường sẽ sử dung WhenAll 
            /*1*/
            /*Task.WaitAll(t1, t2, t3);*/
            /*2*/
            /*Task.WaitAll(new Task[] { t1, t2, t3 });*/
            /*3*/
            /*Task.WaitAll(new Task[] { t1, t2, t3 }, 1000);*/
            /*4*/
            /*Task.WhenAll(t1, t2, t3);*/
            /*5*/
            /*Task.WhenAll(new Task[] { t1, t2, t3 });*/
            /*6*/
            /*await Task.WhenAll(new Task[] { t1, t2, t3 });*/
            /*7*/
            /*var t4 = Task.WhenAll(new Task[] { t1, t2, t3 }); 
            t4.Wait();*/
            /*8*/ // thêm Task.Delay(2000).GetAwaiter().GetResult(); sau Strings.TestWaitOrWhenAll() ()
            /*Task.WhenAll(new Task[] { t1, t2, t3 });*/
            /*9*/ // thêm Task.Delay(3000).GetAwaiter().GetResult(); sau Strings.TestWaitOrWhenAll() ()
            /*Task.WaitAll(new Task[] { t1, t2, t3 });*/


            Console.WriteLine("Thead Vs Async/Await");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            await TaskOneNotReturn();
            await TaskTwoNotReturn();

            /*var task_one = await TaskOne();
            var task_two = await TaskTwo("Hùng");

            Console.WriteLine($"Data tasl one: {task_one}");
            Console.WriteLine($"Data tasl two: {task_two}");*/
            /*var task_one = TaskOne();
            var task_two = TaskTwo("Tai");
            var results = await Task.WhenAll(task_one, task_two);
            Console.WriteLine($"Data results: task one: {results[0]} task two: {results[1]}");*/
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }

        private static async Task<string> TaskOne()
        {
            await Task.Delay(4000);
            return "TaskOne";
        }

        private static async Task<string> TaskTwo(string name)
        {
            await Task.Delay(2000);
            return "Hello " + name;
        }

        private static async Task TaskOneNotReturn()
        {
            /*Thread.Sleep(3000);*/
            await Task.Delay(3000);
            Console.WriteLine("TaskOne");
        }

        private static async Task TaskTwoNotReturn()
        {
            await Task.Delay(1000);
            /*Thread.Sleep(1000);*/
            Console.WriteLine("TaskTwo");
        }
    }
}
