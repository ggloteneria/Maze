using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

// ReSharper disable LocalizableElement

namespace Labirint {
    public partial class GameForm: Form {
        private bool isUser;

        public bool IsUser {
            get => isUser;
            set {
                if (value) {
                    gbUser.Visible = true;
                    gbAdmin.Visible = false;
                }
                else {
                    gbUser.Visible = false;
                    gbAdmin.Visible = true;
                }

                isUser = value;
            }
        }

        private Theme Theme { get; set; } = new Theme(ThemeKind.SPACE);
        private int CellWidth { get; set; } = 15;
        private int CellHeight { get; set; } = 15;
        private int OddW { get; set; } = 1;
        private int OddH { get; set; } = 1;
        private Maze InMaze { get; set; } = new Maze(10, 10);
        private Bitmap InBm { get; set; } = new Bitmap(1, 1);
        private Point point;

        public GameForm() {
            InitializeComponent();
            basicInit();
            InMaze.Theme = Theme;
        }

        private void basicInit() {
            Theme = new Theme(ThemeKind.SPACE);
            CellWidth = 15;
            CellHeight = 15;
            OddW = 1;
            OddH = 1;
            InMaze = new Maze(10, 10);
            InBm = new Bitmap(1, 1);
            point = new Point();
            setSpeed(1);
            InMaze.Theme = Theme;
            gbPath.Enabled = false;
        }

        private void solveBtn_Click(object sender, EventArgs e) {
            point = new Point(InMaze.start.X, InMaze.start.Y);
            btnStep.Enabled = rbStepByStep.Checked;

            var bm = MazeGui.DrawMaze(
                InBm,
                CellWidth,
                CellHeight,
                InMaze,
                OddW,
                OddH,
                InMaze.Theme);
            picMaze.Image = bm;
            InBm = bm;
            InMaze.path.Clear();
            InMaze.neighbours.Clear();
            InMaze.solve.Clear();
            InMaze.visited.Clear();

            if (rbWaveSearch.Checked) {
                InMaze.SolveWaveMaze();
                MazeGui.DrawWaveSolve(InBm, InMaze, CellWidth);
            }
            else if (rbHandSearch.Checked) {
                solveTimer.Enabled = false;
                InMaze.SolveRightHandMaze();
                for (int i = 0; i < 16; i++) {
                    MazeGui.normalizeVisited(InMaze);
                }
                solveTimer.Enabled = true;
            }
        }


        private void picMaze_Click(object sender, EventArgs e) {
            // ReSharper disable once UsePatternMatching
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null & manuallyRBtn.Checked) {
                int x = mouseEventArgs.X, y = mouseEventArgs.Y;
                ConvertCoordinates(picMaze, out x, out y, x, y);


                InMaze.getBorderCells();
                var click = new Cell(x / CellWidth, y / CellHeight);

                //Находится ли клетка в углу
                if (InMaze.CheckCorner(click)) {
                    MessageBox.Show(
                        "Вход и выход не могут находиться на углах!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                // Подходящая клетка для входа
                else if (InMaze.start.X == 0 & InMaze.start.Y == 0 &
                         !InMaze.cells[click.X, click.Y].IsCell) {

                    var result = MessageBox.Show(
                        "Установить вход?",
                        "Сообщение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes) {
                        InMaze.start.X = click.X;
                        InMaze.start.Y = click.Y;

                    }
                }
                else if (InMaze.start.Equals(click)) {
                    MessageBox.Show(
                        "Вход не может совпадать с выходом!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                else if (MazeGui.AreNeighbours(InMaze.start, click)) {
                    MessageBox.Show(
                        "Вход не может находиться по соседству с выходом!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                // Подходящая клетка для выхода
                else if (InMaze.finish.X == 0 & InMaze.finish.Y == 0 &
                         !InMaze.cells[click.X, click.Y].IsCell
                         & !InMaze.start.Equals(click)) {
                    var result = MessageBox.Show(
                        "Установить выход?",
                        "Сообщение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes) {
                        InMaze.finish.X = click.X;
                        InMaze.finish.Y = click.Y;
                    }
                } else {
                    MessageBox.Show(
                        "Выберите клетки у границ лабиринта!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                    TopMost = true;
                }

                var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, InMaze, OddW,
                    OddH, Theme);
                picMaze.Image = bm;
                InBm = bm;
            }

            else if (!manuallyRBtn.Checked) {
                InMaze.start.X = 0;
                InMaze.start.Y = 0;

                InMaze.finish.X = 0;
                InMaze.finish.Y = 0;

                var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, InMaze, OddW,
                    OddH, Theme);
                picMaze.Image = bm;
                InBm = bm;
            }

        }

        private void createModelBtn_Click(object sender, EventArgs e) {
            int width;
            int height;


            try {
                width = (int)numUpDownWidth.Value;
                height = (int)numUpDownHeight.Value;
                if (!checkEven()) {
                    return;
                }

                if (width != height) {
                    ellerRBtn.Enabled = false;
                    ellerRBtn.Checked = false;
                    primRBtn.Checked = true;
                }
                else {
                    ellerRBtn.Enabled = true;
                }

                if (width == 0 || height == 0) {
                    throw new Exception("Размерность должна быть числом, больше 0.");
                }
            }
            catch (Exception ex) {
                var message = ex.Message;
                const string CAPTION = "Ошибка ввода размерности";
                const MessageBoxButtons BUTTONS = MessageBoxButtons.OK;
                MessageBox.Show(message, CAPTION, BUTTONS);
                numUpDownHeight.Value = 10;
                numUpDownWidth.Value = 10;

                return;
            }


            OddW = 0;
            OddH = 0;

            if (width % 2 != 0) {
                OddW = 1;
            }

            if (height % 2 != 0) {
                OddH = 1;
            }


            CellWidth = picMaze.ClientSize.Width / (width + 2);
            CellHeight = picMaze.ClientSize.Height / (height + 2);

            //Установим минимальный размер ячейки
            const int CELL_MIN = 10;
            if (CellWidth < CELL_MIN) {
                CellWidth = CELL_MIN;
                CellHeight = CellWidth;
            }
            else if (CellHeight < CELL_MIN) {
                CellHeight = CELL_MIN;
                CellWidth = CellHeight;
            }
            else if (CellWidth > CellHeight) CellWidth = CellHeight;
            else CellHeight = CellWidth;


            var maze = new Maze(width, height);


            var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, maze, OddW, OddH,
                Theme);
            picMaze.Image = bm;
            InBm = bm;

            InMaze = maze;

            if (sender != null) {
                startFinishGroupBox.Enabled = true;
                parameterGroupBox.Enabled = false;
                gbTheme.Enabled = false;
            }
        }

        private void randomRBtn_CheckedChanged(object sender, EventArgs e) {
            randomRBtn_CheckedChanged_Impl();
        }

        private void randomRBtn_CheckedChanged_Impl(){
            var rb = randomRBtn;
            if (rb.Checked) {
                // Получаем массив возможных клеток входа и выхода
                var rnd2 = new Random();
                List<Cell> possibleStartFinish = InMaze.getBorderCells();
                int r = rnd2.Next(possibleStartFinish.Count - 1);
                var start = possibleStartFinish[r];
                possibleStartFinish.Remove(start);

                r = rnd2.Next(possibleStartFinish.Count);
                var finish = possibleStartFinish[r];

                InMaze.start.X = start.X;
                InMaze.start.Y = start.Y;
                InMaze.start.IsVisited = true;

                InMaze.finish.X = finish.X;
                InMaze.finish.Y = finish.Y;
                InMaze.finish.IsVisited = true;

                var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, InMaze, OddW,
                    OddH, Theme);
                picMaze.Image = bm;
                InBm = bm;
            }
            else {
                InMaze.start.X = 0;
                InMaze.start.Y = 0;

                InMaze.finish.X = 0;
                InMaze.finish.Y = 0;

                var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, InMaze, OddW,
                    OddH, Theme);
                picMaze.Image = bm;
                InBm = bm;
            }
        }

        private void manuallyRBtn_CheckedChanged(object sender, EventArgs e) {
            var enabled = !manuallyRBtn.Checked;
            setStartFinishBtn.Enabled = enabled;
        }

        private void solveTimer_Tick(object sender, EventArgs e) {
            processTick();
        }

        private void processTick() {
            point.X = InMaze.visited[0].X;
            point.Y = InMaze.visited[0].Y;

            // Отрисовываем посещенные клетки
            if (InMaze.visited.Count != 1) {
                picMaze.Image =
                    MazeGui.DrawDynamic(InBm, InMaze, CellWidth, CellHeight, point, 0, 0);
                InMaze.visited.RemoveAt(0);
            }
            else {
                solveTimer.Enabled = false;
                solveBtn.Enabled = true;
            }
        }

        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        private void showProgramInfo() {
            const string INFO_FILE_PATH = @"..\Resources\Site\Site\справка.html";
            var path = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()),
                INFO_FILE_PATH);
            if (File.Exists(path)) {
                Process.Start(path);
            }
            else {
                MessageBox.Show(
                    "Файл отсутствует или поврежден",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {

            // Сохранить объект в локальном файле.

            var openFileDialog1 = new OpenFileDialog();

            string combinedPath = Path.Combine(Directory.GetCurrentDirectory(),
                @"..\..\Resources\Saved mazes");

            openFileDialog1.InitialDirectory = Path.GetFullPath(combinedPath);
            openFileDialog1.Filter = "Access files (*.lab)|*.lab|Old Access files (*.lab)|*.lab";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            var path = openFileDialog1.FileName;
            var binFormat = new BinaryFormatter();

            try {
                if (CheckFileName(path)) {
                    using (Stream fStream = File.OpenRead(path)) {
                        InMaze = (Maze)binFormat.Deserialize(fStream);

                    }
                }
                else {
                    MessageBox.Show(
                        "Расширение некорректно!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }

                CellWidth = picMaze.ClientSize.Width / (InMaze.width + 2);
                CellHeight = picMaze.ClientSize.Height / (InMaze.height + 2);

                //Установим минимальный размер ячейки
                int cellMin = 10;
                if (CellWidth < cellMin) {
                    CellWidth = cellMin;
                    CellHeight = CellWidth;
                }
                else if (CellHeight < cellMin) {
                    CellHeight = cellMin;
                    CellWidth = CellHeight;
                }
                else if (CellWidth > CellHeight) CellWidth = CellHeight;
                else CellHeight = CellWidth;

                var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, InMaze, OddW,
                    OddH, InMaze.Theme);
                picMaze.Image = bm;
                InBm = bm;

                gbPath.Enabled = true;
                genGroupBox.Enabled = true;
                parameterGroupBox.Enabled = false;
            }
            catch (FileNotFoundException) {
                MessageBox.Show(
                    "Такого файла е существует",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            catch (SerializationException) {
                MessageBox.Show(
                    "Файл поврежден",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {

            var binFormat = new BinaryFormatter();
            // Сохранить объект в локальном файле.

            var openFileDialog1 = new OpenFileDialog();

            string combinedPath = Path.Combine(Directory.GetCurrentDirectory(),
                @"..\..\Resources\Saved mazes");

            openFileDialog1.InitialDirectory = Path.GetFullPath(combinedPath);
            openFileDialog1.Filter = "Access files (*.lab)|*.accdb|Old Access files (*.lab)|*.lab";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.Title = "Сохранить";

            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            var path = openFileDialog1.FileName;
            if (CheckFileName(path)) {
                using (Stream fStream = new FileStream(path,
                           FileMode.Create, FileAccess.Write, FileShare.None)) {
                    binFormat.Serialize(fStream, InMaze);
                }
            }
            else {
                MessageBox.Show(
                    "Расширение некорректно!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

            Show();


        }


        private void setStartFinishBtn_Click(object sender, EventArgs e) {
            manuallyRBtn.Checked = true;
            randomRBtn.Checked = true;
        }

        private void startBtn_Click(object sender, EventArgs e) {
            Start();
        }

        private void infoBtn_Click(object sender, EventArgs e) {
            string info = "Resources\\Site\\справка.html";
            Process.Start(Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()),
                @"..\Resources\Site\Site\справка.html"));
        }

        private void createBtn_Click(object sender, EventArgs e) {


            var maze = new Maze(
                InMaze.width, InMaze.height,
                InMaze.start.X, InMaze.start.Y,
                InMaze.finish.X, InMaze.finish.Y)
            {
                Theme = Theme,
            };

            if (primRBtn.Checked) {
                maze.CreatePrimMaze();
            }
            else if (ellerRBtn.Checked) {
                maze.CreateEllerMaze();
                maze.path.Clear();
            }

            var bm = MazeGui.DrawMaze(InBm, CellWidth, CellHeight, maze, OddW, OddH,
                Theme);
            picMaze.Image = bm;
            InBm = bm;

            InMaze = maze;


        }

        /*
         * Метод для начала новой итерации игры
         */
        private void Start() {
            parameterGroupBox.Enabled = true;
            gbTheme.Enabled = true;

            startFinishGroupBox.Enabled = false;
            genGroupBox.Enabled = false;
            genGroupBox.Enabled = false;

            randomRBtn.Checked = false;
            manuallyRBtn.Checked = false;

            picMaze.Image = null;

            basicInit();
        }

        /*
         * Перевод координат в зависимости от SizeMode изображения
         */
        [SuppressMessage("ReSharper", "PossibleLossOfFraction")]
        private void ConvertCoordinates(PictureBox pic,
            out int x0, out int y0, int x, int y) {
            int picHgt = pic.ClientSize.Height;
            int picWid = pic.ClientSize.Width;
            int imgHgt = pic.Image.Height;
            int imgWid = pic.Image.Width;

            x0 = x;
            y0 = y;
            switch (pic.SizeMode) {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    // These are okay. Leave them alone.
                    break;
                case PictureBoxSizeMode.CenterImage:
                    x0 = x - (picWid - imgWid) / 2;
                    y0 = y - (picHgt - imgHgt) / 2;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    x0 = (int)(imgWid * x / (float)picWid);
                    y0 = (int)(imgHgt * y / (float)picHgt);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float picAspect = picWid / (float)picHgt;
                    float imgAspect = imgWid / (float)imgHgt;
                    if (picAspect > imgAspect) {
                        // The PictureBox is wider/shorter than the image.
                        y0 = (int)(imgHgt * y / (float)picHgt);

                        // The image fills the height of the PictureBox.
                        // Get its width.
                        float scaledWidth = imgWid * picHgt / imgHgt;
                        float dx = (picWid - scaledWidth) / 2;
                        x0 = (int)((x - dx) * imgHgt / picHgt);
                    }
                    else {
                        // The PictureBox is taller/thinner than the image.
                        x0 = (int)(imgWid * x / (float)picWid);

                        // The image fills the height of the PictureBox.
                        // Get its height.
                        float scaledHeight = imgHgt * picWid / imgWid;
                        float dy = (picHgt - scaledHeight) / 2;
                        y0 = (int)((y - dy) * imgWid / picWid);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        /*
         * Метод для проверки расширения файлов
         */
        private static bool CheckFileName(string fileName) {
            string ext = fileName.Substring(fileName.LastIndexOf('.'));
            return ".lab" == ext;
        }

        private void rbForest_CheckedChanged(object sender, EventArgs e) {
            handleThemeChange(sender, e);
        }

        private void rbDesert_CheckedChanged(object sender, EventArgs e) {
            handleThemeChange(sender, e);
        }

        private void rbSpace_CheckedChanged(object sender, EventArgs e) {
            handleThemeChange(sender, e);
        }

        private void rbArctic_CheckedChanged(object sender, EventArgs e) {
            handleThemeChange(sender, e);
        }

        private void handleThemeChange(object sender, EventArgs e) {
            var rb = sender as RadioButton ?? new RadioButton();
            var newTheme = new Theme();
            if (rb.Text.Equals(Theme.Styles[ThemeKind.SPACE])) {
                newTheme = new Theme(ThemeKind.SPACE);
            }
            else if (rb.Text.Equals(Theme.Styles[ThemeKind.ARCTIC])) {
                newTheme = new Theme(ThemeKind.ARCTIC);
            }
            else if (rb.Text.Equals(Theme.Styles[ThemeKind.DESERT])) {
                newTheme = new Theme(ThemeKind.DESERT);
            }
            else if (rb.Text.Equals(Theme.Styles[ThemeKind.FOREST])) {
                newTheme = new Theme(ThemeKind.FOREST);
            }

            Theme = newTheme;
            createModelBtn_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e) {
            saveToolStripMenuItem_Click(null, null);
        }

        private void rbSlow_CheckedChanged(object sender, EventArgs e) {
            setSpeed(1);
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e) {
            setSpeed(2);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            setSpeed(3);
        }

        private void setSpeed(int speed) {
            solveTimer.Interval = 1000 / speed;
        }

        private void rbStepByStep_CheckedChanged(object sender, EventArgs e) {
            gbSpeed.Enabled = false;
            rbSlow.Checked = false;
            rbMedium.Checked = false;
            rbFast.Checked = false;
            setSpeed(5);
        }

        private void rbWithDelay_CheckedChanged(object sender, EventArgs e) {
            gbSpeed.Enabled = true;
            rbSlow.Checked = true;
            setSpeed(1);
        }

        // private void manualSolveRBtn_CheckedChanged(object sender, EventArgs e) {
        //     setManual(true);
        // }
        //
        // private void handRBtn_CheckedChanged(object sender, EventArgs e) {
        //     setManual(false);
        // }
        //
        // private void waveRBtn_CheckedChanged(object sender, EventArgs e) {
        //     setManual(false);
        // }
        //
        // private void setManual(bool isManual) {
        //     if (isManual) {
        //         gbVisualization.Enabled = false;
        //         gbSpeed.Enabled = false;
        //     }
        //     else {
        //         gbVisualization.Enabled = true;
        //         gbSpeed.Enabled = true;
        //     }
        // }

        private void button1_Click(object sender, EventArgs e) {
            showProgramInfo();
        }

        private void button2_Click(object sender, EventArgs e) {
            var devForm = new devInfoForm();
            devForm.Show();
        }

        private void button4_Click_1(object sender, EventArgs e) {
            loadToolStripMenuItem_Click(null, null);
        }

        private void waveRBtn_CheckedChanged(object sender, EventArgs e) {
            toggleSearchVisibility(false);
        }

        private void handRBtn_CheckedChanged(object sender, EventArgs e) {
            toggleSearchVisibility(true);
        }

        private void toggleSearchVisibility(bool visible) {
            rbWithDelay.Enabled = visible;
            rbStepByStep.Enabled = visible;
            rbSlow.Enabled = visible;
            rbFast.Enabled = visible;
            rbMedium.Enabled = visible;
        }

        private void numUpDownHeight_ValueChanged(object sender, EventArgs e) {}

        private void numUpDownWidth_ValueChanged(object sender, EventArgs e) {}

        private bool checkEven() {
            try {
                if ((int)numUpDownHeight.Value % 2 == 0 ||
                    (int)numUpDownWidth.Value % 2 == 0) {
                    MessageBox.Show(
                        "Введенное значение некорректно",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            catch (Exception exception) {
                return false;
            }

            return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (!manuallyRBtn.Checked && !randomRBtn.Checked) {
                return;
            }

            genGroupBox.Enabled = true;
            startFinishGroupBox.Enabled = false;
        }

        private void btnStep_Click(object sender, EventArgs e) {
            processTick();
        }
    }
}