using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RockPaperScissors
{
    class VM : INotifyPropertyChanged
    {
        private string displayResult = "";
        public string DisplayResult
        {
            get { return displayResult; }
            set { displayResult = value; NotifyChange(); }
        }

        private string displayUserSelection = "";
        public string DisplayUserSelection
        {
            get { return displayUserSelection /*"/RockPaperScissors; component / Resourses / Rock.bmp"*/; }
            set { displayUserSelection = value; NotifyChange(); }
        }

        private string displayComputerSelection = "";
        public string DisplayComputerSelection
        {
            get { return displayComputerSelection; }
            set { displayComputerSelection = value; NotifyChange(); }
        }

        private string userScore = "";
        public string UserScore
        {
            get { return userScore; }
            set { userScore = value; NotifyChange(); }
        }

        private string computerScore = "";
        public string ComputerScore
        {
            get { return computerScore; }
            set { computerScore = value; NotifyChange(); }
        }

        Random r = new Random();
        private Choice ComputerSelection;
        private Choice UserSelection;
        private string rockpath = "/RockPaperScissors;component/Resources/Rock.bmp";
        private string paperPath = "/RockPaperScissors;component/Resources/Paper.bmp";
        private string scissorsPath = "/RockPaperScissors;component/Resources/Scissors.bmp";
        private int playerScore;
        private int cpuScore;

        public enum Choice
        {
            Rock,
            Paper,
            Scissors,
        }

        public void Rock()
        {
            UserSelection = Choice.Rock;
            DisplayUserSelection = rockpath;
        }

        public void Paper()
        {
            UserSelection = Choice.Paper;
            DisplayUserSelection = paperPath;
        }

        public void Scissors()
        {
            UserSelection = Choice.Scissors;
            DisplayUserSelection = scissorsPath;
        }

        public void ComputerRandomSelection()
        {

            ComputerSelection = (Choice)Enum.ToObject(typeof(Choice), r.Next(0, 3));
            if (ComputerSelection.Equals(Choice.Rock))
            {
                DisplayComputerSelection = rockpath;
            }
            else if (ComputerSelection.Equals(Choice.Paper))
            {
                DisplayComputerSelection = paperPath;
            }
            else if (ComputerSelection.Equals(Choice.Scissors))
            {
                DisplayComputerSelection = scissorsPath;
            }
        }

        public void GetResult()
        {
            if (
                    (UserSelection.Equals(Choice.Rock) && ComputerSelection.Equals(Choice.Rock)) ||
                    (UserSelection.Equals(Choice.Paper) && ComputerSelection.Equals(Choice.Paper)) ||
                    (UserSelection.Equals(Choice.Scissors) && ComputerSelection.Equals(Choice.Scissors))
               )
            {
                if (playerScore > cpuScore)
                {
                    DisplayResult = "It's a tie & You are leading by points # " + (playerScore - cpuScore).ToString();
                    return;
                }
                else if (playerScore < cpuScore)
                {
                    DisplayResult = "It's a tie & Computer is leading by points # " + (cpuScore - playerScore).ToString();
                    return;
                }
                else if (playerScore == cpuScore)
                {
                    DisplayResult = "It's a tie & both players have equal points";
                    return;
                }
            }
            else
            if (
                    (UserSelection.Equals(Choice.Rock) && ComputerSelection.Equals(Choice.Scissors)) ||
                    (UserSelection.Equals(Choice.Paper) && ComputerSelection.Equals(Choice.Rock)) ||
                    (UserSelection.Equals(Choice.Scissors) && ComputerSelection.Equals(Choice.Paper))
               )
            {
                playerScore += 1;
                UserScore = playerScore.ToString();
                if (playerScore > cpuScore)
                {
                    DisplayResult = "You win & You are in lead by points # " + (playerScore - cpuScore).ToString();
                    return;
                }
                else if (playerScore < cpuScore)
                {
                    DisplayResult = "You win & Computer is in lead by points # " + (cpuScore - playerScore).ToString();
                    return;
                }
                else if (playerScore == cpuScore)
                {
                    DisplayResult = "You win & both players have equal points";
                    return;
                }
            }
            else
            if (
                    (UserSelection.Equals(Choice.Paper) && ComputerSelection.Equals(Choice.Rock)) ||
                    (UserSelection.Equals(Choice.Scissors) && ComputerSelection.Equals(Choice.Rock)) ||
                    (UserSelection.Equals(Choice.Rock) && ComputerSelection.Equals(Choice.Paper)) ||
                    (UserSelection.Equals(Choice.Paper) && ComputerSelection.Equals(Choice.Scissors))
               )
            {
                cpuScore += 1;
                ComputerScore = cpuScore.ToString();
                if (playerScore > cpuScore)
                {
                    DisplayResult = "Computer wins & You are in lead by points # " + (playerScore - cpuScore).ToString();
                    return;
                }
                else if (playerScore < cpuScore)
                {
                    DisplayResult = "Computer wins & Computer is in lead by points # " + (cpuScore - playerScore).ToString();
                    return;
                }
                else if (playerScore == cpuScore)
                {
                    DisplayResult = "Computer wins & both players have equal points";
                    return;
                }
            }
        }

        public void ResetData()
        {
            DisplayResult = "";
            DisplayUserSelection = "/RockPaperScissors;component/Resources/Cover.png";
            DisplayComputerSelection = "/RockPaperScissors;component/Resources/Cover.png";
            UserScore = "0";
            ComputerScore = "0";
            playerScore = 0;
            cpuScore = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
