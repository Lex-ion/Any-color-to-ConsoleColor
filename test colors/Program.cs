using System.Drawing;


namespace test_colors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            

            Color color = Color.Firebrick;

            Console.BackgroundColor = GetCC(color);
            Console.Clear();

        }


        public static ConsoleColor GetCC(Color c)
        {
            ConsoleColor wc = 0;

            Color[] rc = new Color[16];

            for (int i = 0; i < rc.Length; i++)
            {
                ConsoleColor mc = (ConsoleColor)i;
                rc[i] = Color.FromName(mc.ToString());
            }//tohle může být v cyklu pod


            int[] scores = new int[rc.Length];

            for (int i = 0; i < scores.Length; i++)// v tomhle
            {

                int scoreR = Math.Abs(rc[i].R - c.R);
                int scoreG = Math.Abs(rc[i].G - c.G);
                int scoreB = Math.Abs(rc[i].B - c.B);
                scores[i] = scoreR + scoreG + scoreB;

            }



            int smallest = scores[0];
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] < smallest)
                {
                    smallest = scores[i];
                }
            }
            for (int i = 0; i < scores.Length; i++)
            {
                if (smallest == scores[i])
                {
                    wc = (ConsoleColor)i;
                    break;
                }
            }
            return wc;

        }
    }
}