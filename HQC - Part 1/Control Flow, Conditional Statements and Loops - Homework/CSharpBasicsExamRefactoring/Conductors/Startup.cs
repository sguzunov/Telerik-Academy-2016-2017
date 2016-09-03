namespace Conductors
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            uint perforator = uint.Parse(Console.ReadLine());
            int ticketsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ticketsCount; i++)
            {
                uint ticket = uint.Parse(Console.ReadLine());
                Console.WriteLine(PerforateATicket(perforator, ticket));
            }
        }

        private static string PerforateATicket(uint perforator, uint ticket)
        {
            string perforatorAsBinary = Convert.ToString(perforator, 2);
            string ticketAsBinary = Convert.ToString(ticket, 2);

            for (int i = ticketAsBinary.Length - 1; i >= perforatorAsBinary.Length - 1; i--)
            {
                bool canPerforate = CanPerforate(perforatorAsBinary, ticketAsBinary, i);
                if (canPerforate)
                {
                    ticketAsBinary = Perforate(ticketAsBinary, i, perforatorAsBinary.Length);
                }
            }

            return ticketAsBinary;
        }

        private static string Perforate(string ticket, int ticketIndex, int perforatorLength)
        {
            var perforatedTicket = ticket.ToCharArray();
            for (int i = 0; i < perforatorLength; i++)
            {
                perforatedTicket[ticketIndex] = '0';
                ticketIndex--;
            }

            return string.Join(string.Empty, perforatedTicket);
        }

        private static bool CanPerforate(string perforator, string ticket, int ticketStartIndex)
        {
            int ticketIndex = ticketStartIndex;
            for (int i = perforator.Length - 1; i >= 0; i--)
            {
                if (perforator[i] != ticket[ticketIndex])
                {
                    return false;
                }

                ticketIndex--;
            }

            return true;
        }
    }
}
