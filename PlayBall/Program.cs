using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;

namespace PlayBall
{
    class Program
    {
        private const string MAIN_MENU_OPTION_PLAY = "Play";
        private const string MAIN_MENU_OPTION_EXIT = "Exit";
        private readonly string[] MAIN_MENU_OPTIONS = { MAIN_MENU_OPTION_PLAY, MAIN_MENU_OPTION_EXIT };

        //private const string SUB_MENU_PLAY_SLOW_PITCH = "0 - 1, Slow Pitch";
        //private const string SUB_MENU_PLAY_STRAIGHT_PITCH = "2 - 3, Straight Pitch";
        //private const string SUB_MENU_PLAY_FASTBALL = "4 - 6, Fastball";
        //private const string SUB_MENU_PLAY_CURVEBALL = "7 - 9, Curveball";
        //private readonly string[] SUB_MENU_OPTIONS = { SUB_MENU_PLAY_SLOW_PITCH, SUB_MENU_PLAY_STRAIGHT_PITCH, SUB_MENU_PLAY_FASTBALL, SUB_MENU_PLAY_CURVEBALL };

        private readonly IBasicUserInterface ui = new MenuDrivenCLI();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {        
            PlayBall playball = new PlayBall(); //Not using yet
            bool exit = false;
            Console.WriteLine("Hello! Let's play some baseball!");
            Console.WriteLine("What would you like to do?");
            while (!exit) 
            {
                int hitCount = 0;
                int strikeCount = 0;
                String selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                if (selection == MAIN_MENU_OPTION_EXIT)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please enter your name:");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Please enter your jersey number:");
                    string jerseyNumber = Console.ReadLine();
                    Console.WriteLine("Introducing number " + jerseyNumber + ", " + userName.ToUpper() + "!");
                    while (strikeCount < 4 || hitCount <4)
                    {
                        PromptForPitch();
                        try
                        {
                            int pitchStyle = int.Parse(Console.ReadLine());
                            Random rand = new Random();

                            //selection = (string)ui.PromptForSelection(SUB_MENU_OPTIONS);

                            if (pitchStyle == 0 || pitchStyle == 1) //could move pitchstyle to another class(playball) to figure it out
                            {
                                int genNum = rand.Next(0, 2);
                                HitOrStrike(ref hitCount, ref strikeCount, pitchStyle, genNum);
                            }
                            else if (pitchStyle == 2 || pitchStyle == 3)
                            {
                                int genNum = rand.Next(2, 4);
                                HitOrStrike(ref hitCount, ref strikeCount, pitchStyle, genNum);
                            }
                            else if (pitchStyle == 4 || pitchStyle == 5 || pitchStyle == 6)
                            {
                                int genNum = rand.Next(4, 7);
                                HitOrStrike(ref hitCount, ref strikeCount, pitchStyle, genNum);
                            }
                            else if (pitchStyle == 7 || pitchStyle == 8 || pitchStyle == 9)
                            {
                                int genNum = rand.Next(7, 10);
                                HitOrStrike(ref hitCount, ref strikeCount, pitchStyle, genNum);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid value");
                            }
                            if (strikeCount == 3)
                            {
                                strikeCount = 0;
                                hitCount = 0;
                                Console.WriteLine("3 strikes and YOU'RE OUT! Would you like to play again?");
                                selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                                if (selection == MAIN_MENU_OPTION_EXIT)
                                {
                                    exit = true;
                                    break;
                                }
                            }
                            else if (hitCount == 3)
                            {
                                hitCount = 0;
                                strikeCount = 0;
                                Console.WriteLine("3 hits for a HOME RUN! You win! Would you like to play again?");
                                selection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);
                                if (selection == MAIN_MENU_OPTION_EXIT)
                                {
                                    exit = true;
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a valid option");
                        }
                    }
                }              
            }
        }

        private static void PromptForPitch()
        {
            Console.WriteLine("Please enter a number corresponding to your pitch choice:"); //extract these into a method to promptforpitch
            Console.WriteLine("0 - 1, Slow Pitch");
            Console.WriteLine("2 - 3, Straight Pitch");
            Console.WriteLine("4 - 6, Fastball");
            Console.WriteLine("7 - 9, Curveball");
        }

        private static void HitOrStrike(ref int hitCount,ref int strikeCount, int pitchStyle, int genNum)
        {
            if (pitchStyle != genNum)
            {
                Console.WriteLine("STRIKE!");
                strikeCount++;
            }
            else
            {
                Console.WriteLine("HIT!");
                hitCount++;
            }
        }
    }
}
