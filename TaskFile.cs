using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicketSystem19
{
    class TaskFile
    {
        public string filepath { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskFile (string path)
        {
            Tasks = new List<Task>();
            filepath = path;

            StreamReader sr = new StreamReader(filepath);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
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
            task.ticketID = Tasks.Max(t => t.ticketID) + 1;
            string summery = task.summery.IndexOf(',') != -1 ? $"\"{task.summery}\"" : task.summery;
            StreamWriter sw = new StreamWriter(filepath, true);
            sw.WriteLine($"{task.ticketID},{task.summery},{task.status},{task.priority},{task.submitter},{task.assigned},{string.Join(", ", task.watching)},{task.projectName},{task.dueDate} ");
            sw.Close();

        }
    }
}
