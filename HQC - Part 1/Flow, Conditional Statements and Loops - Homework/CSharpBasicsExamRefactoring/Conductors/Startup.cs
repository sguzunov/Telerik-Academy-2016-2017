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

        private static uint PerforateATicket(uint perforator, uint ticket)
        {
            string perforatorAsBinary = Convert.ToString(perforator, 2);
            string ticketAsBinary = Convert.ToString(ticket, 2);

            for (int i = 0; i <= ticketAsBinary.Length - perforatorAsBinary.Length; i++)
            {
                bool canPerforateATicket = CanPerforate(perforator, ticket, i);
                if (canPerforateATicket)
                {
                    ticket = SetBitsToZero(ticket, i, perforatorAsBinary.Length);
                }
            }

            return ticket;
        }

        // Sets all bits to zero depending on perforator's length.
        private static uint SetBitsToZero(uint ticket, int ticketIndex, int bitsCount)
        {
            for (int offset = 0; offset < bitsCount; offset++)
            {
                int ticketOffset = ticketIndex + offset;
                uint ticketBit = (ticket >> ticketOffset) & 1u;
                if (ticketBit == 1)
                {
                    ticket = ticket & (~(1u << ticketOffset));
                }
            }

            return ticket;
        }

        private static bool CanPerforate(uint perforator, uint ticket, int ticketIndex)
        {
            int perforatorBinaryLength = Convert.ToString(perforator, 2).Length;
            for (int offset = 0; offset < perforatorBinaryLength; offset++)
            {
                uint perforatorBit = (perforator >> offset) & 1u;
                int ticketOffset = ticketIndex + offset;
                uint ticketBit = (ticket >> ticketOffset) & 1u;
                if (perforatorBit != ticketBit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
