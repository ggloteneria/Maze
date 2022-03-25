namespace Labirint
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.createModelBtn = new System.Windows.Forms.Button();
            this.numUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.setStartFinishBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.picMaze = new System.Windows.Forms.PictureBox();
            this.solveBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rbWaveSearch = new System.Windows.Forms.RadioButton();
            this.rbHandSearch = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.rbStepByStep = new System.Windows.Forms.RadioButton();
            this.rbWithDelay = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.randomRBtn = new System.Windows.Forms.RadioButton();
            this.manuallyRBtn = new System.Windows.Forms.RadioButton();
            this.solveTimer = new System.Windows.Forms.Timer(this.components);
            this.primRBtn = new System.Windows.Forms.RadioButton();
            this.ellerRBtn = new System.Windows.Forms.RadioButton();
            this.genGroupBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.startFinishGroupBox = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.parameterGroupBox = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbTheme = new System.Windows.Forms.GroupBox();
            this.rbSpace = new System.Windows.Forms.RadioButton();
            this.rbArctic = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbForest = new System.Windows.Forms.RadioButton();
            this.rbDesert = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startBtn = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.gbPath = new System.Windows.Forms.GroupBox();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.rbFast = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbSlow = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.gbVisualization = new System.Windows.Forms.GroupBox();
            this.btnStep = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.gbPathAlg = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).BeginInit();
            this.genGroupBox.SuspendLayout();
            this.startFinishGroupBox.SuspendLayout();
            this.parameterGroupBox.SuspendLayout();
            this.gbTheme.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.gbPath.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.gbVisualization.SuspendLayout();
            this.gbPathAlg.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // createModelBtn
            // 
            this.createModelBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.createModelBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.createModelBtn.Location = new System.Drawing.Point(6, 109);
            this.createModelBtn.Name = "createModelBtn";
            this.createModelBtn.Size = new System.Drawing.Size(318, 34);
            this.createModelBtn.TabIndex = 1;
            this.createModelBtn.Text = "Создать макет";
            this.createModelBtn.UseVisualStyleBackColor = false;
            this.createModelBtn.Click += new System.EventHandler(this.createModelBtn_Click);
            // 
            // numUpDownHeight
            // 
            this.numUpDownHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numUpDownHeight.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            this.numUpDownHeight.Location = new System.Drawing.Point(150, 18);
            this.numUpDownHeight.Maximum = new decimal(new int[] { 35, 0, 0, 0 });
            this.numUpDownHeight.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            this.numUpDownHeight.Name = "numUpDownHeight";
            this.numUpDownHeight.Size = new System.Drawing.Size(174, 30);
            this.numUpDownHeight.TabIndex = 3;
            this.numUpDownHeight.Value = new decimal(new int[] { 7, 0, 0, 0 });
            this.numUpDownHeight.ValueChanged += new System.EventHandler(this.numUpDownHeight_ValueChanged);
            // 
            // numUpDownWidth
            // 
            this.numUpDownWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numUpDownWidth.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            this.numUpDownWidth.Location = new System.Drawing.Point(150, 67);
            this.numUpDownWidth.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            this.numUpDownWidth.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
            this.numUpDownWidth.Name = "numUpDownWidth";
            this.numUpDownWidth.Size = new System.Drawing.Size(174, 30);
            this.numUpDownWidth.TabIndex = 4;
            this.numUpDownWidth.Value = new decimal(new int[] { 9, 0, 0, 0 });
            this.numUpDownWidth.ValueChanged += new System.EventHandler(this.numUpDownWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Высота";
            // 
            // setStartFinishBtn
            // 
            this.setStartFinishBtn.BackColor = System.Drawing.SystemColors.Window;
            this.setStartFinishBtn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.setStartFinishBtn.Location = new System.Drawing.Point(6, 81);
            this.setStartFinishBtn.Name = "setStartFinishBtn";
            this.setStartFinishBtn.Size = new System.Drawing.Size(318, 34);
            this.setStartFinishBtn.TabIndex = 10;
            this.setStartFinishBtn.Text = "Расставить";
            this.setStartFinishBtn.UseVisualStyleBackColor = false;
            this.setStartFinishBtn.Click += new System.EventHandler(this.setStartFinishBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.createBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.createBtn.Location = new System.Drawing.Point(6, 69);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(318, 34);
            this.createBtn.TabIndex = 14;
            this.createBtn.Text = "Сгенерировать";
            this.createBtn.UseVisualStyleBackColor = false;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // picMaze
            // 
            this.picMaze.Location = new System.Drawing.Point(382, 19);
            this.picMaze.Name = "picMaze";
            this.picMaze.Size = new System.Drawing.Size(869, 853);
            this.picMaze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMaze.TabIndex = 15;
            this.picMaze.TabStop = false;
            this.picMaze.Click += new System.EventHandler(this.picMaze_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.solveBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.solveBtn.Location = new System.Drawing.Point(6, 406);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(340, 36);
            this.solveBtn.TabIndex = 16;
            this.solveBtn.TabStop = false;
            this.solveBtn.Text = "Найти путь";
            this.solveBtn.UseVisualStyleBackColor = false;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 18;
            // 
            // rbWaveSearch
            // 
            this.rbWaveSearch.AutoSize = true;
            this.rbWaveSearch.Location = new System.Drawing.Point(194, 24);
            this.rbWaveSearch.Name = "rbWaveSearch";
            this.rbWaveSearch.Size = new System.Drawing.Size(93, 21);
            this.rbWaveSearch.TabIndex = 19;
            this.rbWaveSearch.TabStop = true;
            this.rbWaveSearch.Text = "Волновой";
            this.rbWaveSearch.UseVisualStyleBackColor = true;
            this.rbWaveSearch.CheckedChanged += new System.EventHandler(this.waveRBtn_CheckedChanged);
            // 
            // rbHandSearch
            // 
            this.rbHandSearch.AutoSize = true;
            this.rbHandSearch.Location = new System.Drawing.Point(194, 51);
            this.rbHandSearch.Name = "rbHandSearch";
            this.rbHandSearch.Size = new System.Drawing.Size(106, 21);
            this.rbHandSearch.TabIndex = 20;
            this.rbHandSearch.TabStop = true;
            this.rbHandSearch.Text = "Одной руки";
            this.rbHandSearch.UseVisualStyleBackColor = true;
            this.rbHandSearch.CheckedChanged += new System.EventHandler(this.handRBtn_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(539, 566);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 22;
            // 
            // rbStepByStep
            // 
            this.rbStepByStep.AutoSize = true;
            this.rbStepByStep.Location = new System.Drawing.Point(192, 52);
            this.rbStepByStep.Name = "rbStepByStep";
            this.rbStepByStep.Size = new System.Drawing.Size(102, 21);
            this.rbStepByStep.TabIndex = 23;
            this.rbStepByStep.Text = "Пошаговая";
            this.rbStepByStep.UseVisualStyleBackColor = true;
            this.rbStepByStep.CheckedChanged += new System.EventHandler(this.rbStepByStep_CheckedChanged);
            // 
            // rbWithDelay
            // 
            this.rbWithDelay.AutoSize = true;
            this.rbWithDelay.Checked = true;
            this.rbWithDelay.Location = new System.Drawing.Point(192, 25);
            this.rbWithDelay.Name = "rbWithDelay";
            this.rbWithDelay.Size = new System.Drawing.Size(113, 21);
            this.rbWithDelay.TabIndex = 24;
            this.rbWithDelay.TabStop = true;
            this.rbWithDelay.Text = "С задержкой";
            this.rbWithDelay.UseVisualStyleBackColor = true;
            this.rbWithDelay.CheckedChanged += new System.EventHandler(this.rbWithDelay_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(46, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 17);
            this.linkLabel1.TabIndex = 26;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(278, 12);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(0, 17);
            this.linkLabel2.TabIndex = 27;
            // 
            // randomRBtn
            // 
            this.randomRBtn.AutoSize = true;
            this.randomRBtn.Location = new System.Drawing.Point(198, 21);
            this.randomRBtn.Name = "randomRBtn";
            this.randomRBtn.Size = new System.Drawing.Size(130, 21);
            this.randomRBtn.TabIndex = 32;
            this.randomRBtn.Text = "Автоматически";
            this.randomRBtn.UseVisualStyleBackColor = true;
            this.randomRBtn.CheckedChanged += new System.EventHandler(this.randomRBtn_CheckedChanged);
            // 
            // manuallyRBtn
            // 
            this.manuallyRBtn.AutoSize = true;
            this.manuallyRBtn.Location = new System.Drawing.Point(198, 45);
            this.manuallyRBtn.Name = "manuallyRBtn";
            this.manuallyRBtn.Size = new System.Drawing.Size(86, 21);
            this.manuallyRBtn.TabIndex = 33;
            this.manuallyRBtn.Text = "Вручную";
            this.manuallyRBtn.UseVisualStyleBackColor = true;
            this.manuallyRBtn.CheckedChanged += new System.EventHandler(this.manuallyRBtn_CheckedChanged);
            // 
            // solveTimer
            // 
            this.solveTimer.Interval = 500;
            this.solveTimer.Tick += new System.EventHandler(this.solveTimer_Tick);
            // 
            // primRBtn
            // 
            this.primRBtn.AutoSize = true;
            this.primRBtn.Location = new System.Drawing.Point(186, 39);
            this.primRBtn.Name = "primRBtn";
            this.primRBtn.Size = new System.Drawing.Size(138, 21);
            this.primRBtn.TabIndex = 36;
            this.primRBtn.Text = "Алгоритм Прима";
            this.primRBtn.UseVisualStyleBackColor = true;
            // 
            // ellerRBtn
            // 
            this.ellerRBtn.AutoSize = true;
            this.ellerRBtn.Checked = true;
            this.ellerRBtn.Location = new System.Drawing.Point(186, 18);
            this.ellerRBtn.Name = "ellerRBtn";
            this.ellerRBtn.Size = new System.Drawing.Size(144, 21);
            this.ellerRBtn.TabIndex = 37;
            this.ellerRBtn.TabStop = true;
            this.ellerRBtn.Text = "Алгоритм Эллера";
            this.ellerRBtn.UseVisualStyleBackColor = true;
            // 
            // genGroupBox
            // 
            this.genGroupBox.Controls.Add(this.label11);
            this.genGroupBox.Controls.Add(this.primRBtn);
            this.genGroupBox.Controls.Add(this.ellerRBtn);
            this.genGroupBox.Controls.Add(this.createBtn);
            this.genGroupBox.Enabled = false;
            this.genGroupBox.Location = new System.Drawing.Point(11, 509);
            this.genGroupBox.Name = "genGroupBox";
            this.genGroupBox.Size = new System.Drawing.Size(336, 117);
            this.genGroupBox.TabIndex = 38;
            this.genGroupBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 42);
            this.label11.TabIndex = 35;
            this.label11.Text = "Алгоритм генерации лабиринта:";
            // 
            // startFinishGroupBox
            // 
            this.startFinishGroupBox.Controls.Add(this.btnConfirm);
            this.startFinishGroupBox.Controls.Add(this.label10);
            this.startFinishGroupBox.Controls.Add(this.randomRBtn);
            this.startFinishGroupBox.Controls.Add(this.manuallyRBtn);
            this.startFinishGroupBox.Controls.Add(this.setStartFinishBtn);
            this.startFinishGroupBox.Enabled = false;
            this.startFinishGroupBox.Location = new System.Drawing.Point(11, 323);
            this.startFinishGroupBox.Name = "startFinishGroupBox";
            this.startFinishGroupBox.Size = new System.Drawing.Size(336, 180);
            this.startFinishGroupBox.TabIndex = 39;
            this.startFinishGroupBox.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConfirm.Location = new System.Drawing.Point(5, 139);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(318, 34);
            this.btnConfirm.TabIndex = 35;
            this.btnConfirm.Text = "Подтвердить";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(10, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 42);
            this.label10.TabIndex = 34;
            this.label10.Text = "Расстановка входа и выхода:";
            // 
            // parameterGroupBox
            // 
            this.parameterGroupBox.Controls.Add(this.label9);
            this.parameterGroupBox.Controls.Add(this.label2);
            this.parameterGroupBox.Controls.Add(this.label8);
            this.parameterGroupBox.Controls.Add(this.label1);
            this.parameterGroupBox.Controls.Add(this.numUpDownHeight);
            this.parameterGroupBox.Controls.Add(this.numUpDownWidth);
            this.parameterGroupBox.Controls.Add(this.createModelBtn);
            this.parameterGroupBox.Location = new System.Drawing.Point(11, 66);
            this.parameterGroupBox.Name = "parameterGroupBox";
            this.parameterGroupBox.Size = new System.Drawing.Size(336, 161);
            this.parameterGroupBox.TabIndex = 40;
            this.parameterGroupBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "от 9 до 45 клеток";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "Ширина";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 42;
            this.label8.Text = "от 7 до 35 клеток";
            // 
            // gbTheme
            // 
            this.gbTheme.Controls.Add(this.rbSpace);
            this.gbTheme.Controls.Add(this.rbArctic);
            this.gbTheme.Controls.Add(this.label3);
            this.gbTheme.Controls.Add(this.rbForest);
            this.gbTheme.Controls.Add(this.rbDesert);
            this.gbTheme.Location = new System.Drawing.Point(11, 233);
            this.gbTheme.Name = "gbTheme";
            this.gbTheme.Size = new System.Drawing.Size(336, 84);
            this.gbTheme.TabIndex = 12;
            this.gbTheme.TabStop = false;
            // 
            // rbSpace
            // 
            this.rbSpace.BackColor = System.Drawing.SystemColors.Control;
            this.rbSpace.Checked = true;
            this.rbSpace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbSpace.Location = new System.Drawing.Point(83, 41);
            this.rbSpace.Name = "rbSpace";
            this.rbSpace.Size = new System.Drawing.Size(97, 29);
            this.rbSpace.TabIndex = 10;
            this.rbSpace.TabStop = true;
            this.rbSpace.Text = "Космос";
            this.rbSpace.UseVisualStyleBackColor = false;
            this.rbSpace.CheckedChanged += new System.EventHandler(this.rbSpace_CheckedChanged);
            // 
            // rbArctic
            // 
            this.rbArctic.Location = new System.Drawing.Point(190, 41);
            this.rbArctic.Name = "rbArctic";
            this.rbArctic.Size = new System.Drawing.Size(119, 29);
            this.rbArctic.TabIndex = 11;
            this.rbArctic.Text = "Антарктида";
            this.rbArctic.UseVisualStyleBackColor = true;
            this.rbArctic.CheckedChanged += new System.EventHandler(this.rbArctic_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Тема:";
            // 
            // rbForest
            // 
            this.rbForest.Location = new System.Drawing.Point(83, 14);
            this.rbForest.Name = "rbForest";
            this.rbForest.Size = new System.Drawing.Size(97, 29);
            this.rbForest.TabIndex = 8;
            this.rbForest.Text = "Лес";
            this.rbForest.UseVisualStyleBackColor = true;
            this.rbForest.CheckedChanged += new System.EventHandler(this.rbForest_CheckedChanged);
            // 
            // rbDesert
            // 
            this.rbDesert.Location = new System.Drawing.Point(190, 14);
            this.rbDesert.Name = "rbDesert";
            this.rbDesert.Size = new System.Drawing.Size(119, 29);
            this.rbDesert.TabIndex = 9;
            this.rbDesert.Text = "Пустыня";
            this.rbDesert.UseVisualStyleBackColor = true;
            this.rbDesert.CheckedChanged += new System.EventHandler(this.rbDesert_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Firebrick;
            this.startBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.startBtn.Location = new System.Drawing.Point(16, 768);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(319, 32);
            this.startBtn.TabIndex = 37;
            this.startBtn.TabStop = false;
            this.startBtn.Text = "Сбросить";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.startBtn);
            this.gbAdmin.Controls.Add(this.button3);
            this.gbAdmin.Controls.Add(this.gbTheme);
            this.gbAdmin.Controls.Add(this.label5);
            this.gbAdmin.Controls.Add(this.parameterGroupBox);
            this.gbAdmin.Controls.Add(this.startFinishGroupBox);
            this.gbAdmin.Controls.Add(this.genGroupBox);
            this.gbAdmin.Location = new System.Drawing.Point(18, 19);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(357, 853);
            this.gbAdmin.TabIndex = 44;
            this.gbAdmin.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.SystemColors.Window;
            this.button3.Location = new System.Drawing.Point(16, 806);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(319, 34);
            this.button3.TabIndex = 38;
            this.button3.Text = "Сохранить в файл";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(341, 45);
            this.label5.TabIndex = 2;
            this.label5.Text = "Параметры лабиринта";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(18, 891);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 74);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(732, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "Информация о разработчиках";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1019, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Информация о системе";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.gbPath);
            this.gbUser.Controls.Add(this.groupBox4);
            this.gbUser.Location = new System.Drawing.Point(11, 19);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(364, 835);
            this.gbUser.TabIndex = 46;
            this.gbUser.TabStop = false;
            // 
            // gbPath
            // 
            this.gbPath.Controls.Add(this.gbSpeed);
            this.gbPath.Controls.Add(this.solveBtn);
            this.gbPath.Controls.Add(this.gbVisualization);
            this.gbPath.Controls.Add(this.gbPathAlg);
            this.gbPath.Controls.Add(this.label12);
            this.gbPath.Location = new System.Drawing.Point(6, 139);
            this.gbPath.Name = "gbPath";
            this.gbPath.Size = new System.Drawing.Size(352, 683);
            this.gbPath.TabIndex = 1;
            this.gbPath.TabStop = false;
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.rbFast);
            this.gbSpeed.Controls.Add(this.rbMedium);
            this.gbSpeed.Controls.Add(this.rbSlow);
            this.gbSpeed.Controls.Add(this.label15);
            this.gbSpeed.Location = new System.Drawing.Point(5, 283);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(339, 117);
            this.gbSpeed.TabIndex = 48;
            this.gbSpeed.TabStop = false;
            // 
            // rbFast
            // 
            this.rbFast.Location = new System.Drawing.Point(192, 79);
            this.rbFast.Name = "rbFast";
            this.rbFast.Size = new System.Drawing.Size(122, 31);
            this.rbFast.TabIndex = 50;
            this.rbFast.Text = "Быстро";
            this.rbFast.UseVisualStyleBackColor = true;
            this.rbFast.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbMedium
            // 
            this.rbMedium.Location = new System.Drawing.Point(192, 50);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(122, 31);
            this.rbMedium.TabIndex = 49;
            this.rbMedium.Text = "Средне";
            this.rbMedium.UseVisualStyleBackColor = true;
            this.rbMedium.CheckedChanged += new System.EventHandler(this.rbMedium_CheckedChanged);
            // 
            // rbSlow
            // 
            this.rbSlow.Checked = true;
            this.rbSlow.Location = new System.Drawing.Point(192, 20);
            this.rbSlow.Name = "rbSlow";
            this.rbSlow.Size = new System.Drawing.Size(122, 31);
            this.rbSlow.TabIndex = 48;
            this.rbSlow.TabStop = true;
            this.rbSlow.Text = "Медленно";
            this.rbSlow.UseVisualStyleBackColor = true;
            this.rbSlow.CheckedChanged += new System.EventHandler(this.rbSlow_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(163, 63);
            this.label15.TabIndex = 47;
            this.label15.Text = "Скорость перемещения персонажа:";
            // 
            // gbVisualization
            // 
            this.gbVisualization.Controls.Add(this.btnStep);
            this.gbVisualization.Controls.Add(this.rbStepByStep);
            this.gbVisualization.Controls.Add(this.label14);
            this.gbVisualization.Controls.Add(this.rbWithDelay);
            this.gbVisualization.Location = new System.Drawing.Point(5, 130);
            this.gbVisualization.Name = "gbVisualization";
            this.gbVisualization.Size = new System.Drawing.Size(339, 147);
            this.gbVisualization.TabIndex = 47;
            this.gbVisualization.TabStop = false;
            // 
            // btnStep
            // 
            this.btnStep.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnStep.Enabled = false;
            this.btnStep.ForeColor = System.Drawing.SystemColors.Window;
            this.btnStep.Location = new System.Drawing.Point(0, 102);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(340, 36);
            this.btnStep.TabIndex = 49;
            this.btnStep.TabStop = false;
            this.btnStep.Text = "Шаг";
            this.btnStep.UseVisualStyleBackColor = false;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 42);
            this.label14.TabIndex = 46;
            this.label14.Text = "Динамическая визуализация:";
            // 
            // gbPathAlg
            // 
            this.gbPathAlg.Controls.Add(this.rbWaveSearch);
            this.gbPathAlg.Controls.Add(this.label13);
            this.gbPathAlg.Controls.Add(this.rbHandSearch);
            this.gbPathAlg.Location = new System.Drawing.Point(5, 42);
            this.gbPathAlg.Name = "gbPathAlg";
            this.gbPathAlg.Size = new System.Drawing.Size(341, 82);
            this.gbPathAlg.TabIndex = 46;
            this.gbPathAlg.TabStop = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 20);
            this.label13.TabIndex = 45;
            this.label13.Text = "Алгоритм поиска пути:";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label12.Location = new System.Drawing.Point(6, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(340, 34);
            this.label12.TabIndex = 43;
            this.label12.Text = "Поиск пути:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(6, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 124);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Window;
            this.button4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button4.Location = new System.Drawing.Point(96, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 38);
            this.button4.TabIndex = 42;
            this.button4.Text = "Выбрать";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(340, 31);
            this.label4.TabIndex = 41;
            this.label4.Text = "Выбрать файл с лабиринтом:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 977);
            this.Controls.Add(this.gbUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAdmin);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picMaze);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабиринт - Администратор";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).EndInit();
            this.genGroupBox.ResumeLayout(false);
            this.genGroupBox.PerformLayout();
            this.startFinishGroupBox.ResumeLayout(false);
            this.startFinishGroupBox.PerformLayout();
            this.parameterGroupBox.ResumeLayout(false);
            this.parameterGroupBox.PerformLayout();
            this.gbTheme.ResumeLayout(false);
            this.gbTheme.PerformLayout();
            this.gbAdmin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbUser.ResumeLayout(false);
            this.gbPath.ResumeLayout(false);
            this.gbSpeed.ResumeLayout(false);
            this.gbVisualization.ResumeLayout(false);
            this.gbVisualization.PerformLayout();
            this.gbPathAlg.ResumeLayout(false);
            this.gbPathAlg.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnStep;

        private System.Windows.Forms.Button btnConfirm;

        private System.Windows.Forms.RadioButton rbWithDelay;

        private System.Windows.Forms.GroupBox gbPathAlg;

        private System.Windows.Forms.RadioButton rbMedium;

        private System.Windows.Forms.RadioButton rbSlow;

        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.GroupBox gbSpeed;

        private System.Windows.Forms.Label label14;

        private System.Windows.Forms.GroupBox gbVisualization;

        private System.Windows.Forms.Label label13;

        private System.Windows.Forms.GroupBox gbPath;
        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.GroupBox gbTheme;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.RadioButton rbForest;
        private System.Windows.Forms.RadioButton rbDesert;
        private System.Windows.Forms.RadioButton rbArctic;

        private System.Windows.Forms.GroupBox gbUser;

        private System.Windows.Forms.RadioButton rbSpace;

        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;

        private System.Windows.Forms.RadioButton rbAverage;
        private System.Windows.Forms.RadioButton rbFast;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.GroupBox gbAdmin;
        #endregion
        private System.Windows.Forms.Button createModelBtn;
        private System.Windows.Forms.NumericUpDown numUpDownHeight;
        private System.Windows.Forms.NumericUpDown numUpDownWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setStartFinishBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.PictureBox picMaze;
        private System.Windows.Forms.Button solveBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbWaveSearch;
        private System.Windows.Forms.RadioButton rbHandSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbStepByStep;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.RadioButton randomRBtn;
        private System.Windows.Forms.RadioButton manuallyRBtn;
        private System.Windows.Forms.Timer solveTimer;
        private System.Windows.Forms.RadioButton primRBtn;
        private System.Windows.Forms.RadioButton ellerRBtn;
        private System.Windows.Forms.GroupBox genGroupBox;
        private System.Windows.Forms.GroupBox startFinishGroupBox;
        private System.Windows.Forms.GroupBox parameterGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button startBtn;
    }
}

