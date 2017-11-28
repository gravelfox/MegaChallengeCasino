using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        string[] tiles = { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon", "Orange", "Plum", "Seven", "Strawberry", "Watermelon" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                double coffer = 100.0;
                ViewState.Add("Coffer", coffer);
                int[] result = generateOutcome();
                printPlayerMoney();
            }

        }

        protected void spinButton_Click(object sender, EventArgs e)
        {
            double wager;

            //ensure a value has been bet, if so, pass to wager
            if (!evaluateWager(out wager)) return;

            //debit bet from coffer and save to viewstate
            debitWager(wager);

            //populate reels with tiles
            int[] result = generateOutcome();

            //award winnings to coffer and save to viewstate
            awardWinnings(calculateWinnings(wager, result));

        }

        private bool evaluateWager(out double wager)
        {
            if (double.TryParse(wagerBox.Text.Trim(), out wager) && wager <= (double)ViewState["Coffer"] && wager > 0)
                return true;
                else return false;
        }

        private void debitWager(double wager)
        {
            ViewState["Coffer"] = (double)ViewState["Coffer"] - wager;
        }

        private int[] generateOutcome()
        {
            Random random = new Random();
            int[] result = { random.Next(12), random.Next(12), random.Next(12) };
            reel1.ImageUrl = "./" + populateReel(result[0]) + ".png";
            reel2.ImageUrl = "./" + populateReel(result[1]) + ".png";
            reel3.ImageUrl = "./" + populateReel(result[2]) + ".png";
            return result;

        }

        private string populateReel(int random)
        {
            return tiles[random];
        }

        //test reels for win
        private double calculateWinnings(double wager, int[] result)
        {
            int winningsMult = 1;
            if (result[0] == 0 || result[1] == 0 || result[2] == 0) winningsMult = 0;
            else if (result[0] == 9 && result[1] == 9 && result[2] == 9) winningsMult = 100;
            else for (int i = 0; i < 3; i++) if (result[i] == 2) winningsMult++;
            if (winningsMult != 1) return winningsMult * wager;
                else return 0;
        }

        private void awardWinnings(double winnings)
        {
            ViewState["Coffer"] = (double)ViewState["Coffer"] + winnings;
            printPlayerMoney();
            //report result to user
            printResult(winnings);
        }

        private void printResult(double winnings)
        {
            if (winnings == 0)
                resultLabel.Text = string.Format("Sorry, you lost {0:C}. Try again!", double.Parse(wagerBox.Text.Trim()));
            else
                resultLabel.Text = string.Format("You're a winner! You've won {0:C}", winnings);
        }

        private void printPlayerMoney()
        {
            moneyLabel.Text = string.Format("{0:C}", ViewState["Coffer"]);
        }

    }
}