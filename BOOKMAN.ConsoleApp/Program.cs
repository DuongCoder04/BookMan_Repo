﻿using BOOKMAN.ConsoleApp.Framework;
using System;

namespace BOOKMAN.ConsoleApp
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var text = Config.Instance.PromptText;
            var color = Config.Instance.PromptColor;

            ConfigRouter();
            while (true)
            {
                ViewHelp.Write(text, color);
                string request = Console.ReadLine();
                try
                {
                    Router.Instance.Forward(request);
                }
                catch (Exception ex)
                {
                    ViewHelp.WriteLine(ex.Message, ConsoleColor.Red);
                }
                finally
                {
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }                   
        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("SUPPORTED COMMANDS:", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("type: help ? cmd= <command> to get command details", ConsoleColor.Cyan);
                return;
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var conmand = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(conmand));
        }

        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("BOOK MANAGER v1.0", ConsoleColor.Green);
            ViewHelp.WriteLine("by duong192k4@gmail.com", ConsoleColor.Magenta);
        }

     }

}
