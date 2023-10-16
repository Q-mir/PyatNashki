namespace WinFormsApp39
{
    public partial class Form1 : Form
    {
        Game game = new Game();
        public Form1()
        {
            InitializeComponent();
            Button[] buttons = game.Array;
            for (int i = 0; i < buttons.Length; i++)
            {
                Controls.Add(buttons[i]);
                buttons[i].Click += Form1_Click;
            }
        }

        private void Form1_Click(object? sender, EventArgs e)
        {
            Button button = (Button?)sender;
            if(button != null)
            {
                game.Step(button.Text);
                
            }
        }
    }
}
