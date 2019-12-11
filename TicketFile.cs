using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicketSystem19
{
    class TicketFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public string file { get; set; }
        public List<Ticket> Tickets { get; set; }
        public TicketFile(string path)
        {
            logger.Info("Start of Ticket File");
            Tickets = new List<Ticket>();
            file = path;

            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                logger.Info("Read Ticket File");
                Ticket ticket = new Ticket();
                string line = sr.ReadLine();
                String[] ticketDetail = line.Split(',');

                ticket.ticketID = UInt16.Parse(ticketDetail[0]);
                ticket.summery = ticketDetail[1];
                ticket.status = ticketDetail[2];
                ticket.priority = ticketDetail[3];
                ticket.submitter = ticketDetail[4];
                ticket.assigned = ticketDetail[5];
                ticket.watching = ticketDetail[6].Split('|').ToList();

                Tickets.Add(ticket);
            }
            sr.Close();
        }

        public void AddTicket(Ticket ticket)
        {
            logger.Info("Add Ticket to file");
            ticket.ticketID = Tickets.Max(t => t.ticketID) + 1;
            string summery = ticket.summery.IndexOf(',') != -1 ? $"\"{ticket.summery}\"" : ticket.summery;
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine($"{ticket.ticketID},{ticket.summery},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join(", ", ticket.watching)}");
            sw.Close();

        }
    }
}
