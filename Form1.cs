using static System.Net.Mime.MediaTypeNames;

namespace campo_minado
{
    public partial class Form1 : Form
    {
        private const int TOTAL_BOMBS = 7;
        private const int LINES = 7;
        private const int COLS = 7;

        private bool gameover = false;
        private int total_flags = 0;
        private int time = 0;

        private int[,] tabuleiro = new int[LINES, COLS];
        private Button[][] btns = new Button[LINES][];

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void initBtns()
        {
            btns = [
                [ btn_00, btn_01, btn_02, btn_03, btn_04, btn_05, btn_06 ],
                [ btn_10, btn_11, btn_12, btn_13, btn_14, btn_15, btn_16 ],
                [ btn_20, btn_21, btn_22, btn_23, btn_24, btn_25, btn_26 ],
                [ btn_30, btn_31, btn_32, btn_33, btn_34, btn_35, btn_36 ],
                [ btn_40, btn_41, btn_42, btn_43, btn_44, btn_45, btn_46 ],
                [ btn_50, btn_51, btn_52, btn_53, btn_54, btn_55, btn_56 ],
                [ btn_60, btn_61, btn_62, btn_63, btn_64, btn_65, btn_66 ],
            ];
        }

        private bool isBomb(int i, int j)
        {
            return tabuleiro[i, j] == -1;
        }

        private int convertBombValue(int i, int j)
        {
            return -1 * tabuleiro[i, j];
        }

        private void init()
        {
            this.total_flags = TOTAL_BOMBS;
            this.gameover = false;
            this.time = 0;

            initBtns();
            setTxtTime();
            setTxtFlags();

            Random rand = new Random();

            // Inicializa os campos da matriz com 0
            for (int i = 0; i < LINES; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    btns[i][j].Enabled = true;
                    restartCell(i, j);
                }
            }

            // Sorteia as posições das bombas
            for (int i = 0; i < TOTAL_BOMBS; i++)
            {
                int l, c;

                do
                {
                    l = rand.Next(0, LINES - 1);
                    c = rand.Next(0, COLS - 1);
                } while (tabuleiro[l, c] == -1);

                tabuleiro[l, c] = -1;
            }

            // Contabilizando as bombas ao redor de cada celula do tabuleiro
            for (int i = 0; i < LINES; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    int cell = tabuleiro[i, j];
                    int total = 0;

                    if (cell == -1) continue;

                    // Verificando e contabilizando as linhas vizinhas
                    if (i > 0 && isBomb(i - 1, j))
                    {
                        total += convertBombValue(i - 1, j);
                    }

                    if (i < LINES - 1 && isBomb(i + 1, j))
                    {
                        total += convertBombValue(i + 1, j);
                    }

                    // Verificando e contabilizando as colunas vizinhas
                    if (j > 0 && isBomb(i, j - 1))
                    {
                        total += convertBombValue(i, j - 1);
                    }

                    if (j < COLS - 1 && isBomb(i, j + 1))
                    {
                        total += convertBombValue(i, j + 1);
                    }

                    // Verificando e contabilizando as diagonais vizinhas

                    // Verificando canto superior esquerdo
                    if (j > 0 && i > 0 && isBomb(i - 1, j - 1))
                    {
                        total += convertBombValue(i - 1, j - 1);
                    }

                    // Verificando canto superior direito
                    if (j < COLS - 1 && i > 0 && isBomb(i - 1, j + 1))
                    {
                        total += convertBombValue(i - 1, j + 1);
                    }

                    // Verificando canto inferior esquerdo
                    if (j > 0 && i < LINES - 1 && isBomb(i + 1, j - 1))
                    {
                        total += convertBombValue(i + 1, j - 1);
                    }

                    // Verificando canto inferior direito
                    if (j < COLS - 1 && i < LINES - 1 && isBomb(i + 1, j + 1))
                    {
                        total += convertBombValue(i + 1, j + 1);
                    }

                    tabuleiro[i, j] = total;
                    // btns[i][j].Text = total.ToString();
                }
            }
        }

        private void verifySelectBox(int row, int col)
        {
            if (isValidAndIsABomb(row, col))
            {
                activeBombs();
                return;
            }

            if (isValidAndAPositiveNumber(row, col))
            {
                activeButton(row, col);
                verifyWinner();
                return;
            }

            if (isValidAndDifferentZero(row, col)) return;

            activeButton(row, col);

            verifySelectBox(row - 1, col);
            verifySelectBox(row, col - 1);

            verifySelectBox(row + 1, col);
            verifySelectBox(row, col + 1);

            activeButton(row - 1, col);
            activeButton(row, col - 1);

            activeButton(row + 1, col);
            activeButton(row, col + 1);
        }

        private void verifyWinner()
        {
            if (!hasWin()) return;

            MessageBox.Show("Parabéns você ganhou!");
            init();
        }

        private bool hasWin()
        {
            for (int i = 0; i < LINES; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (isValidAndDifferentNegative(i, j)) return false;
                }
            }

            return true;
        }

        private void activeButton(int row, int col)
        {
            if (isInvalidCell(row, col)) return;

            int value = tabuleiro[row, col];

            btns[row][col].Text = value > 0 ? value.ToString() : "";
            btns[row][col].BackColor = Color.White;
            btns[row][col].Enabled = false;
        }

        private void restartCell(int row, int col)
        {
            if (isInvalidCell(row, col)) return;

            tabuleiro[row, col] = 0;

            btns[row][col].Enabled = true;
            btns[row][col].Text = "";
            btns[row][col].BackColor = Color.LightGray;
            btns[row][col].Image = null;
        }

        private void activeBombs()
        {
            this.gameover = true;

            for (int i = 0; i < LINES; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (isBomb(i, j))
                    {
                        btns[i][j].Image = Properties.Resources.bomb;
                        btns[i][j].BackColor = Color.White;
                        btns[i][j].Enabled = false;
                    }
                }
            }

            MessageBox.Show("Boooom! Você perdeu!");

            init();
        }

        private bool isValidAndIsABomb(int row, int col)
        {
            return !isInvalidCell(row, col) && tabuleiro[row, col] == -1;
        }

        private bool isValidAndAPositiveNumber(int row, int col)
        {
            return !isInvalidCell(row, col) && tabuleiro[row, col] > 0;
        }

        private bool isValidAndDifferentZero(int row, int col)
        {
            return isInvalidCell(row, col) || tabuleiro[row, col] != 0;
        }

        private bool isValidAndDifferentNegative(int row, int col)
        {
            return !isInvalidCell(row, col) && (tabuleiro[row, col] >= 0 && btns[row][col].Enabled);
        }

        private bool isInvalidCell(int row, int col)
        {
            return row < 0 ||
                col < 0 ||
                row >= LINES ||
                col >= COLS ||
                btns[row][col].Enabled == false;
        }

        private void setTxtTime()
        {
            txt_time.Text = this.time.ToString();
        }

        private void setTxtFlags()
        {
            txt_flags.Text = this.total_flags.ToString();
        }

        private void timer_game_Tick(object sender, EventArgs e)
        {
            if (!this.gameover) this.time++;
            setTxtTime();
        }

        private void btn_00_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 0);
        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 1);
        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 2);
        }

        private void btn_03_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 3);
        }

        private void btn_04_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 4);
        }

        private void btn_05_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 5);
        }

        private void btn_06_Click(object sender, EventArgs e)
        {
            verifySelectBox(0, 6);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 0);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 1);
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 2);
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 3);
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 4);
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 5);
        }

        private void btn_16_Click(object sender, EventArgs e)
        {
            verifySelectBox(1, 6);
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 0);
        }

        private void btn_21_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 1);
        }

        private void btn_22_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 2);
        }

        private void btn_23_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 3);
        }

        private void btn_24_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 4);
        }

        private void btn_25_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 5);
        }

        private void btn_26_Click(object sender, EventArgs e)
        {
            verifySelectBox(2, 6);
        }

        private void btn_30_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 0);
        }

        private void btn_31_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 1);
        }

        private void btn_32_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 2);
        }

        private void btn_33_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 3);
        }

        private void btn_34_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 4);
        }

        private void btn_35_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 5);
        }

        private void btn_36_Click(object sender, EventArgs e)
        {
            verifySelectBox(3, 6);
        }

        private void btn_40_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 0);
        }

        private void btn_41_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 1);
        }

        private void btn_42_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 2);
        }

        private void btn_43_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 3);
        }

        private void btn_44_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 4);
        }

        private void btn_45_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 5);
        }

        private void btn_46_Click(object sender, EventArgs e)
        {
            verifySelectBox(4, 6);
        }

        private void btn_50_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 0);
        }

        private void btn_51_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 1);
        }

        private void btn_52_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 2);
        }

        private void btn_53_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 3);
        }

        private void btn_54_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 4);
        }

        private void btn_55_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 5);
        }

        private void btn_56_Click(object sender, EventArgs e)
        {
            verifySelectBox(5, 6);
        }

        private void btn_60_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 0);
        }

        private void btn_61_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 1);
        }

        private void btn_62_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 2);
        }

        private void btn_63_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 3);
        }

        private void btn_64_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 4);
        }

        private void btn_65_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 5);
        }

        private void btn_66_Click(object sender, EventArgs e)
        {
            verifySelectBox(6, 6);
        }
    }
}
