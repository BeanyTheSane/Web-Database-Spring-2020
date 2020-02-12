using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rock_Paper_Scissors.Pages
{
    public class IndexModel : PageModel
    {
        public String userChoice { get; set; }
        public String gameChoice { get; set; }
        public String userChoiceImage { get; set; }
        public String gameChoiceImage { get; set; }
        public String resultsBannerImage { get; set; }
        public String persistRock { get; set; }
        public String persistPaper { get; set; }
        public String persistScissors { get; set; }
        public int userScore = 0;
        public int gameScore = 0;

        public void OnGet()
        {
            persistRock = "checked";
        }

        public void OnPost()
        {
            gameScore = Convert.ToInt32(Request.Form["gameScore"]);
            userScore = Convert.ToInt32(Request.Form["userScore"]);

            userChoice = Request.Form["userSelection"];
            switch (userChoice)
            {
                case "rock":
                    userChoiceImage = "leftRock.png";
                    persistUserChoice("rock");
                    break;
                case "paper":
                    userChoiceImage = "leftPaper.png";
                    persistUserChoice("paper");
                    break;
                case "scissors":
                    userChoiceImage = "leftScissors.png";
                    persistUserChoice("scissors");
                    break;
                default:
                    break;
            }
            Random random = new Random();
            switch (random.Next(1,4))
            {
                case 1:
                    gameChoice = "rock";
                    gameChoiceImage = "rightRock.png";
                    break;
                case 2:
                    gameChoice = "paper";
                    gameChoiceImage = "rightPaper.png";
                    break;
                case 3:
                    gameChoice = "scissors";
                    gameChoiceImage = "rightScissors.png";
                    break;
                default:
                    break;
            }



            evaluateResults();

        }

        private void evaluateResults()
        {
            if ((userChoice.Equals("rock") && gameChoice.Equals("scissors"))
                || (userChoice.Equals("paper") && gameChoice.Equals("rock"))
                || (userChoice.Equals("scissors") && gameChoice.Equals("paper")))
            {
                resultsBannerImage = "winnerBanner.png";
                userScore = userScore + 1;
            }
            else if ((userChoice.Equals("rock") && gameChoice.Equals("paper"))
                || (userChoice.Equals("paper") && gameChoice.Equals("scissors"))
                || (userChoice.Equals("scissors") && gameChoice.Equals("rock")))
            {
                resultsBannerImage = "loserBanner.png";
                gameScore = gameScore + 1;
            }
            else
            {
                resultsBannerImage = "drawBanner.png";
            }
        }

        private void persistUserChoice(String userChoice)
        {
            persistRock = "";
            persistPaper = "";
            persistScissors = "";
            switch (userChoice)
            {
                case "rock":
                    persistRock = "checked";
                    break;

                case "paper":
                    persistPaper = "checked";
                    break;

                case "scissors":
                    persistScissors = "checked";
                    break;

                default:
                    break;
            }
        }
    }
}
