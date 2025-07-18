using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КасьяноваИА_3._8
{
    public partial class ParametrsForm : Form
    {
        private ColorDialog colorDialog;
        public Color PointColor { get; set; }
        public Color LineColor { get; set; }
        public Color FillColor { get; set; }
        public ParametrsForm(Color currentPointColor, Color currentLineColor, Color currentFillColor)
        {
            InitializeComponent();
            pointColor_btn.Click += new EventHandler(pointColor_btn_Click);
            lineColor_btn.Click += new EventHandler(lineColor_btn_Click);

            colorDialog = new ColorDialog { Color = currentPointColor, FullOpen = true };
            PointColor = currentPointColor;
            LineColor = currentLineColor;
            FillColor = currentFillColor;
            pointColor_panel.BackColor = currentPointColor;
            lineColor_panel.BackColor = currentLineColor;
            fillColor_panel.BackColor = currentFillColor;
        }

        private void pointColor_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                PointColor = colorDialog.Color;
                pointColor_panel.BackColor = colorDialog.Color;
            }
        }

        private void lineColor_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                LineColor = colorDialog.Color;
                lineColor_panel.BackColor = colorDialog.Color;
            }
        }

        private void fillColor_btn_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                FillColor = colorDialog.Color;
                fillColor_panel.BackColor = colorDialog.Color;
            }
        }
    }
}
