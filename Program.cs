using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAB4_GROUP5_2021510130_2023510239_2023510038
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                Console.SetBufferSize(130, 48);
                Console.SetWindowSize(130, 48);
            }
            catch
            {
            }

            Console.CursorVisible = false;

            Random random = new Random();

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


            //round
            int round = 0;

            //is players on the game
            bool isBlueThrowerOntheGame = true;
            bool isRedThrowerOntheGame = true;
            bool isBlueSnowman1OntheGame = true;
            bool isBlueSnowman2OntheGame = true;
            bool isRedSnowman1OntheGame = true;
            bool isRedSnowman2OntheGame = true;

            Console.WriteLine("     SNOWBALL GAME       ");
            Console.WriteLine("Blue Team vs. Red Team");
            Console.WriteLine();
            Console.WriteLine("             MENU              ");
            Console.WriteLine("Select the mode you want to play:");
            Console.WriteLine("1) Wall lengths should change every three rounds.");
            Console.WriteLine("2) Wall lengths should remain constant throughout all rounds.");
            Console.Write("Your choice: ");
            int mode = Convert.ToInt16(Console.ReadLine());

            int lengthWall1Value = random.Next(3, 7);
            int lengthWall2Value = random.Next(3, 7);


            while ((isBlueSnowman1OntheGame || isBlueSnowman2OntheGame) && (isRedSnowman1OntheGame || isRedSnowman2OntheGame))
            {

                //frame

                Console.Clear();

                for (int i = 0; i < 41; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("                                         ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("                                        ");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("                                        ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("");
                    Console.WriteLine();
                }

                for (int a = 0; a < 122; a++)
                {
                    Console.SetCursorPosition(a, 0);
                    Console.Write("#");
                    Console.SetCursorPosition(a, 41);
                    Console.Write("#");
                }

                for (int b = 0; b < 42; b++)
                {
                    Console.SetCursorPosition(0, b);
                    Console.Write("#");
                    Console.SetCursorPosition(121, b);
                    Console.Write("#");
                }

                //wind
                double windSpeed = random.NextDouble() * 4 - 2;

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

                    switch (mode)
                    {
                        case 1:
                            //lenght of the walls
                            lengthWall1 = random.Next(3, 7);
                            lengthWall2 = random.Next(3, 7);
                            break;
                        case 2:
                            //lenght of the walls
                            lengthWall1 = lengthWall1Value;
                            lengthWall2 = lengthWall2Value;
                            break;

                    }


                }

                //bunu ekstradan ekledim çünkü oyun bitince yeni turda duvarlar vs çizilmemiş oluyordu

                if (blueThrowerX > 0)
                {
                    Console.SetCursorPosition(blueThrowerX, blueThrowerY);
                    Console.Write(">");
                }

                if (redThrowerX > 0)
                {
                    Console.SetCursorPosition(redThrowerX, redThrowerY);
                    Console.Write("<");
                }

                if (isBlueSnowman1OntheGame)
                {
                    Console.SetCursorPosition(blueSnowman1X, blueSnowman1Y);
                    Console.Write("A");
                }

                if (isBlueSnowman2OntheGame)
                {
                    Console.SetCursorPosition(blueSnowman2X, blueSnowman2Y);
                    Console.Write("B");
                }

                if (isRedSnowman1OntheGame)
                {
                    Console.SetCursorPosition(redSnowman1X, redSnowman1Y);
                    Console.Write("C");
                }

                if (isRedSnowman2OntheGame)
                {
                    Console.SetCursorPosition(redSnowman2X, redSnowman2Y);
                    Console.Write("D");
                }

                // walls (yeniden çizmek istersen – opsiyonel, ama flicker yoksa iyi olur)
                for (int i = 0; i < lengthWall1; i++)
                {
                    int wy = wall1Y + i; if (wy <= 41)
                    {
                        Console.SetCursorPosition(wall1X, wy);
                        Console.Write("#");
                    }
                }

                for (int i = 0; i < lengthWall2; i++)
                {
                    int wy = wall2Y + i;
                    if (wy <= 41)
                    {
                        Console.SetCursorPosition(wall2X, wy); Console.Write("#");
                    }
                }

                // Velocity input
                double velocity = 0;
                bool validVelocity = false;

                while (!validVelocity)
                {
                    Console.SetCursorPosition(1, 42);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(1, 42);
                    Console.Write("Enter velocity (5 - 25): ");

                    string input = Console.ReadLine();

                    try
                    {
                        velocity = Convert.ToDouble(input);
                        if (velocity >= 5 && velocity <= 25)
                        {
                            validVelocity = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(33, 42);
                            Console.Write("Invalid input! Try again...");
                            Thread.Sleep(800);
                            Console.SetCursorPosition(33, 42);
                            Console.Write(new string(' ', 50));
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(33, 42);
                        Console.Write("Invalid input! Try again...");
                        Thread.Sleep(800);
                        Console.SetCursorPosition(33, 42);
                        Console.Write(new string(' ', 50));
                    }
                }

                // Angle input
                double angle = 0;
                bool validAngle = false;

                while (!validAngle)
                {
                    Console.SetCursorPosition(1, 43);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(1, 43);
                    Console.Write("Enter Angle (-85 - 85): ");

                    try
                    {
                        angle = Convert.ToDouble(Console.ReadLine());
                        if (angle >= -85 && angle <= 85)
                        {
                            validAngle = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(33, 43);
                            Console.Write("Invalid input. Enter angle (-85 - 85):      ");
                            Thread.Sleep(800);
                            Console.SetCursorPosition(33, 43);
                            Console.Write(new string(' ', 50));
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(33, 43);
                        Console.Write("Invalid input. Enter angle (-85 - 85):      ");
                        Thread.Sleep(800);
                        Console.SetCursorPosition(33, 43);
                        Console.Write(new string(' ', 50));
                    }
                }

                Console.SetCursorPosition(124, 1);
                Console.Write("Round: " + (round + 1) + "   ");
                Console.SetCursorPosition(124, 2);
                Console.Write("Wind: " + windSpeed.ToString("0.00") + "   ");
                Console.SetCursorPosition(124, 3);
                Console.Write("Velocity: " + velocity + "   ");
                Console.SetCursorPosition(124, 4);
                Console.Write("Angle: " + angle + "   ");
                Console.SetCursorPosition(124, 5);
                Console.Write("Turn: " + "blue" + "   ");
                Console.SetCursorPosition(124, 6);
                Console.Write("Press any key to continue...");


                // atışı kimin yaptığına karar veriyoruz burada (çift round olursa blue tek olursa red yani sırayla)
                bool blueShoots = true;
                int startX;
                int startY;

                if (blueShoots)
                {
                    startX = blueThrowerX;
                    startY = blueThrowerY;
                }
                else
                {
                    startX = redThrowerX;
                    startY = redThrowerY;
                }

                // başlangıc icin hız bileşenleri oluşturdum
                double rad = angle * Math.PI / 180.0;
                double vx = velocity * Math.Cos(rad);
                double vy = -velocity * Math.Sin(rad);

                double g = 1.0;
                double ax = windSpeed;
                double dt = Math.Max(0.02, 0.10 - (velocity / 250));

                double x = startX + 1;
                double y = startY;
                int maxSteps = 1000;
                bool hitSomething = false;

                // sıradaki oyuncu atışı
                for (int step = 0; step < maxSteps; step++)
                {
                    if (step == 0)
                    {
                        x += vx * dt;
                        y += vy * dt;
                    }

                    int px = (int)Math.Round(x);
                    int py = (int)Math.Round(y);

                    if (px < 1 || px > 120 || py < 1 || py > 40)
                    {
                        break;
                    }

                    Console.SetCursorPosition(px, py);
                    Console.Write("o");

                    bool hitWall =
                        (px == wall1X && py >= wall1Y && py < wall1Y + lengthWall1) ||
                        (px == wall2X && py >= wall2Y && py < wall2Y + lengthWall2);

                    if (hitWall)
                    {
                        Console.SetCursorPosition(2, 2);
                        Console.Write("Hit: Wall   ");
                        hitSomething = true;
                        break;
                    }

                    if (px == blueSnowman1X && py == blueSnowman1Y && isBlueSnowman1OntheGame)
                    {
                        isBlueSnowman1OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Blue A ");
                        hitSomething = true;
                        break;
                    }
                    if (px == blueSnowman2X && py == blueSnowman2Y && isBlueSnowman2OntheGame)
                    {
                        isBlueSnowman2OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Blue B ");
                        hitSomething = true;
                        break;
                    }
                    if (px == redSnowman1X && py == redSnowman1Y && isRedSnowman1OntheGame)
                    {
                        isRedSnowman1OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Red C  ");
                        hitSomething = true;
                        break;
                    }
                    if (px == redSnowman2X && py == redSnowman2Y && isRedSnowman2OntheGame)
                    {
                        isRedSnowman2OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Red D  ");
                        hitSomething = true;
                        break;
                    }

                    if (step > 0 && px == blueThrowerX && py == blueThrowerY && isBlueThrowerOntheGame)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Hit: Blue Thrower (rest next turn)  ");
                        hitSomething = true;
                        break;
                    }
                    if (step > 0 && px == redThrowerX && py == redThrowerY && isRedThrowerOntheGame)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Hit: Red Thrower (rest next turn)   ");
                        hitSomething = true;
                        break;
                    }

                    vx += ax * dt;
                    vy += g * dt;

                    x += vx * dt;
                    y += vy * dt;

                    System.Threading.Thread.Sleep(15); // 1 yerine biraz yavaş

                }

                // --- RED SHOT DONE: show trace until a key is pressed ---
                Console.SetCursorPosition(124, 16);
                Console.Write("Blue shot done. Press any key...");
                Console.ReadKey(true);   // kullanıcı bastığında sonraki round’a geçer

                // === CLEAR TRACE BEFORE RED TURN ===
                // Mavi atışın izini temizle ve aynı round'un yerleşimiyle sahneyi yeniden çiz
                Console.Clear();

                // 1) Zemin bantları
                for (int i = 0; i < 41; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Blue; Console.Write("                                         ");
                    Console.BackgroundColor = ConsoleColor.White; Console.Write("                                        ");
                    Console.BackgroundColor = ConsoleColor.Red; Console.Write("                                        ");
                    Console.BackgroundColor = ConsoleColor.Black; Console.Write("");
                    Console.WriteLine();
                }

                // 2) Kenarlıklar
                for (int a = 0; a < 122; a++)
                {
                    Console.SetCursorPosition(a, 0); Console.Write("#");
                    Console.SetCursorPosition(a, 41); Console.Write("#");
                }
                for (int b = 0; b < 42; b++)
                {
                    Console.SetCursorPosition(0, b); Console.Write("#");
                    Console.SetCursorPosition(121, b); Console.Write("#");
                }

                // 3) Oyuncular (varsa)
                if (blueThrowerX > 0) { Console.SetCursorPosition(blueThrowerX, blueThrowerY); Console.Write(">"); }
                if (redThrowerX > 0) { Console.SetCursorPosition(redThrowerX, redThrowerY); Console.Write("<"); }

                if (isBlueSnowman1OntheGame) { Console.SetCursorPosition(blueSnowman1X, blueSnowman1Y); Console.Write("A"); }
                if (isBlueSnowman2OntheGame) { Console.SetCursorPosition(blueSnowman2X, blueSnowman2Y); Console.Write("B"); }
                if (isRedSnowman1OntheGame) { Console.SetCursorPosition(redSnowman1X, redSnowman1Y); Console.Write("C"); }
                if (isRedSnowman2OntheGame) { Console.SetCursorPosition(redSnowman2X, redSnowman2Y); Console.Write("D"); }

                // 4) Duvarlar
                for (int i = 0; i < lengthWall1; i++) { int wy = wall1Y + i; if (wy <= 41) { Console.SetCursorPosition(wall1X, wy); Console.Write("#"); } }
                for (int i = 0; i < lengthWall2; i++) { int wy = wall2Y + i; if (wy <= 41) { Console.SetCursorPosition(wall2X, wy); Console.Write("#"); } }

                // 5) Sağ üst bilgilendirme (aynı round & rüzgâr)
                Console.SetCursorPosition(124, 1); Console.Write("Round: " + (round + 1) + "   ");
                Console.SetCursorPosition(124, 2); Console.Write("Wind: " + windSpeed.ToString("0.00") + "   ");
                Console.SetCursorPosition(124, 3); Console.Write("Turn: red   ");

                round++;


                // Velocity (Red thrower)
                double velocity2 = 0;
                bool validVelocity2 = false;

                while (!validVelocity2)
                {
                    Console.SetCursorPosition(1, 44);
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(1, 44);
                    Console.Write("Enter velocity (5 - 25): ");

                    try
                    {
                        velocity2 = Convert.ToDouble(Console.ReadLine());
                        if (velocity2 >= 5 && velocity2 <= 25)
                        {
                            validVelocity2 = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(33, 44);
                            Console.Write("Invalid input! Try again...");
                            Thread.Sleep(800);
                            Console.SetCursorPosition(33, 44);
                            Console.Write(new string(' ', 50));
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(33, 44);
                        Console.Write("Invalid input! Try again...");
                        Thread.Sleep(800);
                        Console.SetCursorPosition(33, 44);
                        Console.Write(new string(' ', 50));
                    }
                }

                // Angle (Red thrower)
                double angle2 = 0;
                bool validAngle2 = false;

                while (!validAngle2)
                {
                    // RED input
                    Console.SetCursorPosition(1, 44);  
                    Console.Write(new string(' ', 60));
                    Console.SetCursorPosition(1, 44);
                    Console.Write("Enter Angle (-85 - 85): ");

                    Console.SetCursorPosition(33, 44); 


                    try
                    {
                        angle2 = Convert.ToDouble(Console.ReadLine());
                        if (angle2 >= -85 && angle2 <= 85)
                        {
                            validAngle2 = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(33, 45);
                            Console.Write("Invalid input. Enter angle (-85 - 85):      ");
                            Thread.Sleep(800);
                            Console.SetCursorPosition(33, 45);
                            Console.Write(new string(' ', 50));
                        }
                    }
                    catch
                    {
                        Console.SetCursorPosition(33, 45);
                        Console.Write("Invalid input. Enter angle (-85 - 85):      ");
                        Thread.Sleep(800);
                        Console.SetCursorPosition(33, 45);
                        Console.Write(new string(' ', 50));
                    }
                }

                // Info (top-right)
                Console.SetCursorPosition(124, 10);
                Console.Write("Round: " + (round) + "   ");
                Console.SetCursorPosition(124, 11);
                Console.Write("Wind: " + windSpeed.ToString("0.00") + "   ");
                Console.SetCursorPosition(124, 12);
                Console.Write("Velocity: " + velocity2 + "   ");
                Console.SetCursorPosition(124, 13);
                Console.Write("Angle: " + angle2 + "   ");
                Console.SetCursorPosition(124, 14);
                Console.Write("Turn: " + "red" + "   ");
                Console.SetCursorPosition(124, 15);
                Console.Write("Press any key to continue...");

                double rad2 = angle2 * Math.PI / 180.0;
                double vx2 = -1 * velocity2 * Math.Cos(rad2); // sağdaki sola atar
                double vy2 = -velocity2 * Math.Sin(rad2);

                double x2 = redThrowerX - 1;
                double y2 = redThrowerY;
                bool hitSomething2 = false;

                for (int step = 0; step < maxSteps; step++)
                {
                    if (step == 0)
                    {
                        x2 += vx2 * dt;
                        y2 += vy2 * dt;
                    }

                    int px2 = (int)Math.Round(x2);
                    int py2 = (int)Math.Round(y2);

                    if (px2 < 1 || px2 > 120 || py2 < 1 || py2 > 40) break;

                    Console.SetCursorPosition(px2, py2);
                    Console.Write("o");

                    bool hitWall2 =
                        (px2 == wall1X && py2 >= wall1Y && py2 < wall1Y + lengthWall1) ||
                        (px2 == wall2X && py2 >= wall2Y && py2 < wall2Y + lengthWall2);

                    if (hitWall2)
                    {
                        Console.SetCursorPosition(2, 2);
                        Console.Write("Hit: Wall   ");
                        hitSomething2 = true;
                        break;
                    }

                    if (px2 == blueSnowman1X && py2 == blueSnowman1Y && isBlueSnowman1OntheGame)
                    {
                        isBlueSnowman1OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Blue A ");
                        hitSomething2 = true;
                        break;
                    }
                    if (px2 == blueSnowman2X && py2 == blueSnowman2Y && isBlueSnowman2OntheGame)
                    {
                        isBlueSnowman2OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Blue B ");
                        hitSomething2 = true;
                        break;
                    }
                    if (px2 == redSnowman1X && py2 == redSnowman1Y && isRedSnowman1OntheGame)
                    {
                        isRedSnowman1OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Red C  ");
                        hitSomething2 = true;
                        break;
                    }
                    if (px2 == redSnowman2X && py2 == redSnowman2Y && isRedSnowman2OntheGame)
                    {
                        isRedSnowman2OntheGame = false;
                        Console.SetCursorPosition(2, 3);
                        Console.Write("Hit: Red D  ");
                        hitSomething2 = true;
                        break;
                    }

                    if (step > 0 && px2 == blueThrowerX && py2 == blueThrowerY && isBlueThrowerOntheGame)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Hit: Blue Thrower (rest next turn)  ");
                        hitSomething2 = true;
                        break;
                    }
                    if (step > 0 && px2 == redThrowerX && py2 == redThrowerY && isRedThrowerOntheGame)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Hit: Red Thrower (rest next turn)   ");
                        hitSomething2 = true;
                        break;
                    }

                    vx2 += ax * dt;
                    vy2 += g * dt;

                    x2 += vx2 * dt;
                    y2 += vy2 * dt;

                    System.Threading.Thread.Sleep(1);

                }


                Console.ReadLine();
            }
        }
    }
}