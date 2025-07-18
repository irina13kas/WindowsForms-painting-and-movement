namespace КасьяноваИА_3._8
{
    partial class ParametrsForm
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
            pointColor_btn = new Button();
            lineColor_btn = new Button();
            OK_btn = new Button();
            Cancel_btn = new Button();
            pointColor_panel = new Panel();
            lineColor_panel = new Panel();
            fillColor_btn = new Button();
            fillColor_panel = new Panel();
            SuspendLayout();
            // 
            // pointColor_btn
            // 
            pointColor_btn.BackColor = Color.LightSteelBlue;
            pointColor_btn.Location = new Point(12, 31);
            pointColor_btn.Name = "pointColor_btn";
            pointColor_btn.Size = new Size(116, 32);
            pointColor_btn.TabIndex = 0;
            pointColor_btn.Text = "Цвет точек";
            pointColor_btn.UseVisualStyleBackColor = false;
            // 
            // lineColor_btn
            // 
            lineColor_btn.BackColor = Color.LightSteelBlue;
            lineColor_btn.Location = new Point(12, 88);
            lineColor_btn.Name = "lineColor_btn";
            lineColor_btn.Size = new Size(116, 32);
            lineColor_btn.TabIndex = 1;
            lineColor_btn.Text = "Цвет линии";
            lineColor_btn.UseVisualStyleBackColor = false;
            // 
            // OK_btn
            // 
            OK_btn.BackColor = Color.LightSteelBlue;
            OK_btn.DialogResult = DialogResult.OK;
            OK_btn.Location = new Point(31, 204);
            OK_btn.Name = "OK_btn";
            OK_btn.Size = new Size(84, 34);
            OK_btn.TabIndex = 2;
            OK_btn.Text = "ОК";
            OK_btn.UseVisualStyleBackColor = false;
            // 
            // Cancel_btn
            // 
            Cancel_btn.BackColor = Color.LightSteelBlue;
            Cancel_btn.DialogResult = DialogResult.Cancel;
            Cancel_btn.Location = new Point(141, 204);
            Cancel_btn.Name = "Cancel_btn";
            Cancel_btn.Size = new Size(84, 34);
            Cancel_btn.TabIndex = 3;
            Cancel_btn.Text = "Отмена";
            Cancel_btn.UseVisualStyleBackColor = false;
            // 
            // pointColor_panel
            // 
            pointColor_panel.Location = new Point(197, 31);
            pointColor_panel.Name = "pointColor_panel";
            pointColor_panel.Size = new Size(38, 32);
            pointColor_panel.TabIndex = 4;
            // 
            // lineColor_panel
            // 
            lineColor_panel.Location = new Point(197, 88);
            lineColor_panel.Name = "lineColor_panel";
            lineColor_panel.Size = new Size(38, 32);
            lineColor_panel.TabIndex = 5;
            // 
            // fillColor_btn
            // 
            fillColor_btn.BackColor = Color.LightSteelBlue;
            fillColor_btn.Location = new Point(12, 144);
            fillColor_btn.Name = "fillColor_btn";
            fillColor_btn.Size = new Size(116, 32);
            fillColor_btn.TabIndex = 6;
            fillColor_btn.Text = "Цвет заливки";
            fillColor_btn.UseVisualStyleBackColor = false;
            fillColor_btn.Click += fillColor_btn_Click;
            // 
            // fillColor_panel
            // 
            fillColor_panel.Location = new Point(197, 144);
            fillColor_panel.Name = "fillColor_panel";
            fillColor_panel.Size = new Size(38, 32);
            fillColor_panel.TabIndex = 7;
            // 
            // ParametrsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 253);
            Controls.Add(fillColor_panel);
            Controls.Add(fillColor_btn);
            Controls.Add(lineColor_panel);
            Controls.Add(pointColor_panel);
            Controls.Add(Cancel_btn);
            Controls.Add(OK_btn);
            Controls.Add(lineColor_btn);
            Controls.Add(pointColor_btn);
            Name = "ParametrsForm";
            Text = "Параметры";
            ResumeLayout(false);
        }

        #endregion

        private Button pointColor_btn;
        private Button lineColor_btn;
        private Button OK_btn;
        private Button Cancel_btn;
        private Panel pointColor_panel;
        private Panel lineColor_panel;
        private Button fillColor_btn;
        private Panel fillColor_panel;
    }
}