using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Task2Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            //1. Создать List, ArrayList и LinkedList.
            //2. Добавить в каждый 1 000 000 элементов
            //3. Замерить длительность заполнения каждой коллекции через Stopwatch.Start() и Stopwatch.Stop() и вывести значения на экран

            var arrLength = 1000000;
            Stopwatch stopWatch = Stopwatch.StartNew();

            List<int> list = new List<int>();
            stopWatch.Start();
            for (int i=0; i < arrLength; i++)
            {
                list.Add(i);
            }
            stopWatch.Stop();
            strings.Add($"Время добавления 1 000 000 элементов в List<int> равно [ {stopWatch.ElapsedMilliseconds} ]");


            ArrayList arrList= new ArrayList();
            stopWatch.Restart();
            for (int i = 0; i < arrLength; i++)
            {
                arrList.Add(i);
            }
            stopWatch.Stop();
            strings.Add($"Время добавления 1 000 000 элементов в ArrayList равно [ {stopWatch.ElapsedMilliseconds} ]");

            LinkedList<int> linkList= new LinkedList<int>();
            stopWatch.Restart();
            for (int i = 0; i < arrLength; i++)
            {
                linkList.AddLast(i);
            }
            stopWatch.Stop();
            strings.Add($"Время добавления 1 000 000 элементов в LinkedList<int> равно [ {stopWatch.ElapsedMilliseconds} ]");

            //5. Найти 496753-ий элемент, замерить длительность этого поиска в каждой коллекции и вывести значение на экран

            stopWatch.Restart();
            var listEl=list.ElementAt(496752);
            stopWatch.Stop();
            strings.Add($"Время поиска 496753-го элемента в List<int> равно [ {stopWatch.ElapsedMilliseconds} ]");

            stopWatch.Restart();
            var arrlistEl = arrList[496752];
            stopWatch.Stop();
            strings.Add($"Время поиска 496753-го элемента в ArrayList равно [ {stopWatch.ElapsedMilliseconds} ]");

            stopWatch.Restart();
            var linkListEl = linkList.ElementAt(496752);
            stopWatch.Stop();
            strings.Add($"Время поиска 496753-го элемента в LinkedList<int> равно [ {stopWatch.ElapsedMilliseconds} ]");

            //6. Вывести на экран каждый элемент коллекции, который без остатка делится на 777. Вывести длительность этой операции для каждой коллекции.

            stopWatch.Restart();
            list.ForEach(it => {
                if (it % 777 == 0)
                    {
                        Console.WriteLine(it);
                    }
                }
            );
            stopWatch.Stop();
            strings.Add($"Время вывода на экран каждого элемента, который делится без остатка на 777 из List<int> равно [ {stopWatch.ElapsedMilliseconds} ]");

            stopWatch.Restart();
            foreach (int it in arrList)
            {
                if (it % 777 == 0)
                {
                    Console.WriteLine(it);
                }
            }
            stopWatch.Stop();
            strings.Add($"Время вывода на экран каждого элемента, который делится без остатка на 777 из ArrayList равно [ {stopWatch.ElapsedMilliseconds} ]");

            stopWatch.Restart();
            foreach (int it in linkList)
            {
                if (it % 777 == 0)
                {
                    Console.WriteLine(it);
                }
            }
            stopWatch.Stop();
            strings.Add($"I способ ( через цикл foreach ) . Время вывода на экран каждого элемента, который делится без остатка на 777 из LinkedList<int> равно [ {stopWatch.ElapsedMilliseconds} ]");

            //второй способ прохода по linkedlist
            stopWatch.Restart();
            var currentNode = linkList.First;
            while (currentNode != null)
            {
                if (currentNode.Value % 777 == 0)
                {
                    Console.WriteLine(currentNode.Value);
                }
                currentNode = currentNode.Next;
            }
            stopWatch.Stop();
            strings.Add($"II способ ( через цикл while ). Время вывода на экран каждого элемента, который делится без остатка на 777 из LinkedList<int> равно [ {stopWatch.ElapsedMilliseconds} ]");

            strings.ForEach(it=> Console.WriteLine(it));
            Console.ReadKey();
        }
    }
}
