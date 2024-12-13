namespace SchoolSystem
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            panel2 = new Panel();
            label1 = new Label();
            guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(43, 53, 86);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(guna2ControlBox1);
            guna2Transition1.SetDecoration(panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(519, 48);
            panel2.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            guna2Transition1.SetDecoration(label1, Guna.UI2.AnimatorNS.DecorationType.None);
            label1.Font = new Font("Verdana", 14F);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(8, 7);
            label1.Name = "label1";
            label1.Size = new Size(73, 29);
            label1.TabIndex = 8;
            label1.Text = "Вход";
            // 
            // guna2ControlBox1
            // 
            guna2ControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox1.BackColor = Color.FromArgb(50, 64, 116);
            guna2ControlBox1.Cursor = Cursors.Hand;
            guna2ControlBox1.CustomIconSize = 15F;
            guna2ControlBox1.CustomizableEdges = customizableEdges1;
            guna2Transition1.SetDecoration(guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            guna2ControlBox1.FillColor = Color.FromArgb(30, 37, 67);
            guna2ControlBox1.IconColor = Color.White;
            guna2ControlBox1.Location = new Point(474, 7);
            guna2ControlBox1.Name = "guna2ControlBox1";
            guna2ControlBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox1.Size = new Size(33, 33);
            guna2ControlBox1.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            guna2Transition1.SetDecoration(checkBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            checkBox1.Location = new Point(68, 299);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(136, 24);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "Скрыть пароль";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 15;
            guna2Button1.Cursor = Cursors.Hand;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Transition1.SetDecoration(guna2Button1, Guna.UI2.AnimatorNS.DecorationType.None);
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(43, 53, 86);
            guna2Button1.Font = new Font("Segoe UI", 10F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(68, 417);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(375, 58);
            guna2Button1.TabIndex = 18;
            guna2Button1.Text = "Войти";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2TextBox2
            // 
            guna2TextBox2.Animated = true;
            guna2TextBox2.BorderRadius = 15;
            guna2TextBox2.CustomizableEdges = customizableEdges5;
            guna2Transition1.SetDecoration(guna2TextBox2, Guna.UI2.AnimatorNS.DecorationType.None);
            guna2TextBox2.DefaultText = "";
            guna2TextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Font = new Font("Segoe UI", 10F);
            guna2TextBox2.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Location = new Point(68, 238);
            guna2TextBox2.Margin = new Padding(3, 5, 3, 5);
            guna2TextBox2.Name = "guna2TextBox2";
            guna2TextBox2.PasswordChar = '\0';
            guna2TextBox2.PlaceholderText = "Пароль";
            guna2TextBox2.SelectedText = "";
            guna2TextBox2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox2.Size = new Size(375, 53);
            guna2TextBox2.TabIndex = 16;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.Animated = true;
            guna2TextBox1.BorderRadius = 15;
            guna2TextBox1.CustomizableEdges = customizableEdges7;
            guna2Transition1.SetDecoration(guna2TextBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 10F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(68, 175);
            guna2TextBox1.Margin = new Padding(3, 5, 3, 5);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "Логин";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2TextBox1.Size = new Size(375, 53);
            guna2TextBox1.TabIndex = 15;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.DragStartTransparencyValue = 1D;
            guna2DragControl1.TargetControl = panel2;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Transition1
            // 
            guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = (PointF)resources.GetObject("animation1.BlindCoeff");
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = (PointF)resources.GetObject("animation1.MosaicCoeff");
            animation1.MosaicShift = (PointF)resources.GetObject("animation1.MosaicShift");
            animation1.MosaicSize = 0;
            animation1.Padding = new Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = (PointF)resources.GetObject("animation1.ScaleCoeff");
            animation1.SlideCoeff = (PointF)resources.GetObject("animation1.SlideCoeff");
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            guna2Transition1.DefaultAnimation = animation1;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(519, 552);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(guna2Button1);
            Controls.Add(guna2TextBox2);
            Controls.Add(guna2TextBox1);
            guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            Load += FormLogin_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Label label2;
        private CheckBox checkBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}