namespace КасьяноваИА_3._8
{
    partial class MainForm
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
            points_btn = new Button();
            parametrs_btn = new Button();
            move_btn = new Button();
            curve_btn = new Button();
            brokenLine_btn = new Button();
            bezieLine_btn = new Button();
            fillColor_btn = new Button();
            clear_btn = new Button();
            SuspendLayout();
            // 
            // points_btn
            // 
            points_btn.BackColor = SystemColors.ActiveCaption;
            points_btn.Location = new Point(22, 21);
            points_btn.Name = "points_btn";
            points_btn.Size = new Size(98, 32);
            points_btn.TabIndex = 0;
            points_btn.Text = "Точки";
            points_btn.UseVisualStyleBackColor = false;
            // 
            // parametrs_btn
            // 
            parametrs_btn.BackColor = SystemColors.ActiveCaption;
            parametrs_btn.Location = new Point(22, 72);
            parametrs_btn.Name = "parametrs_btn";
            parametrs_btn.Size = new Size(98, 32);
            parametrs_btn.TabIndex = 1;
            parametrs_btn.Text = "Параметры";
            parametrs_btn.UseVisualStyleBackColor = false;
            // 
            // move_btn
            // 
            move_btn.BackColor = SystemColors.ActiveCaption;
            move_btn.Location = new Point(22, 123);
            move_btn.Name = "move_btn";
            move_btn.Size = new Size(98, 32);
            move_btn.TabIndex = 2;
            move_btn.Text = "Движение";
            move_btn.UseVisualStyleBackColor = false;
            // 
            // curve_btn
            // 
            curve_btn.BackColor = SystemColors.ActiveCaption;
            curve_btn.Location = new Point(22, 173);
            curve_btn.Name = "curve_btn";
            curve_btn.Size = new Size(98, 32);
            curve_btn.TabIndex = 3;
            curve_btn.Text = "Кривая";
            curve_btn.UseVisualStyleBackColor = false;
            // 
            // brokenLine_btn
            // 
            brokenLine_btn.BackColor = SystemColors.ActiveCaption;
            brokenLine_btn.Location = new Point(22, 226);
            brokenLine_btn.Name = "brokenLine_btn";
            brokenLine_btn.Size = new Size(98, 32);
            brokenLine_btn.TabIndex = 4;
            brokenLine_btn.Text = "Ломанная";
            brokenLine_btn.UseVisualStyleBackColor = false;
            // 
            // bezieLine_btn
            // 
            bezieLine_btn.BackColor = SystemColors.ActiveCaption;
            bezieLine_btn.Location = new Point(22, 278);
            bezieLine_btn.Name = "bezieLine_btn";
            bezieLine_btn.Size = new Size(98, 32);
            bezieLine_btn.TabIndex = 5;
            bezieLine_btn.Text = "Безье";
            bezieLine_btn.UseVisualStyleBackColor = false;
            // 
            // fillColor_btn
            // 
            fillColor_btn.BackColor = SystemColors.ActiveCaption;
            fillColor_btn.Location = new Point(22, 328);
            fillColor_btn.Name = "fillColor_btn";
            fillColor_btn.Size = new Size(98, 32);
            fillColor_btn.TabIndex = 6;
            fillColor_btn.Text = "Закрашенная";
            fillColor_btn.UseVisualStyleBackColor = false;
            // 
            // clear_btn
            // 
            clear_btn.BackColor = SystemColors.ActiveCaption;
            clear_btn.Location = new Point(22, 377);
            clear_btn.Name = "clear_btn";
            clear_btn.Size = new Size(98, 32);
            clear_btn.TabIndex = 7;
            clear_btn.Text = "Очистить";
            clear_btn.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(628, 421);
            Controls.Add(clear_btn);
            Controls.Add(fillColor_btn);
            Controls.Add(bezieLine_btn);
            Controls.Add(brokenLine_btn);
            Controls.Add(curve_btn);
            Controls.Add(move_btn);
            Controls.Add(parametrs_btn);
            Controls.Add(points_btn);
            Location = new Point(800, 800);
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(600, 460);
            Name = "MainForm";
            Text = "Форма";
            ResumeLayout(false);
        }

        #endregion

        private Button points_btn;
        private Button parametrs_btn;
        private Button move_btn;
        private Button curve_btn;
        private Button brokenLine_btn;
        private Button bezieLine_btn;
        private Button fillColor_btn;
        private Button clear_btn;

    }
}
