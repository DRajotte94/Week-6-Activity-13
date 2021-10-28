using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_6_Activity_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // list of each textbox used for storing game values
            List<TextBox> display = new List<TextBox>();
            display.Add(ul); display.Add(um); display.Add(ur); // top row
            display.Add(ml); display.Add(mm); display.Add(mr); // middle row
            display.Add(ll); display.Add(lm); display.Add(lr); // bottom row

            // verify each textbox is empty at the start of every game
            ClearTextBoxes(this.Controls);

            Random r = new Random(); // generate random numbers for the game

            // two-dimensional array for game board
            int[,] board = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }; // values are all unique to avoid game assuming winner at beginning
            int boxCount = 0; // tracks which textbox is next

            // two for-loops to iterate through the array
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = r.Next(0, 2);

                    // display results on screen
                    if (board[i, j] == 0)
                    {
                        display[boxCount].Text = "O";
                    }
                    else
                    {
                        display[boxCount].Text = "X";
                    }
                    
                    boxCount++; // increments to use next textbox in list

                    if (CheckResults(board) != "Draw")
                    {
                        goto GameEnd; // break out of both loops
                    }
                }
            }

            // print end results
            GameEnd: results.Text = CheckResults(board).ToString();
        }

        public String CheckResults(int[,] board)
        {
            int winner = 9; // 0 and 1 are already assigned so 9 represents a draw

            // win conditions
            if (board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2]) // across the top
            {
                winner = board[0,0];
            }
            else if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2]) // across the middle
            {
                winner = board[1, 0];
            }
            else if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2]) // across the bottom
            {
                winner = board[2, 0];
            }
            else if (board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0]) // down the left
            {
                winner = board[0, 0];
            }
            else if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1]) // down the middle
            {
                winner = board[0, 1];
            }
            else if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2]) // down the right
            {
                winner = board[0, 2];
            }
            else if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) // diagonal from the left to right
            {
                winner = board[0, 0];
            }
            else if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) // diagonal from the right to left
            {
                winner = board[0, 2];
            } 
            else
            {
                winner = 9;
            }

            // return winner or draw
            if (winner == 1)
            {
                return "X is the winner!";
            }
            else if (winner == 0)
            {
                return "O is the winner!";
            }
            else
            {
                return "Draw";
            }
        }

        // Method clears all text boxes in control for each new game
        // Credit: Thomas Daniels, 30-Aug-2014, https://www.codeproject.com/Questions/813344/Clear-all-textboxes-in-form-with-one-Function
        public void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }
    }
}
