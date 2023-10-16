using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace WinFormsApp39
{
    internal class Game
    {
        public Button[] Array { get; private set; }
        private string[,] grid;
        private int row, col;
        private SoundPlayer player;
        public Game()
        {
            player = new SoundPlayer();
            player.SoundLocation = "1.wav";
            Array = GeneratorButton.Create(16, 4);
            Shaffle();
            grid = new string[4, 4];
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grid[i, j] = Array[index].Text;
                    row = i;
                    col = j;
                    if (Array[index].Text == "16")
                    {
                        Array[index].Visible= false;
                    }
                    index++;
                }
            }
        }

        private void Shaffle()
        {
            Random random = new Random();
            for (int i = 0; i < Array.Length; i++)
            {
                int index = random.Next(0, Array.Length);
                string temp = Array[i].Text;
                Array[i].Text = Array[index].Text;
                Array[index].Text = temp;
            }
        }
        public void Step(string value)
        {
            //player.Play();
            if(row - 1 >= 0 && grid[row - 1, col] == value) 
            {
                grid[row - 1, col] = "16";
                grid[row, col] = value;
            }

            if(row + 1 <= 3 && grid[row + 1 ,col] == value)
            {
                grid[row + 1, col] = "16";
                grid[row, col] = value;
            }

            if(col -1>=0 && grid[row, col -1] == value)
            {
                grid[row, col - 1] = "16";
                grid[row, col] = value;
            } 

            if(col + 1 >= 3 && grid[row, col +1] == value)
            {
                grid[row, col + 1] = "16";
                grid[row, col] = value;
            }

            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Array[index].Text = grid[i, j];
                    if (Array[index].Text == "16")
                    {
                        Array[index].Visible = false;
                        row = i;
                        col = j;
                    }
                    else
                    {
                        Array[index].Visible = true;    
                    }
                    index++;
                    
                   
                }
            }
            CheckWin();
        }

        private void CheckWin()
        {
            int index = 1;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i].Text == index.ToString())
                {
                    index++;
                }
                else
                {
                    break;
                }
            }
            if(index >=16)
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    Array[i].BackColor = Color.Green;
                    Array[i].Enabled= false;
                }
            }
        }
    }
}
