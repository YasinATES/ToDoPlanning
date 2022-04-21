using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Entities.Concrete;
using ToDoPlanning.WebUI.Helper;
using ToDoPlanning.WebUI.Models;

namespace ToDoPlanning.WebUI.Helper
{
    public static class SprintPlan
    {
        public static List<Developer> GetSprintPlan(IList<WorkTask> taskList)
        {
            var developers = CreateDeveloper();
            var totalWeek = (double)taskList.Sum(x => x.WorkScore) / (double)developers.Sum(x => x.DeveloperScore);
            taskList.Shuffle();

            foreach (var task in taskList)
            {
                foreach (var developer in developers)
                {
                    if (developer.WorkScore + task.WorkScore <= developer.DeveloperScore * totalWeek)
                    {
                        SetTaskDeveloper(developer, task);
                        break;
                    }
                }

                if (!developers.Any(x => x.WorkTasks.Any(y => y.Name == task.Name)))
                    SetTaskDeveloper(developers.First(x => x.Level == developers.Max(x => x.Level)), task);
            }

            return developers;
        }

        private static List<Developer> CreateDeveloper()
        {
            return new List<Developer>()
            {
                new Developer{ Name = "DEV1", Level = 1 },
                new Developer{ Name = "DEV2", Level = 2 },
                new Developer{ Name = "DEV3", Level = 3 },
                new Developer{ Name = "DEV4", Level = 4 },
                new Developer{ Name = "DEV5", Level = 5 }
            };
        }

        private static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static void SetTaskDeveloper(Developer developer, WorkTask task)
        {
            developer.WorkScore += task.WorkScore;
            task.Sprint = ((developer.WorkScore / developer.Level) / 45) + 1;
            developer.WorkTasks.Add(task);
        }

        public static double GetTotalWeek(this IEnumerable<WorkTask> taskList)
        {
            var developers = CreateDeveloper();
            var week = (double)taskList.Sum(x => x.WorkScore) / (double)developers.Sum(x => x.DeveloperScore);

            return Math.Round(week, 2);
        }
    }
}