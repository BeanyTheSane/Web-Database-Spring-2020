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

        public void OnPost()
        {
            userChoice = Request.Form["userSelection"];
            switch (userChoice)
            {
                case "rock":
                    userChoiceImage = "leftRock.png";
                    break;
                case "paper":
                    userChoiceImage = "leftPaper.png";
                    break;
                case "scissors":
                    userChoiceImage = "leftScissors.png";
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
            }
            else if ((userChoice.Equals("rock") && gameChoice.Equals("paper"))
                || (userChoice.Equals("paper") && gameChoice.Equals("scissors"))
                || (userChoice.Equals("scissors") && gameChoice.Equals("rock")))
            {
                resultsBannerImage = "loserBanner.png";
            }
            else
            {
                resultsBannerImage = "drawBanner.png";
            }
        }
    }
}
