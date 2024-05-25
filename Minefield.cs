public class Minefield
{
    private const int TOTAL_BOMBS = 7;
    private const int ROWS = 7;
    private const int COLS = 7;

    public bool playing;
    public int total_flags;
    public int time;

    private Cell[][] cells = new Cell[ROWS][];

    private Bitmap image_bomb;
    private TextBox txt_time;
    private TextBox txt_flags;

    public Minefield(Cell[][] cells, Bitmap image_bomb, TextBox txt_time, TextBox txt_flags)
	{
        this.cells = cells;
        this.image_bomb = image_bomb;
        this.txt_time = txt_time;
        this.txt_flags = txt_flags;

        reset();
    }

    public void clickCell(int row, int col)
    {
        if (!isValidCell(row, col)) return;

        if (cells[row][col].isBomb())
        {
            activeBombs();
            return;
        }

        activeCell(row, col);

        if (cells[row][col].isNotABombAndNotEmpty())
        {
            verifyWinner();
            return;
        }

        clickCell(row - 1, col);
        clickCell(row, col - 1);
        clickCell(row + 1, col);
        clickCell(row, col + 1);
        clickCell(row + 1, col + 1);
        clickCell(row - 1, col + 1);
        clickCell(row - 1, col - 1);
        clickCell(row + 1, col - 1);

        activeCell(row - 1, col);
        activeCell(row, col - 1);
        activeCell(row + 1, col);
        activeCell(row, col + 1);
        activeCell(row + 1, col + 1);
        activeCell(row - 1, col + 1);
        activeCell(row - 1, col - 1);
        activeCell(row + 1, col - 1);
    }

    private void reset()
    {
        this.total_flags = TOTAL_BOMBS;
        this.playing = true;
        this.time = 0;

        setTxtTime();
        setTxtFlags();

        Random rand = new Random();

        // Reseta celulas
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                cells[i][j].reset();
            }
        }

        // Sorteia as posições das bombas
        for (int i = 0; i < TOTAL_BOMBS; i++)
        {
            int row, col;

            do
            {
                row = rand.Next(0, ROWS - 1);
                col = rand.Next(0, COLS - 1);
            } while (cells[row][col].isBomb());

            cells[row][col].value = Cell.BOMB;
        }

        // Contabilizando as bombas ao redor de cada celula do tabuleiro
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                Cell cell = cells[i][j];
                int total = 0;

                if (cell.isBomb()) continue;

                // Verificando e contabilizando as linhas vizinhas
                if (isBombCell(i - 1, j))
                {
                    total += convertBombValueCell(i - 1, j);
                }

                if (isBombCell(i + 1, j))
                {
                    total += convertBombValueCell(i + 1, j);
                }

                // Verificando e contabilizando as colunas vizinhas
                if (isBombCell(i, j - 1))
                {
                    total += convertBombValueCell(i, j - 1);
                }

                if (isBombCell(i, j + 1))
                {
                    total += convertBombValueCell(i, j + 1);
                }

                // Verificando e contabilizando as diagonais vizinhas

                // Verificando canto superior esquerdo
                if (isBombCell(i - 1, j - 1))
                {
                    total += convertBombValueCell(i - 1, j - 1);
                }

                // Verificando canto superior direito
                if (isBombCell(i - 1, j + 1))
                {
                    total += convertBombValueCell(i - 1, j + 1);
                }

                // Verificando canto inferior esquerdo
                if (isBombCell(i + 1, j - 1))
                {
                    total += convertBombValueCell(i + 1, j - 1);
                }

                // Verificando canto inferior direito
                if (isBombCell(i + 1, j + 1))
                {
                    total += convertBombValueCell(i + 1, j + 1);
                }

                cell.value = total;
            }
        }
    }

    public void setTxtTime()
    {
        if (this.playing) this.time++;
        txt_time.Text = this.time.ToString();
    }

    public void setTxtFlags()
    {
        txt_flags.Text = this.total_flags.ToString();
    }

    private void activeBombs()
    {
        this.playing = false;

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (isBombCell(i, j))
                {
                    cells[i][j].activeBomb(image_bomb);
                }
            }
        }

        MessageBox.Show("Boooom! Você perdeu!");

        reset();
    }

    private void verifyWinner()
    {
        if (!hasWin()) return;

        this.playing = false;

        MessageBox.Show("Parabéns você ganhou!");

        reset();
    }

    private bool hasWin()
    {
        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if (isValidCell(i, j) && !cells[i][j].isBomb()) return false;
            }
        }

        return true;
    }

    private bool isBombCell(int i, int j)
    {
        return isValidCell(i, j) && cells[i][j].isBomb();
    }

    private bool isValidCell(int row, int col)
    {
        return row >= 0 &&
            col >= 0 &&
            row < ROWS &&
            col < COLS &&
            cells[row][col].button.Enabled == true;
    }

    private int convertBombValueCell(int row, int col)
    {
        return -1 * cells[row][col].value;
    }

    private void activeCell(int row, int col)
    {
        if (isValidCell(row, col)) cells[row][col].active();
    }
}
