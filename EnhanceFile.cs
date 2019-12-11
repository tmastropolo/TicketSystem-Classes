using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicketSystem19
{
    class EnhanceFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public string efile { get; set; }
        public List<Enhancement> Enhances { get; set; }

        public EnhanceFile(string path)
        {
            logger.Info("Start of Enhanced file");
            Enhances = new List<Enhancement>();
            efile = path;


            StreamReader sr = new StreamReader(efile);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                logger.Info("Enhance File");
                Enhancement enhancement = new Enhancement();
                string line = sr.ReadLine();
                String[] enhanceDetail = line.Split(",");
                enhancement.ticketID = UInt16.Parse(enhanceDetail[0]);
                enhancement.summery = enhanceDetail[1];
                enhancement.status = enhanceDetail[2];
                enhancement.priority = enhanceDetail[3];
                enhancement.submitter = enhanceDetail[4];
                enhancement.assigned = enhanceDetail[5];
                enhancement.watching = enhanceDetail[6].Split('|').ToList();
                enhancement.software = enhanceDetail[7];
                enhancement.cost = Convert.ToDouble( enhanceDetail[8]);
                enhancement.reason = enhanceDetail[9];
                enhancement.estimate = Convert.ToDouble(enhanceDetail[10]);

                Enhances.Add(enhancement);
                
            }
            sr.Close();
        }

        public void AddEnhance(Enhancement enhancement)
        {
            logger.Info("Add Enhanced ticket");
            enhancement.ticketID = Enhances.Max(t => t.ticketID) + 1;
            string summery = enhancement.summery.IndexOf(',') != -1 ? $"\"{enhancement.summery}\"" : enhancement.summery;
            StreamWriter sw = new StreamWriter(efile, true);
            sw.WriteLine($"{enhancement.ticketID},{enhancement.summery},{enhancement.status},{enhancement.priority},{enhancement.submitter},{enhancement.assigned},{string.Join(", ", enhancement.watching)}," +
                $"{enhancement.software}, {enhancement.cost}, {enhancement.reason}, {enhancement.estimate}");
            sw.Close();
        }
    }
}
