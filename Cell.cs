public class Cell
{
	public const int BOMB = -1;
    public const int EMPTY = 0;

    public int value { get; set; }
    public Button button { get; private set; }

    public Cell(int value, Button button)
	{
        this.value = value;
        this.button = button;

        reset();
	}

    public bool isBomb()
    {
        return value == BOMB;
    }

    public bool isEmpty()
    {
        return value == EMPTY;
    }

    public bool isNotABombAndNotEmpty()
    {
        return !isBomb() && !isEmpty();
    }

    public void reset()
    {
        value = 0;
        button.Enabled = true;
        button.Text = "";
        button.BackColor = Color.LightGray;
        button.Image = null;
    }

    public void active()
    {
        button.Text = isNotABombAndNotEmpty() ? value.ToString() : "";
        button.BackColor = Color.White;
        button.Enabled = false;
    }

    public void activeBomb(Bitmap image)
    {
        button.Text = "";
        button.Image = image;
        button.BackColor = Color.White;
        button.Enabled = false;
    }
}
