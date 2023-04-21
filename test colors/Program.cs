using System.Drawing;


namespace test_colors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Hello, World!");

            while (true)
            {
                Bitmap bp = new Bitmap("input.png");

                Random random = new Random();
                int offset = random.Next(17);
                double db = random.NextDouble();

                Console.ReadKey(true);
                for (int i = 0; i < bp.Height; i++)
                {
                    for (int j = 0; j < bp.Width; j++)
                    {
                        GetCC(bp.GetPixel(j, i), offset, db);

                    }
                    Console.WriteLine();
                }

                Console.ReadKey();
                Console.WriteLine("\n\n\n");
            }

        }


        public static void GetCC(Color c, int offset,double db)
        {
            
            ConsoleColor[] wc = new ConsoleColor[2];

            Color[] rc = new Color[16];

            for (int i = 0; i < rc.Length; i++)
            {
                ConsoleColor mc = (ConsoleColor)i;
                rc[i] = Color.FromName(mc.ToString());
            }//tohle může být v cyklu pod


            int[] scoresR = new int[rc.Length];
            int[] scoresG = new int[rc.Length];
            int[] scoresB = new int[rc.Length];
            int[] scoreHUE = new int[rc.Length];
            int[] saturation = new int[rc.Length];
            int[] scores = new int[rc.Length]; 

            for (int i = 0; i < scoresB.Length; i++)// v tomhle
            {

                 scoresR[i] = Math.Abs(rc[i].R - c.R);
                 scoresG[i] = Math.Abs(rc[i].G - c.G);
                 scoresB[i] = Math.Abs(rc[i].B - c.B);
                scoreHUE[i] = (int)Math.Abs(rc[i].GetHue() - c.GetHue());
                saturation[i] =(int)Math.Abs(rc[i].GetSaturation() - c.GetSaturation());

              //  if (scoresG[i] > 90)
              //  {
              //      scoresG[i] /= 2;
              //      scoresB[i] += scoresG[i] / 2; 
              //      scoresR[i] += scoresG[i] / 2;
              //  }
                    


                scores[i] = scoresR[i] + scoresG[i] + scoresB[i] + scoreHUE[i] + saturation[i];
            }

             if (c.G > 210)//greenbooster
             {
                 scores[10] /= 2;
                
             }

            int smallest = scores[0];
            int scnd = scores[0];
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] < smallest)
                {
                    scnd = smallest;
                    smallest = scores[i];
                }
            }
            for (int i = 0; i < scores.Length; i++)
            {
                if (smallest == scores[i])
                {
                    wc[0] = (ConsoleColor)((i + offset) % 16);
                    
                }
            }

            char[] chars = new char[] { ' ','.', ':', '-', '=', '+', '*', '#', '%','@' };
            int index = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scnd == scores[i] && Math.Abs(smallest - scnd) < 120)
                {
                    wc[1] = (ConsoleColor)((i+offset)%16);
                    if (db > 0.5)
                    {
                        index = chars.Length - 1 - Math.Abs(Math.Abs(smallest - scnd) / chars.Length - (chars.Length - 1));
                    }else
                        index = Math.Abs(Math.Abs(smallest - scnd) / chars.Length - (chars.Length - 1));

                } else if (scnd == scores[i])
                {
                    index = 0;
                    wc[1] = wc[0];
                }


            }
            
            Console.BackgroundColor = wc[0];
            Console.ForegroundColor = wc[1];
            Console.Write(chars[index]);
            

        }
    }
}