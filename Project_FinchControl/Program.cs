using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch
    // Description:My Finch
    // Application Type: Console
    // Author: Alexander Vigil
    // Dated Created: 6/4/2021
    // Last Modified: 7/4/2021
    //
    // **************************************************
    public enum Commands
        {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNLEFT, 
        TURNRIGHT,
        LEDON,
        LEDOFF,
        GETTEMPERARTURE,
        DONE
        }


    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayReadAndSetTheme(); 
            DisplaySetNewTheme(); 
            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }


        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecordingScreen(finchRobot);
                        break;

                    case "d":
                        AlarmSystemMenu(finchRobot);
                        break;

                    case "e":
                        DisplayUserControlMenu(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region Talent Show

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) SongBird (Finch Orfginal Song");
                Console.WriteLine("\tb) The Avian Waltz (Finch Original Dance");
                Console.WriteLine("\tc) The Full performance");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":

                        DisplayDanceMenu(finchRobot);
                        break;

                    case "c":

                        DisplayFullPerformanceMenu(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");

            DisplayContinuePrompt();

            //Copy/Pasted into it's own method to be called on again later too.

            PlaySongBird(finchRobot);

            DisplayContinuePrompt();

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void PlaySongBird(Finch finchRobot)
        {
            //Quick little song with some lyrics written to it. Going to try and math up the dance with it...
            Console.WriteLine("Now we sing....");
            finchRobot.noteOn(880);
            finchRobot.setLED(100, 0, 100);
            Console.WriteLine("The world isn't always as beautiful as we like it to be");
            finchRobot.wait(1000);
            finchRobot.noteOn(988);
            Console.WriteLine("However there is always beauty in this world");
            finchRobot.setLED(0, 100, 100);
            finchRobot.noteOn(1047);
            finchRobot.wait(1000);
            finchRobot.setLED(100, 0, 100);
            Console.WriteLine("Let it unravel before your eyes...");
            Console.WriteLine("At the sound of your voice...");
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.setLED(255, 0, 0);
            Console.WriteLine("And to the beat of your pulse...");
            finchRobot.noteOn(698);
            finchRobot.wait(500);
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            Console.WriteLine("May your rhythm be felt and your song heard...");
            finchRobot.noteOn(587);
            finchRobot.wait(4000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
        }

        static void PlayAvianDance(Finch finchRobot)
        {
            //We'll copy/paste the wait times from the PlaySongBird method...
            //And now we have our rhythm...
            finchRobot.setMotors(-255, 100);
            finchRobot.wait(1000);
            finchRobot.setMotors(100, -255);
            finchRobot.wait(1000);
            finchRobot.setMotors(50, -127); //Half speed to math the 8th notes
            finchRobot.wait(500);
            finchRobot.setMotors(-127, 50);
            finchRobot.wait(500);
            finchRobot.setMotors(50, 50);
            finchRobot.wait(500);
            finchRobot.setMotors(-100, -100);
            finchRobot.wait(1333); //Divide the whole note by 3 (4000/3=1333)
            finchRobot.setMotors(-100, -50); //We are going to make him swerve but be able to keep in time with the music.
            finchRobot.wait(333); //Divide that by 4 (1333/4=333)
            finchRobot.setMotors(-50, -100); //multiply that by 2 to make him swerve (333*2=666)
            finchRobot.wait(666);
            finchRobot.setMotors(-100, -50);
            finchRobot.wait(333);
            finchRobot.setMotors(-100, 100);
            finchRobot.wait(1335);
            //Consulting calculator... The last note held for 4000 ms so 1,333 + 333 + 666 + 333 + 1,333 = 3,998
            finchRobot.setMotors(0, 0);
        }

        static void PlayFullPerformance(Finch finchRobot) //Copy/Pasted code, but going to have to do some shuffling to make them run simulaneously.
        {
            Console.WriteLine("Now we sing....");
            Console.WriteLine("The world isn't always as beautiful as we like it to be");
            Console.WriteLine("However there is always beauty in this world");
            Console.WriteLine("Let it unravel before your eyes...");
            Console.WriteLine("At the sound of your voice...");
            Console.WriteLine("And to the beat of your pulse...");
            Console.WriteLine("May your rhythm be felt and your song heard...");

            finchRobot.noteOn(880);
            finchRobot.setLED(100, 0, 100);
            finchRobot.setMotors(-255, 100);
            finchRobot.wait(1000);

            finchRobot.noteOn(988);
            finchRobot.setLED(0, 100, 100);
            finchRobot.noteOn(1047);
            finchRobot.setMotors(100, -255);
            finchRobot.wait(1000);


            finchRobot.setLED(100, 0, 100);
            finchRobot.noteOn(587);
            finchRobot.setMotors(50, -127);
            finchRobot.wait(500);


            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(698);
            finchRobot.setMotors(-127, 50);
            finchRobot.wait(500);

            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(587);
            finchRobot.setMotors(50, 50);
            finchRobot.wait(500);

            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(587);
            finchRobot.setMotors(-100, -100);
            finchRobot.wait(1333);
            finchRobot.setMotors(-100, -50);
            finchRobot.wait(333);
            finchRobot.setMotors(-50, -100);
            finchRobot.wait(666);
            finchRobot.setMotors(-100, -50);
            finchRobot.wait(333);
            finchRobot.setMotors(-100, 100);
            finchRobot.wait(1335);
            finchRobot.setMotors(0, 0);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);



        }

        static void DisplayDanceMenu(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("The Avian Waltz");

            Console.WriteLine("Let's Dance!");
            Console.WriteLine("Please, make sure I've got plkenty of airspace!");

            DisplayContinuePrompt();

            PlayAvianDance(finchRobot);

            DisplayContinuePrompt();

            DisplayMenuPrompt("Talent Show Menu");

        }

        static void DisplayFullPerformanceMenu(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("The Full Performance");

            DisplayContinuePrompt();

            PlayFullPerformance(finchRobot);

            DisplayMenuPrompt("Talent Show Menu");

        }

        #endregion

        #region DATA RECORDING 

        static void DataRecordingScreen(Finch finchRobot)
        {
            int numberOfData = 0;
            double freqOfData = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recording Menu");
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfData = DataPointsMenu(finchRobot);
                        break;

                    case "b":
                        freqOfData = DataFrequencyMenu(finchRobot);
                        break;

                    case "c":
                        temperatures = GetDataMenu(numberOfData, freqOfData, finchRobot);
                        break;

                    case "d":
                        do
                        {
                            DisplayScreenHeader("\tOoops...");
                            Console.WriteLine("\tThere is no data to display...");
                            DisplayContinuePrompt();
                        } while (temperatures.Length == 0);
                        ShowDataMenu(temperatures);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitMenu);


        }

        static void ShowDataMenu(double[] temperatures)
        {
            double sum = 0;
            double average = 0;

            DisplayScreenHeader("Show Data");

            //
            //Display Header
            //
            Console.WriteLine(
                "Recording #".PadLeft(24) +
                "Temp".PadLeft(24)
                );
            Console.WriteLine(
                "...........".PadLeft(24) +
                "...........".PadLeft(24)
                );

            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine(
                    (i + 1).ToString().PadLeft(24) +
                    temperatures[i].ToString("n2").PadLeft(24)
                    );
                sum += temperatures[i];
            }
            average = sum / temperatures.Length;

            Console.WriteLine("The Average Room Temperature was: " + average + "C ");

            DisplayContinuePrompt();
        }

        static double[] GetDataMenu(int numberOfData, double freqOfData, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfData];

            DisplayScreenHeader("Get Data");

            Console.WriteLine("Data Points: {0}", numberOfData);
            Console.WriteLine("Frequency: {0}", freqOfData);
            Console.WriteLine();
            Console.WriteLine("We will now gather the temperature...");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfData; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index}: {temperatures[index]}");
                int waitInSeconds = (int)(freqOfData * 1000);
                finchRobot.wait(waitInSeconds);
            }

            DisplayContinuePrompt();
            return temperatures;
        }

        static int DataPointsMenu(Finch finchRobot)
        {
            int numberOfData;

            DisplayScreenHeader("\tData Points");
            Console.WriteLine("\tEnter number of data points:");

            //Validate User Input using nested do while.
            int.TryParse(Console.ReadLine(), out numberOfData);
            if (numberOfData <= 0)
            {
                do
                {
                    Console.WriteLine("Please enter a valid integer...");
                    int.TryParse(Console.ReadLine(), out numberOfData);
                } while (numberOfData <= 0);
            }
            Console.WriteLine("You entered: {0}", numberOfData);
            DisplayContinuePrompt();
            return numberOfData;
        }

        static double DataFrequencyMenu(Finch finchRobot)
        {
            double freqOfData;

            DisplayScreenHeader("\tData Frequency");
            Console.WriteLine("Enter frequency of data points:");


            // Validate user input using nested do 
            double.TryParse(Console.ReadLine(), out freqOfData);

            if (freqOfData <= 0)
            {
                do
                {
                    Console.WriteLine("Please enter a valid number...");
                    double.TryParse(Console.ReadLine(), out freqOfData);
                } while (freqOfData <= 0);
            }

            Console.WriteLine("You entered: {0}", freqOfData);
            DisplayContinuePrompt();
            return freqOfData;
        }
        #endregion

        #region ALARM SYSTEM

        static void AlarmSystemMenu(Finch finchRobot)
        {


            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string senorToMonitor = "";
            string rangeType = "";
            int minMaxThreshhold = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Alarm Systen Menu");
                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Min/Max");
                Console.WriteLine("\td) Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        senorToMonitor = SensorToMonitorMenu(); 
                        break;

                    case "b":
                        rangeType = AlarmRangeType();
                        break;

                    case "c":
                        minMaxThreshhold = AlarmThresholdMenu(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = TimeToMonitorMenu(); 
                        break;

                    case "e":
                        SetAlarm(finchRobot, senorToMonitor, rangeType, minMaxThreshhold, timeToMonitor);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitMenu);

             
        }

        private static void SetAlarm(Finch finchRobot,
            string senorToMonitor,
            string rangeType,
            int minMaxThreshhold,
            int timeToMonitor)
        {
            int currentSensorValue = 0;
            int secondsElapsed = 0;
            bool threshholdPassed = false;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to Monitor: {senorToMonitor}");
            Console.WriteLine($"\tRange Type: {rangeType}");
            Console.WriteLine($"\t{rangeType} Threshhold: {minMaxThreshhold}");
            Console.WriteLine($"\tTime to Monitor: {timeToMonitor}");

            while ((secondsElapsed < timeToMonitor) && !threshholdPassed)
            {
                switch (senorToMonitor)
                {
                    case "LEFT":
                        currentSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "RIGHT":
                        currentSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "BOTH":
                        currentSensorValue = finchRobot.getRightLightSensor()
                            + finchRobot.getRightLightSensor() / 2;
                        break;

                }
                switch (rangeType)
                {

                    case "MINIMUM":
                        if (currentSensorValue < minMaxThreshhold)
                        {
                            threshholdPassed = true;
                        }
                        break;

                    case "MAXIMUM":
                        if (currentSensorValue > minMaxThreshhold) 
                        {
                            threshholdPassed = true;
                        }
                        break;
                }
                finchRobot.wait(1000);
                secondsElapsed++;
            }

            if (threshholdPassed)
            {
                Console.WriteLine($"\t{rangeType} threshhold was exceeded.");
            }

            else
            {
                Console.WriteLine($"\tThe {rangeType} vale of {minMaxThreshhold} was not exceeded...");
            }

            Console.WriteLine($"\tLeft Sensor ambient value: {finchRobot.getLeftLightSensor()} ");
            Console.WriteLine($"\tRight Sensor ambient value: {finchRobot.getRightLightSensor()} ");

            DisplayMenuPrompt("Alarm System");

        }

        private static int TimeToMonitorMenu()
        {
            int timeToMonitor;

            DisplayScreenHeader("Time To Monitor");

            do
            {
                Console.Write("\tEnter Time To Monitor: ");
                int.TryParse(Console.ReadLine(), out timeToMonitor);

                if(timeToMonitor == 0)
                {
                    Console.WriteLine("\tPlease enter a valid integer...");   
                }
            } while (timeToMonitor == 0);

            Console.WriteLine($"\tYou Entered: {timeToMonitor}");

            DisplayMenuPrompt("Set Alarm");

            return timeToMonitor;
        }

        private static int AlarmThresholdMenu(string rangeType, Finch finchRobot)
        {
            int minMaxThreshhold;

            DisplayScreenHeader("Alarm Threshold");

            Console.WriteLine($"\tLeft Sensor ambient value: {finchRobot.getLeftLightSensor()} ");
            Console.WriteLine($"\tRight Sensor ambient value: {finchRobot.getRightLightSensor()} ");
            Console.WriteLine();

            do
            {
                Console.Write($"\tEnter {rangeType} sensor value: ");
                int.TryParse(Console.ReadLine(), out minMaxThreshhold);

                if(minMaxThreshhold ==0)
                {
                    Console.WriteLine("\tPlease enter a valid integer...");
                }

            } while (minMaxThreshhold == 0);

            Console.WriteLine($"\tYou endered: {minMaxThreshhold}");

            DisplayMenuPrompt("Alarm System");

            return minMaxThreshhold;
        }

        private static string AlarmRangeType()
        {
            string rangeType = null;
            bool validRessponse = false;

            DisplayScreenHeader("\tSet Range Type");
           
            while (!validRessponse)
            {
                Console.WriteLine("\tWhich Range Type will our alarm be monitoring for? (Minimum or Maximum)");
                rangeType = Console.ReadLine().ToUpper();

                switch(rangeType)
                {
                    case "MINIMUM":
                        validRessponse = true;
                        break;

                    case "MAXIMUM":
                        validRessponse = true;
                        break;

                    default:
                        Console.WriteLine("\tPlease enter a valid response...");
                        break;


                }
            }

            Console.WriteLine($"\tOur Finch Robot will alarm if a {rangeType} value is suprassed.");

            DisplayMenuPrompt("Alarm System");

            return rangeType;

        }

        private static string SensorToMonitorMenu()
        {
            string sensorsToMonitor = null;
            bool validResponse = false;

            DisplayScreenHeader("\tSensors to Monitors");

            while (!validResponse)
            {
                Console.WriteLine("\tWhich sensor(s) will we be using? (Left, Right, or Both)");
                sensorsToMonitor = Console.ReadLine().ToUpper();
                
                switch(sensorsToMonitor)
                {
                    case "LEFT":
                        Console.WriteLine("\tWe will be using the finch's Left sensor");
                        validResponse = true;
                        break;

                    case "RIGHT":
                        Console.WriteLine("\tWe will be using the finch's Right sensor");
                        validResponse = true;
                        break;

                    case "BOTH":
                        Console.WriteLine("\tWe will be using both the finch's sensors");
                        validResponse = true;
                        break;

                    default:
                        Console.WriteLine("\tPlease enter a valid response...");
                        break;

                }
            }
            DisplayMenuPrompt("Alarm System");

            return sensorsToMonitor;

            
        }

        #endregion

        #region USER CONTROL
        static void DisplayUserControlMenu(Finch finchRobot)
        {
            Console.CursorVisible = true;

            List<Commands> commands = new List<Commands>();

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            bool quitControlMenu = false;
            string menuChoice;


            do
            {
                DisplayScreenHeader("User Control Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Return to main menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayCommands(commands);
                        break;

                    case "d":
                        userProgrammingDisplayExecuteCommands(finchRobot, commands, commandParameters);
                        break;

                    case "q":
                        quitControlMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitControlMenu);
        }

        private static void userProgrammingDisplayExecuteCommands(
            Finch finchRobot, List<Commands> 
            commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorspeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            double waitSeconds = commandParameters.waitSeconds;
            int milliSeconds = (int)(commandParameters.waitSeconds * 1000);
            
            const int TURNING_SPEED = 120;
           
            DisplayScreenHeader("Execute Finch Commands");

            Console.WriteLine("\tWe are ready to take flight!");
            DisplayContinuePrompt();

            foreach(Commands command in commands)
            {
                switch(command)
                {
                    case Commands.NONE:
                        break;

                    case Commands.MOVEBACKWARD:
                        finchRobot.setMotors(-motorspeed, -motorspeed);
                        Console.WriteLine("Moving Backwards");
                        break;

                    case Commands.MOVEFORWARD:
                        finchRobot.setMotors(motorspeed, motorspeed);
                        Console.WriteLine("Moving Forwards");
                        break;

                    case Commands.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        Console.WriteLine("HALT!");
                        break;

                    case Commands.TURNLEFT:
                        finchRobot.setMotors(0, TURNING_SPEED);
                        Console.WriteLine("Turning to the left");
                        break;

                    case Commands.TURNRIGHT:
                        finchRobot.setMotors(TURNING_SPEED, 0);
                        Console.WriteLine("Turning to the right!");
                        break;

                    case Commands.LEDON:
                        finchRobot.setLED(0, 255, 0);
                        Console.WriteLine("Glowing!");
                        break;

                    case Commands.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        Console.WriteLine("Lights Out!");
                        break;

                    case Commands.GETTEMPERARTURE:
                        Console.WriteLine($"{finchRobot.getTemperature().ToString()} Degrees Celcius");
                        break;

                    case Commands.WAIT:
                        finchRobot.wait(milliSeconds);
                        Console.WriteLine("Standby...");
                        break;

                    case Commands.DONE:
                        Console.WriteLine("All commands have been completed...");
                        break;

                    default:
                        break;
                }
            }
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);
            DisplayMenuPrompt("User Programming");
        }   

        private static void UserProgrammingDisplayCommands(List<Commands> commands)
        {
            DisplayScreenHeader("Finch Commands");

            foreach(Commands command in commands)
            {
                Console.WriteLine($"\t{command}");
            }
            DisplayMenuPrompt("User Control Menu");
        }

        private static void UserProgrammingDisplayGetCommands(List<Commands> commands)
        {
            DisplayScreenHeader("Add Commands");

            Commands command = Commands.NONE;

            Console.WriteLine("\t Please Enter one of the following commands:");
            Console.WriteLine();
            Console.WriteLine("MOVEFORWARD");
            Console.WriteLine("MOVEBACKWARD");
            Console.WriteLine("STOPMOTORS");
            Console.WriteLine("WAIT");
            Console.WriteLine("TURNLEFT");
            Console.WriteLine("TURNRIGHT");
            Console.WriteLine("LEDON");
            Console.WriteLine("LEDOFF");
            Console.WriteLine("GETTEMPERARTURE");
            Console.WriteLine("Enter DONE when finished");
            Console.WriteLine();
            
            while(command != Commands.DONE)
            {
                if(Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\tPlease enter a valid command...");
                }
            }

            DisplayMenuPrompt("User Control menu");
        }

        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;
            string userResponse;

            DisplayScreenHeader("Command Parameters");
            //use the same loop sequence to get and verify each value.
            do
            {
                Console.WriteLine("\tSet the finch's motor speed to a speed between 1 and 255:");
                userResponse = Console.ReadLine();
                int.TryParse(userResponse, out commandParameters.motorSpeed);

                if (commandParameters.motorSpeed == 0 || commandParameters.motorSpeed > 255)
                {
                    Console.WriteLine("\tPlease enter a valid integer...");
                }

            } while (commandParameters.motorSpeed == 0 || commandParameters.motorSpeed > 255);

            do
            {
                Console.WriteLine("\tSet the finch's LED brightness between 1 and 255:");
                userResponse = Console.ReadLine();
                int.TryParse(userResponse, out commandParameters.ledBrightness);

                if (commandParameters.ledBrightness == 0 || commandParameters.ledBrightness > 255)
                {
                    Console.WriteLine("\tPlease enter a valid integer...");
                }

            } while (commandParameters.ledBrightness == 0 || commandParameters.ledBrightness > 255);

            do
            {
                Console.WriteLine("\tSet the finch's wait time in seconds between 1 and 15:");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out commandParameters.waitSeconds);

                if (commandParameters.waitSeconds == 0 || commandParameters.waitSeconds > 15)
                {
                    Console.WriteLine("\tPlease enter a valid integer...");
                }

            } while (commandParameters.waitSeconds == 0 || commandParameters.waitSeconds > 15);

            Console.WriteLine($"\t Finch's Motor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\t Finch's LED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\t Finch's Wait Time in Seconds: {commandParameters.waitSeconds}");
            DisplayMenuPrompt("User Control Menu");

            return commandParameters;
        }



        #endregion

        #region SET THEME

        static void DisplayReadAndSetTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            string fileIOStatusMessage;

            //
            // read theme from data and set theme
            //
            themeColors = ReadThemeDataExceptions(out fileIOStatusMessage);
            if (fileIOStatusMessage == "Complete")
            {
                Console.ForegroundColor = themeColors.foregroundColor;
                Console.BackgroundColor = themeColors.backgroundColor;
                Console.Clear();

                DisplayScreenHeader("Read Theme from Data File");
                Console.WriteLine("\n\tTheme read from data file.\n");
            }
            else
            {
                DisplayScreenHeader("Read Theme from Data File");
                Console.WriteLine("\n\tTheme not read from data file.");
                Console.WriteLine($"\t*** {fileIOStatusMessage} ***\n");
            }
            DisplayContinuePrompt();
        }

      
        static void DisplaySetNewTheme()
        {
            (ConsoleColor foregroundColor, ConsoleColor backgroundColor) themeColors;
            bool themeChosen = false;
            string fileIOStatusMessage;

            DisplayScreenHeader("Set New Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.Write("\tWould you like to change the current theme [ yes | no ]?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    //
                    // query the user for console colors
                    //
                    themeColors.foregroundColor = GetConsoleColorFromUser("foreground");
                    themeColors.backgroundColor = GetConsoleColorFromUser("background");

                    //
                    // set new theme
                    //
                    Console.ForegroundColor = themeColors.foregroundColor;
                    Console.BackgroundColor = themeColors.backgroundColor;
                    Console.Clear();
                    DisplayScreenHeader("Set Application Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.Write("\tIs this the theme you would like?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        themeChosen = true;
                        fileIOStatusMessage = WriteThemeDataExceptions(themeColors.foregroundColor, themeColors.backgroundColor);
                        if (fileIOStatusMessage == "Complete")
                        {
                            Console.WriteLine("\n\tNew theme written to data file.\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\tNew theme not written to data file.");
                            Console.WriteLine($"\t*** {fileIOStatusMessage} ***\n");
                        }
                    }

                } while (!themeChosen);
            }
            DisplayContinuePrompt();
        }


        static ConsoleColor GetConsoleColorFromUser(string property)
        {
            ConsoleColor consoleColor;
            bool validConsoleColor;

            do
            {
                Console.Write($"\tEnter a value for the {property}:");
                validConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out consoleColor);

                if (!validConsoleColor)
                {
                    Console.WriteLine("\n\t***** It appears you did not provide a valid console color. Please try again. *****\n");
                }
                else
                {
                    validConsoleColor = true;
                }

            } while (!validConsoleColor);

            return consoleColor;
        }


        static (ConsoleColor foregroundColor, ConsoleColor backgroundColor) ReadThemeDataExceptions(out string fileIOStatusMessage)
        {
            string dataPath = @"Data/Theme.txt";
            string[] themeColors;

            ConsoleColor foregroundColor = ConsoleColor.White;
            ConsoleColor backgroundColor = ConsoleColor.Black;

            try
            {
                themeColors = File.ReadAllLines(dataPath);
                if (Enum.TryParse(themeColors[0], true, out foregroundColor) &&
                    Enum.TryParse(themeColors[1], true, out backgroundColor))
                {
                    fileIOStatusMessage = "Complete";
                }
                else
                {
                    fileIOStatusMessage = "Data file incorrectly formated.";
                }
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to read data file.";
            }

            return (foregroundColor, backgroundColor);
        }


        static string WriteThemeDataExceptions(ConsoleColor foreground, ConsoleColor background)
        {
            string dataPath = @"Data/Theme.txt";
            string fileIOStatusMessage = "";

            try
            {
                File.WriteAllText(dataPath, foreground.ToString() + "\n");
                File.AppendAllText(dataPath, background.ToString());
                fileIOStatusMessage = "Complete";
            }
            catch (DirectoryNotFoundException)
            {
                fileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                fileIOStatusMessage = "Unable to write to data file.";
            }

            return fileIOStatusMessage;
        }


        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        ///
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
