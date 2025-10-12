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

                   

                }
                //bunu ekstradan ekledim çünkü oyun bitince yeni turda duvarlar vs çizilmemiş oluyordu
                
                if (blueThrowerX > 0) { Console.SetCursorPosition(blueThrowerX, blueThrowerY); Console.Write(">"); }
                if (redThrowerX > 0) { Console.SetCursorPosition(redThrowerX, redThrowerY); Console.Write("<"); }

                if (isBlueSnowman1OntheGame) { Console.SetCursorPosition(blueSnowman1X, blueSnowman1Y); Console.Write("A"); }
                if (isBlueSnowman2OntheGame) { Console.SetCursorPosition(blueSnowman2X, blueSnowman2Y); Console.Write("B"); }
                if (isRedSnowman1OntheGame) { Console.SetCursorPosition(redSnowman1X, redSnowman1Y); Console.Write("C"); }
                if (isRedSnowman2OntheGame) { Console.SetCursorPosition(redSnowman2X, redSnowman2Y); Console.Write("D"); }

                // walls (yeniden çizmek istersen – opsiyonel, ama flicker yoksa iyi olur)
                for (int i = 0; i < lengthWall1; i++) { int wy = wall1Y + i; if (wy <= 41) { Console.SetCursorPosition(wall1X, wy); Console.Write("#"); } }
                for (int i = 0; i < lengthWall2; i++) { int wy = wall2Y + i; if (wy <= 41) { Console.SetCursorPosition(wall2X, wy); Console.Write("#"); } }


                Console.SetCursorPosition(1, 42);
                Console.WriteLine();
                Console.Write("Enter velocity (5 - 25): ");
                double velocity;
                while (!double.TryParse(Console.ReadLine(), out velocity) || velocity < 5 || velocity > 25)
                {
                    Console.Write("Invalid input. Enter velocity (5 - 25): ");
                }

                Console.Write("Enter angle (5 - 85 degrees): ");
                double angle;
                while (!double.TryParse(Console.ReadLine(), out angle) || angle < 5 || angle > 85)
                {
                    Console.Write("Invalid input. Enter angle (5 - 85): ");
                }

                
                Console.WriteLine();
                Console.WriteLine($"Round: {round + 1}");
                Console.WriteLine($"Wind: {windSpeed:F2}");
                Console.WriteLine($"Velocity: {velocity:F2}");
                Console.WriteLine($"Angle: {angle:F2}");
                Console.WriteLine("Press any key to continue..."); 
                

                // atışı kimin yaptığına karar veriyoruz burada (çift round olursa blue tek olursa red yani sırayla)
                bool blueShoots = (round % 2 == 0);
                int startX = blueShoots ? blueThrowerX : redThrowerX;
                int startY = blueShoots ? blueThrowerY : redThrowerY;

                // başlangıc icin hız bileşenleri oluşturdum
                double rad = angle * Math.PI / 180.0;
                int dir = blueShoots ? +1 : -1;           // blue sağa red sola atıyor yerlerinden dolayı
                double vx = dir * velocity * Math.Cos(rad);
                double vy = -velocity * Math.Sin(rad);   

                double g = 1.0;           
                double ax = windSpeed;    
                double dt = 0.10;         

                double x = startX;
                double y = startY;
                int maxSteps = 1000;
                bool hitSomething = false;

                // izi oluşturmak için döngü en mantıklısı geldi
                for (int step = 0; step < maxSteps; step++)
                {
                    // her döngüde bu adıma gelince sürekli yeni konum güncellenecek
                    int px = (int)Math.Round(x);
                    int py = (int)Math.Round(y);

                    if (px < 1 || px > 120 || py < 1 || py > 40) break;

                    Console.SetCursorPosition(px, py);
                    Console.Write(".");


                    // çapışmaları bu kısımda kontrol edecek

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

                    
                    if (px == blueThrowerX && py == blueThrowerY && isBlueThrowerOntheGame)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Hit: Blue Thrower (rest next turn)  ");
                        hitSomething = true;
                        break;
                    }
                    if (px == redThrowerX && py == redThrowerY && isRedThrowerOntheGame)
                    {
                        Console.SetCursorPosition(2, 4);
                        Console.Write("Hit: Red Thrower (rest next turn)   ");
                        hitSomething = true;
                        break;
                    }

                    // formülleri güncellicez
                    
                    vx += ax * dt;     
                    vy += g * dt;      

                    x += vx * dt;
                    y += vy * dt;

                  
                    System.Threading.Thread.Sleep(5);

                    // olmasa da olur ekranın dışına çıktıysa erken donsun dye hızlandırma yapıyor bu satır
                    if ((px < 1 || px > 120 || py < 1 || py > 40) && step > 10) { break; }

                }


                Console.SetCursorPosition(2, 5);
                if (hitSomething) Console.Write("Result: HIT    ");
                else Console.Write("Result: MISS   ");

                Console.SetCursorPosition(2, 6);
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
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
