public class Cell
{
    public const int BOMB = -1;
    public const int EMPTY = 0;

    public int value { get; set; }
    public Button button { get; private set; }
    public bool isFlag { get; private set; }

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

    public bool isNotABombAndNotEmptyAndNotFlag()
    {
        return !isBomb() && !isEmpty() && !isFlag;
    }

    public void reset()
    {
        value = 0;
        isFlag = false;
        button.Enabled = true;
        button.Text = "";
        button.Image = null;
        button.BackColor = Color.LightGray;
    }

    public void active()
    {
        isFlag = false;
        button.Text = isNotABombAndNotEmpty() ? value.ToString() : "";
        button.Image = null;
        button.BackColor = Color.White;
        button.Enabled = false;
    }

    public void flag(Bitmap image)
    {
        isFlag = !isFlag;

        button.Text = "";

        if (!isFlag)
        {
            button.Image = null;
            return;
        }

        button.Image = image;
    }

    public void activeBomb(Bitmap image)
    {
        isFlag = false;
        button.Text = "";
        button.Image = image;
        button.BackColor = Color.White;
        button.Enabled = false;
    }
}
