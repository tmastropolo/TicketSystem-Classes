using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicketSystem19
{
    class TaskFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public string tfile { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskFile (string path)
        {
            logger.Info("Find Task File");
            Tasks = new List<Task>();
            tfile = path;

            StreamReader sr = new StreamReader(tfile);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                logger.Info("Read task file");
                Task task = new Task();
                string line = sr.ReadLine();
                String[] taskDetail = line.Split(',');

                task.ticketID = UInt16.Parse(taskDetail[0]);
                task.summery = taskDetail[1];
                task.status = taskDetail[2];
                task.priority = taskDetail[3];
                task.submitter = taskDetail[4];
                task.assigned = taskDetail[5];
                task.watching = taskDetail[6].Split('|').ToList();
                task.projectName = taskDetail[7];
                task.dueDate = Convert.ToDateTime(taskDetail[8]);

                Tasks.Add(task);
            }
            sr.Close();
        }
        public void AddTask(Task  task)
        {
            logger.Info("Add Task ticket");
            task.ticketID = Tasks.Max(t => t.ticketID) + 1;
            string summery = task.summery.IndexOf(',') != -1 ? $"\"{task.summery}\"" : task.summery;
            StreamWriter sw = new StreamWriter(tfile, true);
            sw.WriteLine($"{task.ticketID},{task.summery},{task.status},{task.priority},{task.submitter},{task.assigned},{string.Join(", ", task.watching)},{task.projectName},{task.dueDate} ");
            sw.Close();

        }
    }
}
