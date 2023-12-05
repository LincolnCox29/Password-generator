using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Xml.Xsl;
using static System.Net.Mime.MediaTypeNames;

namespace PassGenerator;

public static class Program
{
    public static void Main(string[] args)
    {

        //long
        Console.WriteLine($"  Hello, this`s a password generator ;)");

        Console.Write($"Password length: ");

        int PassLong = Convert.ToInt32(Console.ReadLine());

        //complexity
        Console.Write("  1)Easy - Lowercase letters only \n  2)Normal - Lowercase letters and numbers \n" +
            "  3)Hard - +Capital letters and special characters (The characters are not repeated in a row) \nPassword complexity:");

        int ComplexityType = Convert.ToInt32(Console.ReadLine());

        //ignore
        Console.Write("  If you want to add characters to the ignore list (don`t use space). Else press Enter: ");

        string ignore = Console.ReadLine();

        char[] ignore_char = ignore.ToCharArray();

        //char lists

            //easy
        List<char> easy_list = new()  {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

            //norm
        List<char> norm_list = new() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        easy_list.ForEach(item => norm_list.Add(item));

            //hard
        List<char> hard_list = new() { '!', '@', '#', '$', ';', '%', ':', '?', '*', '(', ')', '-', '_', '+', '=' ,
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        norm_list.ForEach(item => hard_list.Add(item));

        //
        //Start generating
        //

        int char_index;

        List<string> password = new ();

        while (PassLong > 0) 
        {

            if (ComplexityType == 1) //easy pass//
            {
               
                easy_list.RemoveAll(x => ignore.Contains(x));

                char_index = rnd.Next(1, easy_list.Count);

                password.Add(Convert.ToString(easy_list[char_index]));

            }
            else if (ComplexityType == 2) //norm pass//
            {
                norm_list.RemoveAll(x => ignore.Contains(x));

                char_index = rnd.Next(1, norm_list.Count);

                password = Del_repeat(norm_list, password, char_index, rnd);
            }
            else if (ComplexityType == 3)
            {
                hard_list.RemoveAll(x => ignore.Contains(x));

                char_index = rnd.Next(1, hard_list.Count);

                password = Del_repeat(hard_list, password, char_index, rnd);


            }
            PassLong -= 1;

        }
        for (int i = 0; i < password.Count; i++)
        {
            Console.Write(password[i]);
        }

        Console.ReadKey();


    }

    static List<string> Del_repeat(List<char> ListVar, List<string> password, int char_index, Random rnd)
    {
        if (password.Count > 0)
        {
            if (Convert.ToBoolean(ListVar[char_index] == Convert.ToChar(password.Last())))
            {

                char_index = rnd.Next(1, ListVar.Count);

            }
            password.Add(Convert.ToString(ListVar[char_index]));

        }
        else
        {

            password.Add(Convert.ToString(ListVar[char_index]));

        }
        return password;
    }
    static readonly Random rnd = new Random();
}
