namespace Switch_Controller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Connect = new Button();
            ipaddress = new TextBox();
            controllerPanel = new Panel();
            HomeBtn = new Button();
            caputureBtn = new Button();
            plusBtn = new Button();
            minusBtn = new Button();
            RBtn = new Button();
            LBtn = new Button();
            ZLBtn = new Button();
            DetachBtn = new Button();
            ZRBtn = new Button();
            DrightBtn = new Button();
            DleftBtn = new Button();
            DdownBtn = new Button();
            DupBtn = new Button();
            RightStickBtn = new Button();
            RstickRIGHTBtn = new Button();
            RstickLEFTBtn = new Button();
            RstickDOWNBtn = new Button();
            RstickUPBtn = new Button();
            LeftStickBtn = new Button();
            ABtn = new Button();
            YBtn = new Button();
            BBtn = new Button();
            XBtn = new Button();
            LstickRIGHTBtn = new Button();
            LstickLEFTBtn = new Button();
            LstickDOWNBtn = new Button();
            LstickUPBtn = new Button();
            controllertimer = new System.Windows.Forms.Timer(components);
            controllerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Connect
            // 
            Connect.BackColor = SystemColors.ActiveCaptionText;
            Connect.ForeColor = SystemColors.ControlLightLight;
            Connect.Location = new Point(241, 12);
            Connect.Name = "Connect";
            Connect.Size = new Size(75, 23);
            Connect.TabIndex = 1;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = false;
            Connect.Click += Connect_Click;
            // 
            // ipaddress
            // 
            ipaddress.Location = new Point(12, 12);
            ipaddress.Name = "ipaddress";
            ipaddress.Size = new Size(214, 23);
            ipaddress.TabIndex = 2;
            // 
            // controllerPanel
            // 
            controllerPanel.BackColor = SystemColors.ActiveCaptionText;
            controllerPanel.Controls.Add(HomeBtn);
            controllerPanel.Controls.Add(caputureBtn);
            controllerPanel.Controls.Add(plusBtn);
            controllerPanel.Controls.Add(minusBtn);
            controllerPanel.Controls.Add(RBtn);
            controllerPanel.Controls.Add(LBtn);
            controllerPanel.Controls.Add(ZLBtn);
            controllerPanel.Controls.Add(DetachBtn);
            controllerPanel.Controls.Add(ZRBtn);
            controllerPanel.Controls.Add(DrightBtn);
            controllerPanel.Controls.Add(DleftBtn);
            controllerPanel.Controls.Add(DdownBtn);
            controllerPanel.Controls.Add(DupBtn);
            controllerPanel.Controls.Add(RightStickBtn);
            controllerPanel.Controls.Add(RstickRIGHTBtn);
            controllerPanel.Controls.Add(RstickLEFTBtn);
            controllerPanel.Controls.Add(RstickDOWNBtn);
            controllerPanel.Controls.Add(RstickUPBtn);
            controllerPanel.Controls.Add(LeftStickBtn);
            controllerPanel.Controls.Add(ABtn);
            controllerPanel.Controls.Add(YBtn);
            controllerPanel.Controls.Add(BBtn);
            controllerPanel.Controls.Add(XBtn);
            controllerPanel.Controls.Add(LstickRIGHTBtn);
            controllerPanel.Controls.Add(LstickLEFTBtn);
            controllerPanel.Controls.Add(LstickDOWNBtn);
            controllerPanel.Controls.Add(LstickUPBtn);
            controllerPanel.ForeColor = SystemColors.ButtonHighlight;
            controllerPanel.Location = new Point(41, 72);
            controllerPanel.Name = "controllerPanel";
            controllerPanel.Size = new Size(456, 88);
            controllerPanel.TabIndex = 318;
            // 
            // HomeBtn
            // 
            HomeBtn.BackColor = Color.FromArgb(114, 137, 218);
            HomeBtn.FlatAppearance.BorderSize = 0;
            HomeBtn.FlatStyle = FlatStyle.Flat;
            HomeBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            HomeBtn.ForeColor = Color.White;
            HomeBtn.Location = new Point(287, 46);
            HomeBtn.Margin = new Padding(4);
            HomeBtn.Name = "HomeBtn";
            HomeBtn.Size = new Size(20, 20);
            HomeBtn.TabIndex = 338;
            HomeBtn.Text = "🏠";
            HomeBtn.UseVisualStyleBackColor = false;
            HomeBtn.Click += HomeBtn_Click;
            // 
            // caputureBtn
            // 
            caputureBtn.BackColor = Color.FromArgb(114, 137, 218);
            caputureBtn.FlatAppearance.BorderSize = 0;
            caputureBtn.FlatStyle = FlatStyle.Flat;
            caputureBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            caputureBtn.ForeColor = Color.White;
            caputureBtn.Location = new Point(140, 46);
            caputureBtn.Margin = new Padding(4);
            caputureBtn.Name = "caputureBtn";
            caputureBtn.Size = new Size(20, 20);
            caputureBtn.TabIndex = 337;
            caputureBtn.Text = "⏺️";
            caputureBtn.UseVisualStyleBackColor = false;
            caputureBtn.Click += caputureBtn_Click;
            // 
            // plusBtn
            // 
            plusBtn.BackColor = Color.FromArgb(114, 137, 218);
            plusBtn.FlatAppearance.BorderSize = 0;
            plusBtn.FlatStyle = FlatStyle.Flat;
            plusBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            plusBtn.ForeColor = Color.White;
            plusBtn.Location = new Point(266, 25);
            plusBtn.Margin = new Padding(4);
            plusBtn.Name = "plusBtn";
            plusBtn.Size = new Size(20, 20);
            plusBtn.TabIndex = 336;
            plusBtn.Text = "➕";
            plusBtn.UseVisualStyleBackColor = false;
            plusBtn.Click += plusBtn_Click;
            // 
            // minusBtn
            // 
            minusBtn.BackColor = Color.FromArgb(114, 137, 218);
            minusBtn.FlatAppearance.BorderSize = 0;
            minusBtn.FlatStyle = FlatStyle.Flat;
            minusBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            minusBtn.ForeColor = Color.White;
            minusBtn.Location = new Point(161, 25);
            minusBtn.Margin = new Padding(4);
            minusBtn.Name = "minusBtn";
            minusBtn.Size = new Size(20, 20);
            minusBtn.TabIndex = 335;
            minusBtn.Text = "➖";
            minusBtn.UseVisualStyleBackColor = false;
            minusBtn.Click += minusBtn_Click;
            // 
            // RBtn
            // 
            RBtn.BackColor = Color.FromArgb(114, 137, 218);
            RBtn.FlatAppearance.BorderSize = 0;
            RBtn.FlatStyle = FlatStyle.Flat;
            RBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            RBtn.ForeColor = Color.White;
            RBtn.Location = new Point(266, 4);
            RBtn.Margin = new Padding(4);
            RBtn.Name = "RBtn";
            RBtn.Size = new Size(20, 20);
            RBtn.TabIndex = 334;
            RBtn.Text = "R";
            RBtn.UseVisualStyleBackColor = false;
            RBtn.Click += RBtn_Click;
            // 
            // LBtn
            // 
            LBtn.BackColor = Color.FromArgb(114, 137, 218);
            LBtn.FlatAppearance.BorderSize = 0;
            LBtn.FlatStyle = FlatStyle.Flat;
            LBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            LBtn.ForeColor = Color.White;
            LBtn.Location = new Point(161, 4);
            LBtn.Margin = new Padding(4);
            LBtn.Name = "LBtn";
            LBtn.Size = new Size(20, 20);
            LBtn.TabIndex = 333;
            LBtn.Text = "L";
            LBtn.UseVisualStyleBackColor = false;
            LBtn.Click += LBtn_Click;
            // 
            // ZLBtn
            // 
            ZLBtn.BackColor = Color.FromArgb(114, 137, 218);
            ZLBtn.FlatAppearance.BorderSize = 0;
            ZLBtn.FlatStyle = FlatStyle.Flat;
            ZLBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            ZLBtn.ForeColor = Color.White;
            ZLBtn.Location = new Point(130, 4);
            ZLBtn.Margin = new Padding(0);
            ZLBtn.Name = "ZLBtn";
            ZLBtn.Size = new Size(30, 20);
            ZLBtn.TabIndex = 332;
            ZLBtn.Text = "ZL";
            ZLBtn.TextImageRelation = TextImageRelation.TextAboveImage;
            ZLBtn.UseVisualStyleBackColor = false;
            ZLBtn.Click += ZLBtn_Click;
            // 
            // DetachBtn
            // 
            DetachBtn.BackColor = Color.FromArgb(114, 137, 218);
            DetachBtn.FlatAppearance.BorderSize = 0;
            DetachBtn.FlatStyle = FlatStyle.Flat;
            DetachBtn.Font = new Font("Arial", 8F, FontStyle.Bold);
            DetachBtn.ForeColor = Color.White;
            DetachBtn.Location = new Point(188, 64);
            DetachBtn.Margin = new Padding(4);
            DetachBtn.Name = "DetachBtn";
            DetachBtn.Size = new Size(69, 20);
            DetachBtn.TabIndex = 325;
            DetachBtn.Text = "Detach";
            DetachBtn.UseVisualStyleBackColor = false;
            DetachBtn.Click += DetachBtn_Click;
            // 
            // ZRBtn
            // 
            ZRBtn.BackColor = Color.FromArgb(114, 137, 218);
            ZRBtn.FlatAppearance.BorderSize = 0;
            ZRBtn.FlatStyle = FlatStyle.Flat;
            ZRBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            ZRBtn.ForeColor = Color.White;
            ZRBtn.Location = new Point(287, 4);
            ZRBtn.Margin = new Padding(0);
            ZRBtn.Name = "ZRBtn";
            ZRBtn.Size = new Size(30, 20);
            ZRBtn.TabIndex = 331;
            ZRBtn.Text = "ZR";
            ZRBtn.UseVisualStyleBackColor = false;
            ZRBtn.Click += ZRBtn_Click;
            // 
            // DrightBtn
            // 
            DrightBtn.BackColor = Color.FromArgb(114, 137, 218);
            DrightBtn.FlatAppearance.BorderSize = 0;
            DrightBtn.FlatStyle = FlatStyle.Flat;
            DrightBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            DrightBtn.ForeColor = Color.White;
            DrightBtn.Location = new Point(112, 25);
            DrightBtn.Margin = new Padding(4);
            DrightBtn.Name = "DrightBtn";
            DrightBtn.Size = new Size(20, 20);
            DrightBtn.TabIndex = 330;
            DrightBtn.Text = "🠊";
            DrightBtn.UseVisualStyleBackColor = false;
            DrightBtn.Click += DrightBtn_Click;
            // 
            // DleftBtn
            // 
            DleftBtn.BackColor = Color.FromArgb(114, 137, 218);
            DleftBtn.FlatAppearance.BorderSize = 0;
            DleftBtn.FlatStyle = FlatStyle.Flat;
            DleftBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            DleftBtn.ForeColor = Color.White;
            DleftBtn.Location = new Point(70, 25);
            DleftBtn.Margin = new Padding(4);
            DleftBtn.Name = "DleftBtn";
            DleftBtn.Size = new Size(20, 20);
            DleftBtn.TabIndex = 329;
            DleftBtn.Text = "🠈";
            DleftBtn.UseVisualStyleBackColor = false;
            DleftBtn.Click += DleftBtn_Click;
            // 
            // DdownBtn
            // 
            DdownBtn.BackColor = Color.FromArgb(114, 137, 218);
            DdownBtn.FlatAppearance.BorderSize = 0;
            DdownBtn.FlatStyle = FlatStyle.Flat;
            DdownBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            DdownBtn.ForeColor = Color.White;
            DdownBtn.Location = new Point(91, 46);
            DdownBtn.Margin = new Padding(4);
            DdownBtn.Name = "DdownBtn";
            DdownBtn.Size = new Size(20, 20);
            DdownBtn.TabIndex = 328;
            DdownBtn.Text = "🠋";
            DdownBtn.UseVisualStyleBackColor = false;
            DdownBtn.Click += DdownBtn_Click;
            // 
            // DupBtn
            // 
            DupBtn.BackColor = Color.FromArgb(114, 137, 218);
            DupBtn.FlatAppearance.BorderSize = 0;
            DupBtn.FlatStyle = FlatStyle.Flat;
            DupBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            DupBtn.ForeColor = Color.White;
            DupBtn.Location = new Point(91, 4);
            DupBtn.Margin = new Padding(4);
            DupBtn.Name = "DupBtn";
            DupBtn.Size = new Size(20, 20);
            DupBtn.TabIndex = 327;
            DupBtn.Text = "🠉";
            DupBtn.UseVisualStyleBackColor = false;
            DupBtn.Click += DupBtn_Click;
            // 
            // RightStickBtn
            // 
            RightStickBtn.BackColor = Color.FromArgb(114, 137, 218);
            RightStickBtn.FlatAppearance.BorderSize = 0;
            RightStickBtn.FlatStyle = FlatStyle.Flat;
            RightStickBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            RightStickBtn.ForeColor = Color.White;
            RightStickBtn.Location = new Point(403, 25);
            RightStickBtn.Margin = new Padding(4);
            RightStickBtn.Name = "RightStickBtn";
            RightStickBtn.Size = new Size(20, 20);
            RightStickBtn.TabIndex = 326;
            RightStickBtn.Text = "⚪";
            RightStickBtn.UseVisualStyleBackColor = false;
            RightStickBtn.Click += RightStickBtn_Click;
            // 
            // RstickRIGHTBtn
            // 
            RstickRIGHTBtn.BackColor = Color.FromArgb(114, 137, 218);
            RstickRIGHTBtn.FlatAppearance.BorderSize = 0;
            RstickRIGHTBtn.FlatStyle = FlatStyle.Flat;
            RstickRIGHTBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            RstickRIGHTBtn.ForeColor = Color.White;
            RstickRIGHTBtn.Location = new Point(424, 25);
            RstickRIGHTBtn.Margin = new Padding(4);
            RstickRIGHTBtn.Name = "RstickRIGHTBtn";
            RstickRIGHTBtn.Size = new Size(20, 20);
            RstickRIGHTBtn.TabIndex = 325;
            RstickRIGHTBtn.Text = "🠊";
            RstickRIGHTBtn.UseVisualStyleBackColor = false;
            RstickRIGHTBtn.MouseDown += RstickRIGHTBtn_MouseDown;
            RstickRIGHTBtn.MouseUp += RstickMouseUp;
            // 
            // RstickLEFTBtn
            // 
            RstickLEFTBtn.BackColor = Color.FromArgb(114, 137, 218);
            RstickLEFTBtn.FlatAppearance.BorderSize = 0;
            RstickLEFTBtn.FlatStyle = FlatStyle.Flat;
            RstickLEFTBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            RstickLEFTBtn.ForeColor = Color.White;
            RstickLEFTBtn.Location = new Point(382, 25);
            RstickLEFTBtn.Margin = new Padding(4);
            RstickLEFTBtn.Name = "RstickLEFTBtn";
            RstickLEFTBtn.Size = new Size(20, 20);
            RstickLEFTBtn.TabIndex = 324;
            RstickLEFTBtn.Text = "🠈";
            RstickLEFTBtn.UseVisualStyleBackColor = false;
            RstickLEFTBtn.MouseDown += RstickLEFTBtn_MouseDown;
            RstickLEFTBtn.MouseUp += RstickMouseUp;
            // 
            // RstickDOWNBtn
            // 
            RstickDOWNBtn.BackColor = Color.FromArgb(114, 137, 218);
            RstickDOWNBtn.FlatAppearance.BorderSize = 0;
            RstickDOWNBtn.FlatStyle = FlatStyle.Flat;
            RstickDOWNBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            RstickDOWNBtn.ForeColor = Color.White;
            RstickDOWNBtn.Location = new Point(403, 46);
            RstickDOWNBtn.Margin = new Padding(4);
            RstickDOWNBtn.Name = "RstickDOWNBtn";
            RstickDOWNBtn.Size = new Size(20, 20);
            RstickDOWNBtn.TabIndex = 323;
            RstickDOWNBtn.Text = "🠋";
            RstickDOWNBtn.UseVisualStyleBackColor = false;
            RstickDOWNBtn.MouseDown += RstickDOWNBtn_MouseDown;
            RstickDOWNBtn.MouseUp += RstickMouseUp;
            // 
            // RstickUPBtn
            // 
            RstickUPBtn.BackColor = Color.FromArgb(114, 137, 218);
            RstickUPBtn.FlatAppearance.BorderSize = 0;
            RstickUPBtn.FlatStyle = FlatStyle.Flat;
            RstickUPBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            RstickUPBtn.ForeColor = Color.White;
            RstickUPBtn.Location = new Point(403, 4);
            RstickUPBtn.Margin = new Padding(4);
            RstickUPBtn.Name = "RstickUPBtn";
            RstickUPBtn.Size = new Size(20, 20);
            RstickUPBtn.TabIndex = 322;
            RstickUPBtn.Text = "🠉";
            RstickUPBtn.UseVisualStyleBackColor = false;
            RstickUPBtn.MouseDown += RstickUPBtn_MouseDown;
            RstickUPBtn.MouseUp += RstickMouseUp;
            // 
            // LeftStickBtn
            // 
            LeftStickBtn.BackColor = Color.FromArgb(114, 137, 218);
            LeftStickBtn.FlatAppearance.BorderSize = 0;
            LeftStickBtn.FlatStyle = FlatStyle.Flat;
            LeftStickBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            LeftStickBtn.ForeColor = Color.White;
            LeftStickBtn.Location = new Point(24, 25);
            LeftStickBtn.Margin = new Padding(4);
            LeftStickBtn.Name = "LeftStickBtn";
            LeftStickBtn.Size = new Size(20, 20);
            LeftStickBtn.TabIndex = 321;
            LeftStickBtn.Text = "⚪";
            LeftStickBtn.UseVisualStyleBackColor = false;
            LeftStickBtn.Click += LeftStickBtn_Click;
            // 
            // ABtn
            // 
            ABtn.BackColor = Color.FromArgb(114, 137, 218);
            ABtn.FlatAppearance.BorderSize = 0;
            ABtn.FlatStyle = FlatStyle.Flat;
            ABtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            ABtn.ForeColor = Color.White;
            ABtn.Location = new Point(357, 25);
            ABtn.Margin = new Padding(4);
            ABtn.Name = "ABtn";
            ABtn.Size = new Size(20, 20);
            ABtn.TabIndex = 320;
            ABtn.Text = "A";
            ABtn.UseVisualStyleBackColor = false;
            ABtn.Click += ABtn_Click;
            // 
            // YBtn
            // 
            YBtn.BackColor = Color.FromArgb(114, 137, 218);
            YBtn.FlatAppearance.BorderSize = 0;
            YBtn.FlatStyle = FlatStyle.Flat;
            YBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            YBtn.ForeColor = Color.White;
            YBtn.Location = new Point(315, 25);
            YBtn.Margin = new Padding(4);
            YBtn.Name = "YBtn";
            YBtn.Size = new Size(20, 20);
            YBtn.TabIndex = 319;
            YBtn.Text = "Y";
            YBtn.UseVisualStyleBackColor = false;
            YBtn.Click += YBtn_Click;
            // 
            // BBtn
            // 
            BBtn.BackColor = Color.FromArgb(114, 137, 218);
            BBtn.FlatAppearance.BorderSize = 0;
            BBtn.FlatStyle = FlatStyle.Flat;
            BBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            BBtn.ForeColor = Color.White;
            BBtn.Location = new Point(336, 46);
            BBtn.Margin = new Padding(4);
            BBtn.Name = "BBtn";
            BBtn.Size = new Size(20, 20);
            BBtn.TabIndex = 318;
            BBtn.Text = "B";
            BBtn.UseVisualStyleBackColor = false;
            BBtn.Click += BBtn_Click;
            // 
            // XBtn
            // 
            XBtn.BackColor = Color.FromArgb(114, 137, 218);
            XBtn.FlatAppearance.BorderSize = 0;
            XBtn.FlatStyle = FlatStyle.Flat;
            XBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            XBtn.ForeColor = Color.White;
            XBtn.Location = new Point(336, 4);
            XBtn.Margin = new Padding(4);
            XBtn.Name = "XBtn";
            XBtn.Size = new Size(20, 20);
            XBtn.TabIndex = 317;
            XBtn.Text = "X";
            XBtn.UseVisualStyleBackColor = false;
            XBtn.Click += XBtn_Click;
            // 
            // LstickRIGHTBtn
            // 
            LstickRIGHTBtn.BackColor = Color.FromArgb(114, 137, 218);
            LstickRIGHTBtn.FlatAppearance.BorderSize = 0;
            LstickRIGHTBtn.FlatStyle = FlatStyle.Flat;
            LstickRIGHTBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            LstickRIGHTBtn.ForeColor = Color.White;
            LstickRIGHTBtn.Location = new Point(45, 25);
            LstickRIGHTBtn.Margin = new Padding(4);
            LstickRIGHTBtn.Name = "LstickRIGHTBtn";
            LstickRIGHTBtn.Size = new Size(20, 20);
            LstickRIGHTBtn.TabIndex = 316;
            LstickRIGHTBtn.Text = "🠊";
            LstickRIGHTBtn.UseVisualStyleBackColor = false;
            LstickRIGHTBtn.MouseDown += LstickRIGHTBtn_MouseDown;
            LstickRIGHTBtn.MouseUp += LstickMouseUp;
            // 
            // LstickLEFTBtn
            // 
            LstickLEFTBtn.BackColor = Color.FromArgb(114, 137, 218);
            LstickLEFTBtn.FlatAppearance.BorderSize = 0;
            LstickLEFTBtn.FlatStyle = FlatStyle.Flat;
            LstickLEFTBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            LstickLEFTBtn.ForeColor = Color.White;
            LstickLEFTBtn.Location = new Point(3, 25);
            LstickLEFTBtn.Margin = new Padding(4);
            LstickLEFTBtn.Name = "LstickLEFTBtn";
            LstickLEFTBtn.Size = new Size(20, 20);
            LstickLEFTBtn.TabIndex = 315;
            LstickLEFTBtn.Text = "🠈";
            LstickLEFTBtn.UseVisualStyleBackColor = false;
            LstickLEFTBtn.MouseDown += LstickLEFTBtn_MouseDown;
            LstickLEFTBtn.MouseUp += LstickMouseUp;
            // 
            // LstickDOWNBtn
            // 
            LstickDOWNBtn.BackColor = Color.FromArgb(114, 137, 218);
            LstickDOWNBtn.FlatAppearance.BorderSize = 0;
            LstickDOWNBtn.FlatStyle = FlatStyle.Flat;
            LstickDOWNBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            LstickDOWNBtn.ForeColor = Color.White;
            LstickDOWNBtn.Location = new Point(24, 46);
            LstickDOWNBtn.Margin = new Padding(4);
            LstickDOWNBtn.Name = "LstickDOWNBtn";
            LstickDOWNBtn.Size = new Size(20, 20);
            LstickDOWNBtn.TabIndex = 314;
            LstickDOWNBtn.Text = "🠋";
            LstickDOWNBtn.UseVisualStyleBackColor = false;
            LstickDOWNBtn.MouseDown += LstickDOWNBtn_MouseDown;
            LstickDOWNBtn.MouseUp += LstickMouseUp;
            // 
            // LstickUPBtn
            // 
            LstickUPBtn.BackColor = Color.FromArgb(114, 137, 218);
            LstickUPBtn.FlatAppearance.BorderSize = 0;
            LstickUPBtn.FlatStyle = FlatStyle.Flat;
            LstickUPBtn.Font = new Font("Arial", 7F, FontStyle.Bold);
            LstickUPBtn.ForeColor = Color.White;
            LstickUPBtn.Location = new Point(24, 4);
            LstickUPBtn.Margin = new Padding(4);
            LstickUPBtn.Name = "LstickUPBtn";
            LstickUPBtn.Size = new Size(20, 20);
            LstickUPBtn.TabIndex = 313;
            LstickUPBtn.Text = "🠉";
            LstickUPBtn.UseVisualStyleBackColor = false;
            LstickUPBtn.MouseDown += LstickUPBtn_MouseDown;
            LstickUPBtn.MouseUp += LstickMouseUp;
            // 
            // controllertimer
            // 
            controllertimer.Interval = 10;
            controllertimer.Tick += ControllerTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(539, 214);
            Controls.Add(controllerPanel);
            Controls.Add(ipaddress);
            Controls.Add(Connect);
            ForeColor = SystemColors.ControlLightLight;
            Name = "Form1";
            Text = "Switch Controller";
            controllerPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Connect;
        private TextBox ipaddress;
        private Panel controllerPanel;
        private Button HomeBtn;
        private Button caputureBtn;
        private Button plusBtn;
        private Button minusBtn;
        private Button RBtn;
        private Button LBtn;
        private Button ZLBtn;
        private Button DetachBtn;
        private Button ZRBtn;
        private Button DrightBtn;
        private Button DleftBtn;
        private Button DdownBtn;
        private Button DupBtn;
        private Button RightStickBtn;
        private Button RstickRIGHTBtn;
        private Button RstickLEFTBtn;
        private Button RstickDOWNBtn;
        private Button RstickUPBtn;
        private Button LeftStickBtn;
        private Button ABtn;
        private Button YBtn;
        private Button BBtn;
        private Button XBtn;
        private Button LstickRIGHTBtn;
        private Button LstickLEFTBtn;
        private Button LstickDOWNBtn;
        private Button LstickUPBtn;
        private System.Windows.Forms.Timer controllertimer;
    }
}
