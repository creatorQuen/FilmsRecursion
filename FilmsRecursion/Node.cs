using System;
using System.Collections.Generic;
using System.Text;

namespace FilmsRecursion
{
    public class Node
    {
        public static List<int> BoxSizes; // Один общий для всех.
        public int EmptyPlace; // Сколько места останлось в конкретной ноде.

        public List<int> CurrentBoxes;

        // Если хотим найти ноду то нам надо хранить ссылки на следующие ноды.
        public List<Node> Next;

        public Node(int emptyPlace, List<int> currtneBox = null)
        {
            // Надо понимать сколько свободного места.
            // И какие коробки уже лежат.
            EmptyPlace = emptyPlace;

            if(currtneBox != null)
            {
                CurrentBoxes = currtneBox;
            }
            else
            {
                CurrentBoxes = new List<int>();
            }

            Next = new List<Node>();
        }

        // Задача постоения графа.
        public void CreateGraph()
        {
            foreach(int box in BoxSizes)
            {
                if(box <= EmptyPlace)
                {
                    List<int> tmp = new List<int>();
                    foreach(int q in CurrentBoxes)
                    {
                        tmp.Add(q);
                    }
                    tmp.Add(box);

                    Node node = new Node(EmptyPlace - box, tmp);

                    Next.Add(node);
                    node.CreateGraph();
                    // Т.е. мы не на прямую этот же метод вызываем много раз подряд, мы создаем новый инстанс для храниния разных вещей и у него метод вызываем.
                }
                


            }
        }


        // Метод котрый бежит до листиков и выводит список листиков.
        public void WriteAllEnds()
        {
            // Пройти в глубину и вывести результаты которые получились. Проверка что все работает.

            // Если count равен нулю то он понимает что он в листике. Т.е. дальше листиков нет. Веток дальше не идет.
            // Мы проверяем количечство ссылок так как мы не можем гарантировать сколько их будет (их может 0 или 50).
            if (Next.Count == 0)
            {
                // Получается если нет куда спускаться - ввывод.
                foreach (int w in CurrentBoxes)
                {
                    Console.Write(w +  " ");
                }
                Console.WriteLine();
            }
            else
            {
                // Иначе нам надо пройти по каждой ссылке.
                // Спустить по очереди везде.
                foreach (Node q in Next)
                {
                    q.WriteAllEnds();
                }
            }




        }

        // Возвращение. Но необходимо EmptyPlace. Пользоваться рекурсивно пользоваться широтным обходом.
        // Сколько осталось свободного места и мой список. В ноде сравнить самый маленький и перекинуть наверх.
        // Сортировки поиск минимума.
        public Result GetResult()
        {
            if(Next.Count == 0)
            {
                return new Result(EmptyPlace, CurrentBoxes);
            }
            else
            {
                // Усли есть нвследники.
                // Просим все собрать.
                List<Result> results = new List<Result>();
                foreach (Node q in Next)
                {
                    results.Add(q.GetResult());
                }

                Result minResult = results[0];
                foreach (Result q in results)
                {
                    if(minResult.EmptyPlace > q.EmptyPlace)
                    {
                        minResult = q;
                    }
                }

                return minResult;

            }
        }


        // Задача поиска решения.
    }


    // Для возвращения за раз два типа. Эта модель класс - у которого много полей.
    public class Result
    {
        public int EmptyPlace;

        // В том случае если не тконцовок возвращаем new result.

        public List<int> CurrentBoxes;

        public Result(int emptyPlace, List<int> currentBoxes)
        {
            EmptyPlace = emptyPlace;
            CurrentBoxes = currentBoxes;
        }
    }
}
