using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem19
{
   public class Ticket
    {
        public UInt64 ticketID { get; set; }
        public String summery { get; set; }
        public String status { get; set; }
        public String priority { get; set; }
        public String submitter { get; set; }
        public String assigned { get; set; }
        public List<string> watching { get; set; }

        public virtual string Display()
        {
            return $"Ticket Id: {ticketID}\nTitle: {summery}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssinged: {assigned}\nWatching: {string.Join(", ", watching)}\n";
        }
    }

    public class Enhancement : Ticket
    {
        public String software { get; set; }
        public Double cost { get; set; }
        public String reason { get; set; }
        public Double estimate { get; set; }

        public override string Display()
        {
            return $"Ticket Id: {ticketID}\nTitle: {summery}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssinged: {assigned}\nWatching: {string.Join(", ", watching)}\nSoftware: {software}\nCost : {cost}\nReason : {reason}\n Estimate : {estimate}";
        }

    }

    public class Task : Ticket
    {
        public String projectName { get; set; }
        public DateTime dueDate { get; set; }

        public virtual string Display()
        {
            return $"Ticket Id: {ticketID}\nTitle: {summery}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssinged: {assigned}\nWatching: {string.Join(", ", watching)}\nProject Name: {projectName}\nDue Date: {dueDate}";
        }
    }
}


