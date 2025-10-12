using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL1_SnowballGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Çerçevi çizerken zorlandım. Console.SetCursorPosition kullandım. Çünkü öteki türlü duvarlar eksik kalıyordu ve oyuncular dışarı çıkıyordu. Console.SetCursorPositionda ise
             * oyun alanı konsoldan daha büyük olduğundan hata veriyordu. O yüzden bu kodları ekledim. Hocaya kullanıp kullanamayacağımızı sorabiliriz. Kodu bu haliyle atıyorum.
             * Koda opsiyonel olarak extra ekleme yaparım. Mesela duvar boyutu sürekli değişsin mi değişmesin mi diye kullanıcı mod sorup ona göre seçenek sunmak gibi. SetCursorPositiondan
             * sonra mavi-nötr-kırmızı alan ayrımını yazdıramadım. Renk olarak araştıracağım.
             */

            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                Console.SetWindowSize(130, 45);
                Console.SetBufferSize(130, 45);
            }
            catch
            {
            }


            Random random = new Random();

            //round
            int round = 0;

            /*Is players on the game*/
            bool isBlueThrowerOntheGame = true;
            bool isRedThrowerOntheGame = true;
            bool isBlueSnowman1OntheGame = true;
            bool isBlueSnowman2OntheGame = true;
            bool isRedSnowman1OntheGame = true;
            bool isRedSnowman2OntheGame = true;

            while ((isBlueSnowman1OntheGame || isBlueSnowman2OntheGame) && (isRedSnowman1OntheGame || isRedSnowman2OntheGame))
            {

                //frame
                Console.Clear();
                /*for (int starRow = 0; starRow < 42; starRow++)
                {
                    for (int starColumn = 0; starColumn < 122; starColumn++)
                    {
                        if (starRow == 0 || starRow == 41 || starColumn == 0 || starColumn == 121)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                */

                for (int x = 0; x < 122; x++)
                {
                    Console.SetCursorPosition(x, 0);
                    Console.Write("#");
                    Console.SetCursorPosition(x, 41);
                    Console.Write("#");
                }

                for (int y = 0; y < 42; y++)
                {
                    Console.SetCursorPosition(0, y);
                    Console.Write("#");
                    Console.SetCursorPosition(121, y);
                    Console.Write("#");
                }

                /*//zones
                for (int starColumn = 0; starColumn < 121; starColumn++)
                {
                    if (starColumn == 40)
                    {
                        Console.Write("B");
                    }
                    else if (starColumn == 41 || starColumn == 81)
                    {
                        Console.Write("|");
                    }
                    else if (starColumn == 42 || starColumn == 80)
                    {
                        Console.Write("N");
                    }
                    else if (starColumn == 82)
                    {
                        Console.Write("R");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();*/

                //wind
                double windSpeed = random.NextDouble() * 4 - 2;

                //x coordinates of players and walls
                int blueThrowerX = 0;
                int blueThrowerY = 0;
                int redThrowerX = 0;
                int redThrowerY = 0;
                int blueSnowman1X = 0;
                int blueSnowman1Y = 0;
                int blueSnowman2X = 0;
                int blueSnowman2Y = 0;
                int redSnowman1X = 0;
                int redSnowman1Y = 0;
                int redSnowman2X = 0;
                int redSnowman2Y = 0;
                int wall1X = 0;
                int wall1Y = 0;
                int wall2X = 0;
                int wall2Y = 0;

                int lengthWall1 = 0;
                int lengthWall2 = 0;

                if (round % 3 == 0)
                {
                    //x coordinates of players and walls
                    blueThrowerX = random.Next(1, 40);
                    redThrowerX = random.Next(81, 120);
                    blueSnowman1X = random.Next(1, 40);
                    blueSnowman2X = random.Next(1, 40);
                    redSnowman1X = random.Next(81, 120);
                    redSnowman2X = random.Next(81, 120);
                    wall1X = random.Next(41, 80);
                    wall2X = random.Next(41, 80);

                    //y coordinates of players and walls
                    blueThrowerY = random.Next(1, 40);
                    redThrowerY = random.Next(1, 40);
                    blueSnowman1Y = random.Next(1, 40);
                    blueSnowman2Y = random.Next(1, 40);
                    redSnowman1Y = random.Next(1, 40);
                    redSnowman2Y = random.Next(1, 40);
                    wall1Y = random.Next(1, 40);
                    wall2Y = random.Next(1, 40);

                    //lenght of the walls
                    lengthWall1 = random.Next(3, 7);
                    lengthWall2 = random.Next(3, 7);

                    //adding players and walls on the screen
                    Console.SetCursorPosition(blueThrowerX, blueThrowerY);
                    Console.Write(">");
                    Console.SetCursorPosition(redThrowerX, redThrowerY);
                    Console.Write("<");
                    Console.SetCursorPosition(blueSnowman1X, blueSnowman1Y);
                    Console.Write("A");
                    Console.SetCursorPosition(blueSnowman2X, blueSnowman2Y);
                    Console.Write("B");
                    Console.SetCursorPosition(redSnowman1X, redSnowman1Y);
                    Console.Write("C");
                    Console.SetCursorPosition(redSnowman2X, redSnowman2Y);
                    Console.Write("D");

                    for (int i = 0; i < lengthWall1; i++)
                    {
                        Console.SetCursorPosition(wall1X, wall1Y++);
                        Console.Write("#");
                    }

                    for (int i = 0; i < lengthWall2; i++)
                    {
                        Console.SetCursorPosition(wall2X, wall2Y++);
                        Console.Write("#");
                    }

                }

                Console.SetCursorPosition(1, 42);
                Console.ReadKey(true);

                round++;

                /* ()
                {
                    isBlueThrowerOntheGame = false;
                    isRedThrowerOntheGame = false;
                    isBlueSnowman1OntheGame = false;
                    isBlueSnowman2OntheGame = false;
                    isRedSnowman1OntheGame = false;
                    isRedSnowman2OntheGame = false;
                }    //if it disappears */

                if (!(isBlueSnowman1OntheGame || isBlueSnowman2OntheGame))
                {
                    Console.WriteLine("The winner: red team");
                }

                if (!(isRedSnowman1OntheGame || isRedSnowman2OntheGame))
                {
                    Console.WriteLine("The winner: blue team");
                }


            }

            Console.ReadLine();
        }
    }
}
