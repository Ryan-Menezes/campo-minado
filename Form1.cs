namespace campo_minado
{
    public partial class Form1 : Form
    {
        private Minefield minefield;

        public Form1()
        {
            InitializeComponent();

            minefield = new Minefield([
                [new Cell(0, btn_00), new Cell(0, btn_01), new Cell(0, btn_02), new Cell(0, btn_03), new Cell(0, btn_04), new Cell(0, btn_05), new Cell(0, btn_06)],
                [new Cell(0, btn_10), new Cell(0, btn_11), new Cell(0, btn_12), new Cell(0, btn_13), new Cell(0, btn_14), new Cell(0, btn_15), new Cell(0, btn_16)],
                [new Cell(0, btn_20), new Cell(0, btn_21), new Cell(0, btn_22), new Cell(0, btn_23), new Cell(0, btn_24), new Cell(0, btn_25), new Cell(0, btn_26)],
                [new Cell(0, btn_30), new Cell(0, btn_31), new Cell(0, btn_32), new Cell(0, btn_33), new Cell(0, btn_34), new Cell(0, btn_35), new Cell(0, btn_36)],
                [new Cell(0, btn_40), new Cell(0, btn_41), new Cell(0, btn_42), new Cell(0, btn_43), new Cell(0, btn_44), new Cell(0, btn_45), new Cell(0, btn_46)],
                [new Cell(0, btn_50), new Cell(0, btn_51), new Cell(0, btn_52), new Cell(0, btn_53), new Cell(0, btn_54), new Cell(0, btn_55), new Cell(0, btn_56)],
                [new Cell(0, btn_60), new Cell(0, btn_61), new Cell(0, btn_62), new Cell(0, btn_63), new Cell(0, btn_64), new Cell(0, btn_65), new Cell(0, btn_66)],
            ], Properties.Resources.bomb, txt_time, txt_flags);
        }

        private void timer_game_Tick(object sender, EventArgs e)
        {
            minefield.setTxtTime();
        }

        private void btn_00_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 0);
        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 1);
        }

        private void btn_02_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 2);
        }

        private void btn_03_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 3);
        }

        private void btn_04_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 4);
        }

        private void btn_05_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 5);
        }

        private void btn_06_Click(object sender, EventArgs e)
        {
            minefield.clickCell(0, 6);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 0);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 1);
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 2);
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 3);
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 4);
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 5);
        }

        private void btn_16_Click(object sender, EventArgs e)
        {
            minefield.clickCell(1, 6);
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 0);
        }

        private void btn_21_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 1);
        }

        private void btn_22_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 2);
        }

        private void btn_23_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 3);
        }

        private void btn_24_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 4);
        }

        private void btn_25_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 5);
        }

        private void btn_26_Click(object sender, EventArgs e)
        {
            minefield.clickCell(2, 6);
        }

        private void btn_30_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 0);
        }

        private void btn_31_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 1);
        }

        private void btn_32_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 2);
        }

        private void btn_33_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 3);
        }

        private void btn_34_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 4);
        }

        private void btn_35_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 5);
        }

        private void btn_36_Click(object sender, EventArgs e)
        {
            minefield.clickCell(3, 6);
        }

        private void btn_40_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 0);
        }

        private void btn_41_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 1);
        }

        private void btn_42_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 2);
        }

        private void btn_43_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 3);
        }

        private void btn_44_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 4);
        }

        private void btn_45_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 5);
        }

        private void btn_46_Click(object sender, EventArgs e)
        {
            minefield.clickCell(4, 6);
        }

        private void btn_50_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 0);
        }

        private void btn_51_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 1);
        }

        private void btn_52_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 2);
        }

        private void btn_53_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 3);
        }

        private void btn_54_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 4);
        }

        private void btn_55_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 5);
        }

        private void btn_56_Click(object sender, EventArgs e)
        {
            minefield.clickCell(5, 6);
        }

        private void btn_60_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 0);
        }

        private void btn_61_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 1);
        }

        private void btn_62_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 2);
        }

        private void btn_63_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 3);
        }

        private void btn_64_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 4);
        }

        private void btn_65_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 5);
        }

        private void btn_66_Click(object sender, EventArgs e)
        {
            minefield.clickCell(6, 6);
        }
    }
}
