/*  Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints "yes CONTENT_OF_STRING" if it is a valid card sign or "no CONTENT_OF_STRING" otherwise. */

using System;

class PlayCard
{
    static void Main()
    {
        string sign = Console.ReadLine();

        bool isAllowedNumber = ((sign.Length == 1) && ('1' < char.Parse(sign) && char.Parse(sign) <= '9')) || sign == "10";
        bool isAllowedLetter = sign == "J" || sign == "Q" || sign == "K" || sign == "A";
        if (isAllowedNumber || isAllowedLetter)
        {
            Console.WriteLine("yes {0}", sign);
        }
        else
        {
            Console.WriteLine("no {0}", sign);
        }
    }
}

