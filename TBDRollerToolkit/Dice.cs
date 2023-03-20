using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBDRollerToolkit
{
    int dieTotal = 0;
    int lowRoll;

    bool dropLowest = false;
    bool lowDropped = false;
    bool top3 = false;
    bool drop1 = false;
    bool critConfirm = false;
    bool addMods = false;
    bool strikeMod = false;

    bool reroll1 = false;

    Random die = new Random();

    List<int> dice = new List<int>();
    List<int> keepList = new List<int>();
    List<int> sortDice = new List<int>();

    class Dice
    {
    }

    private void DiceCheck()
    {
        if (!d4Input.Text.Equals(null) && int.TryParse(d4Input.Text, out int d4) == true && d4 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d4: ");

            RollDice(d4, 4);
        }
        if (!d6Input.Text.Equals(null) && int.TryParse(d6Input.Text, out int d6) == true && d6 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d6: ");

            RollDice(d6, 6);
        }
        if (!d8Input.Text.Equals(null) && int.TryParse(d8Input.Text, out int d8) == true && d8 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d8: ");

            RollDice(d8, 8);
        }
        if (!d10Input.Text.Equals(null) && int.TryParse(d10Input.Text, out int d10) == true && d10 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d10: ");

            RollDice(d10, 10);
        }
        if (!d12Input.Text.Equals(null) && int.TryParse(d12Input.Text, out int d12) == true && d12 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d12: ");

            RollDice(d12, 12);
        }
        if (!d20Input.Text.Equals(null) && int.TryParse(d20Input.Text, out int d20) == true && d20 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d20: ");

            RollDice(d20, 20);
        }
        if (!d100Input.Text.Equals(null) && int.TryParse(d100Input.Text, out int d100) == true && d100 > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d100: ");

            RollDice(d100, 100);
        }
        if (!dXInput.Text.Equals(null) && int.TryParse(dXInput.Text, out int dX) == true && !dXDie.Text.Equals(null) && int.TryParse(dXDie.Text, out int dXD) == true && dX > 0)
        {
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Italic);
            RollOutput.AppendText("d" + dXDie.Text + ": ");

            RollDice(dX, dXD);
        }
    }

    private void RollDice(int numRolls, int dSides)
    {
        RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Regular);

        for (int i = 0; i < numRolls; i++)

        {
            if (reroll1 == true)
            {
                dice.Add(die.Next(1, (dSides + 1)));

                while (dice[i] == 1)
                {
                    dice[i] = die.Next(1, (dSides + 1));
                }
            }
            else
            {
                dice.Add(die.Next(1, (dSides + 1)));
            }

            dieTotal = dieTotal + dice[i];

            if (i == 0)
            {
                lowRoll = dice[i];
            }
            else
            {
                if (dice[i] < lowRoll)
                {
                    lowRoll = dice[i];
                }
            }
        }

        for (int i = 0; i < numRolls; i++)
        {
            if (dice[i] == 1)
            {
                RollOutput.SelectionColor = Color.Red;
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Bold);
            }
            else if (dice[i] == dSides)
            {
                RollOutput.SelectionColor = Color.Green;
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Bold);
            }

            if (dropLowest == true && dice[i] == lowRoll && lowDropped == false)
            {
                RollOutput.SelectionColor = Color.Gray;
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Strikeout);

                dieTotal = dieTotal - dice[i];

                lowDropped = true;
            }

            if (drop1 == true && dice[i] == 1)
            {
                RollOutput.SelectionColor = Color.Gray;
                RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Strikeout);

                dieTotal = dieTotal - dice[i];
            }

            RollOutput.AppendText(dice[i].ToString());

            RollOutput.AppendText("  ");

            if (addMods == true)
            {
                if (drop1 == true && dice[i] != 1)
                {
                    strikeMod = true;
                    Mods(dSides);
                    RollOutput.AppendText("     ");
                }
                else if (dropLowest == true && dice[i] != lowRoll)
                {
                    strikeMod = true;
                    Mods(dSides);
                    RollOutput.AppendText("     ");
                }
                else
                {
                    Mods(dSides);
                    RollOutput.AppendText("     ");
                }
            }

            if (critConfirm == true && dice[i] == dSides)
            {
                ConfirmCrit(dSides);
            }

            RollOutput.SelectionColor = Color.Black;
            RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Regular);
        }

        if (addMods == false)
        {
            Mods(dSides);
        }

        RollOutput.AppendText("\n");
        lowDropped = false;
        dice.Clear();
    }

    private void Mods(int dSides)
    {
        RollOutput.SelectionColor = Color.DarkGoldenrod;
        RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Regular);

        if (dSides == 4)
        {
            if (!d4Mod.Text.Equals(null) && int.TryParse(d4Mod.Text, out int d4) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d4 > 0)
                {
                    RollOutput.AppendText("+ " + d4);
                    dieTotal = dieTotal + d4;
                }
                else if (d4 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d4));
                    dieTotal = dieTotal + d4;
                }
            }
        }
        else if (dSides == 6)
        {
            if (!d6Mod.Text.Equals(null) && int.TryParse(d6Mod.Text, out int d6) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d6 > 0)
                {
                    RollOutput.AppendText("+ " + d6);
                    dieTotal = dieTotal + d6;
                }
                else if (d6 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d6));
                    dieTotal = dieTotal + d6;
                }
            }
        }
        else if (dSides == 8)
        {
            if (!d8Mod.Text.Equals(null) && int.TryParse(d8Mod.Text, out int d8) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d8 > 0)
                {
                    RollOutput.AppendText("+ " + d8);
                    dieTotal = dieTotal + d8;
                }
                else if (d8 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d8));
                    dieTotal = dieTotal + d8;
                }
            }
        }
        else if (dSides == 10)
        {
            if (!d10Mod.Text.Equals(null) && int.TryParse(d10Mod.Text, out int d10) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d10 > 0)
                {
                    RollOutput.AppendText("+ " + d10);
                    dieTotal = dieTotal + d10;
                }
                else if (d10 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d10));
                    dieTotal = dieTotal + d10;
                }
            }
        }
        else if (dSides == 12)
        {
            if (!d12Mod.Text.Equals(null) && int.TryParse(d12Mod.Text, out int d12) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d12 > 0)
                {
                    RollOutput.AppendText("+ " + d12);
                    dieTotal = dieTotal + d12;
                }
                else if (d12 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d12));
                    dieTotal = dieTotal + d12;
                }
            }
        }
        else if (dSides == 20)
        {
            if (!d20Mod.Text.Equals(null) && int.TryParse(d20Mod.Text, out int d20) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d20 > 0)
                {
                    RollOutput.AppendText("+ " + d20);
                    dieTotal = dieTotal + d20;
                }
                else if (d20 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d20));
                    dieTotal = dieTotal + d20;
                }
            }
        }
        else if (dSides == 100)
        {
            if (!d100Mod.Text.Equals(null) && int.TryParse(d100Mod.Text, out int d100) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (d100 > 0)
                {
                    RollOutput.AppendText("+ " + d100);
                    dieTotal = dieTotal + d100;
                }
                else if (d100 < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(d100));
                    dieTotal = dieTotal + d100;
                }
            }
        }
        else
        {
            if (!dXMod.Text.Equals(null) && int.TryParse(dXMod.Text, out int dX) == true)
            {
                if (strikeMod == true)
                {
                    strikeMod = false;
                }
                else if (dX > 0)
                {
                    RollOutput.AppendText("+ " + dX);
                    dieTotal = dieTotal + dX;
                }
                else if (dX < 0)
                {
                    RollOutput.AppendText("- " + Math.Abs(dX));
                    dieTotal = dieTotal + dX;
                }
            }
        }
    }

    private void ConfirmCrit(int sides)
    {
        RollOutput.SelectionColor = Color.DarkBlue;
        RollOutput.SelectionFont = new Font(RollOutput.Font, FontStyle.Bold);

        RollOutput.AppendText("(" + die.Next(1, sides + 1) + ")  ");
    }

    private void dropLowestCheck_CheckedChanged_1(object sender, EventArgs e)
    {
        if (dropLowest == false)
        {
            dropLowest = true;
        }
        else
        {
            dropLowest = false;
        }
    }

    private void drop1sCheck_CheckedChanged_1(object sender, EventArgs e)
    {
        if (drop1 == false)
        {
            drop1 = true;
        }
        else
        {
            drop1 = false;
        }
    }

    private void reroll1sCheck_CheckedChanged_1(object sender, EventArgs e)
    {
        if (reroll1 == false)
        {
            reroll1 = true;
        }
        else
        {
            reroll1 = false;
        }
    }

    private void addModsCheck_CheckedChanged_1(object sender, EventArgs e)
    {
        if (addMods == false)
        {
            addMods = true;
        }
        else
        {
            addMods = false;
        }
    }

    private void critConfirmCheck_CheckedChanged_1(object sender, EventArgs e)
    {
        if (critConfirm == false)
        {
            critConfirm = true;
        }
        else
        {
            critConfirm = false;
        }
    }
}
