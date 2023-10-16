using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp39
{
    internal static class GeneratorButton
    {
        public static Button[] Create(int value, int row)
        {
            Button[] buttons = new Button[value];
            int horizontal = 0;
            int vertical = 0;
            int width = 100;
            int height = 100;
            int index = 1;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i != 0 && i % row == 0)
                {
                    horizontal = 0;
                    vertical += height;
                }
                Button item = new Button();
                item.Width = width;
                item.Height = height;
                item.Text = index.ToString();
                index++;
                item.Location = new Point(horizontal, vertical);
                horizontal += width;
                buttons[i] = item;
            }
            return buttons;
        }
    }
}

