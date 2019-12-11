using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicketSystem19
{
    class TicketFile
    {
        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }
        public TicketFile(string path)
        {
            Tickets = new List<Ticket>();
            filePath = path;

            StreamReader sr = new StreamReader(filePath);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
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
            ticket.ticketID = Tickets.Max(t => t.ticketID) + 1;
            string summery = ticket.summery.IndexOf(',') != -1 ? $"\"{ticket.summery}\"" : ticket.summery;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{ticket.ticketID},{ticket.summery},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join(", ", ticket.watching)}");
            sw.Close();

        }
    }
}
