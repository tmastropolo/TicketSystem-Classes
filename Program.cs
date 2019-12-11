using System;
using System.IO;
using NLog;

namespace TicketSystem19
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();




        public static void Main(string[] args)
        {
            logger.Info("Start of prgram");

            string file = "ticket.csv";
            string efile = "enhancement.csv";
            string tfile = "task.csv";
            TicketFile ticketFile = new TicketFile(file);
            EnhanceFile enhanceFile = new EnhanceFile(efile);
            TaskFile taskFile = new TaskFile(tfile);

            try
            {
                string choice;



                string[] header =
                {
                "Ticket ID: ",
                "Summary: ",
                "Status: ",
                "Priority: ",
                "Submitter: ",
                "Assigned: ",
                "Watching: "
            };

                do
                {
                    logger.Info("First choice ");
                    Console.WriteLine("1) Add Tickets");
                    Console.WriteLine("2) Add Enhance Tickets");
                    Console.WriteLine("3) Add Tasks");

                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        logger.Info("Tickets Section");
                        Console.WriteLine("1) Add Tickets");
                        Console.WriteLine("2) View Tickets");
                        Console.WriteLine("3) Exit");
                        string Tchoice = Console.ReadLine();

                        do
                        {
                            if (Tchoice == "1")
                            {
                                logger.Info("Add Ticket ");
                                Ticket ticket = new Ticket();
                                Console.WriteLine("Enter Ticket Summery");
                                ticket.summery = Console.ReadLine();
                                Console.WriteLine("Enter Status");
                                ticket.summery = Console.ReadLine();
                                Console.WriteLine("Ennter the priority");
                                ticket.priority = Console.ReadLine();
                                Console.WriteLine("Enter submitter");
                                ticket.submitter = Console.ReadLine();
                                Console.WriteLine("Enter Assigned");
                                ticket.assigned = Console.ReadLine();

                                string input;

                                do
                                {
                                    Console.WriteLine("Enter who is watching the Ticket (or done to quit)");
                                    input = Console.ReadLine();
                                    if (input != "done" && input.Length > 0)
                                    {
                                        ticket.watching.Add(input);
                                    }
                                } while (input != "done");

                                if (ticket.watching.Count == 0)
                                {
                                    ticket.watching.Add("(no people watching)");
                                }

                                ticketFile.AddTicket(ticket);
                            }

                            else if (Tchoice == "2")
                            {
                                logger.Info("Display Ticket");
                                foreach (Ticket t in ticketFile.Tickets)
                                {
                                    Console.WriteLine(t.Display());
                                }
                            }
                        } while (Tchoice == "1" || Tchoice == "2");
                    }
                    else if (choice == "2")
                    {
                        logger.Info("Enhanced Tickets");
                        Console.WriteLine("1) Add Enhanced Tickets");
                        Console.WriteLine("2) View Enhanced Tickets");
                        Console.WriteLine("3) Exit");
                        string Echoice = Console.ReadLine();

                        do
                        {
                            if (Echoice == "1")
                            {
                                logger.Info("New Enhanced Ticekt");
                                Enhancement enhancement = new Enhancement();

                                Console.WriteLine("Enter Ticket Summery");
                                enhancement.summery = Console.ReadLine();
                                Console.WriteLine("Enter Status");
                                enhancement.summery = Console.ReadLine();
                                Console.WriteLine("Ennter the priority");
                                enhancement.priority = Console.ReadLine();
                                Console.WriteLine("Enter submitter");
                                enhancement.submitter = Console.ReadLine();
                                Console.WriteLine("Enter Assigned");
                                enhancement.assigned = Console.ReadLine();

                                string input;

                                do
                                {

                                    Console.WriteLine("Enter who is watching the Ticket (or done to quit)");
                                    input = Console.ReadLine();
                                    if (input != "done" && input.Length > 0)
                                    {
                                        enhancement.watching.Add(input);
                                    }
                                } while (input != "done");

                                if (enhancement.watching.Count == 0)
                                {
                                    enhancement.watching.Add("(no people watching)");
                                }

                                Console.WriteLine("Enter Software");
                                enhancement.software = Console.ReadLine();
                                Console.WriteLine("Enter Cost");
                                enhancement.cost = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter Reason");
                                enhancement.reason = Console.ReadLine();
                                Console.WriteLine("Enter Estimate");
                                enhancement.estimate = Convert.ToDouble(Console.ReadLine());
                                enhanceFile.AddEnhance(enhancement);
                            }

                            else if (Echoice == "2")
                            {
                                logger.Info("Dispaly Enhanced ticket");
                                foreach (Enhancement e in enhanceFile.Enhances)
                                {
                                    Console.WriteLine(e.Display());
                                }
                            }
                        } while (Echoice == "3");
                    }
                    else if (choice == "3")
                    {
                        logger.Info("Task Ticket");
                        Console.WriteLine("1) Add Task Tickets");
                        Console.WriteLine("2) View Task Tickets");
                        Console.WriteLine("3) Exit");
                        string Tskchoice = Console.ReadLine();

                        do
                        {
                            if (Tskchoice == "1")
                            {
                                logger.Info("New Task Ticket");
                                Task task = new Task();

                                Console.WriteLine("Enter Ticket Summery");
                                task.summery = Console.ReadLine();
                                Console.WriteLine("Enter Status");
                                task.summery = Console.ReadLine();
                                Console.WriteLine("Ennter the priority");
                                task.priority = Console.ReadLine();
                                Console.WriteLine("Enter submitter");
                                task.submitter = Console.ReadLine();
                                Console.WriteLine("Enter Assigned");
                                task.assigned = Console.ReadLine();

                                string input;

                                do
                                {
                                    Console.WriteLine("Enter who is watching the Ticket (or done to quit)");
                                    input = Console.ReadLine();
                                    if (input != "done" && input.Length > 0)
                                    {
                                        task.watching.Add(input);
                                    }
                                } while (input != "done");

                                if (task.watching.Count == 0)
                                {
                                    task.watching.Add("(no people watching)");
                                }

                                Console.WriteLine("Enter Software");
                                task.projectName = Console.ReadLine();
                                Console.WriteLine("Enter Due Date");
                                task.dueDate = Convert.ToDateTime(Console.ReadLine());
                            }

                            else if (Tskchoice == "2")
                            {
                                logger.Info("Display Task");
                                foreach (Task e in taskFile.Tasks)
                                {
                                    Console.WriteLine(e.Display());
                                }
                            }


                        } while (Tskchoice == "3");

                    }


                } while (choice == "3");
            }
            catch (Exception e)
            {
                logger.Error("file not loaded");
            }
            logger.Info("EOF");
        }
        
    }
}
        