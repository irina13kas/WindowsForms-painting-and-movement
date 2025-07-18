namespace КасьяноваИА_3._8
{
    public partial class MainForm : Form
    {
        private List<PointF> points;
        private List<PointF> offset;
        private List<PointF[]> trails;

        private Pen pen;
        private SolidBrush pointBrush;
        private SolidBrush fillBrush;

        private int iDraggingPoint;
        private bool bDrag;

        private bool isPointMode;
        private bool isFillMode;
        private bool isMoveMode;
        private bool isTrailMode;

        private bool[] direction; //up, down, left, right
        private System.Windows.Forms.Timer moveTimer;
        private enum TypeOfLine
        {
            Curve,
            Broken,
            Bezie,
            None
        }
        private TypeOfLine typeOfLine;
        private const int POINT_RADIUS = 10;

        private float speed = 2;
        private float moveX = 0;
        private float moveY = 0;
        public MainForm()
        {
            points = new List<PointF>();
            offset = new List<PointF>();
            trails = new List<PointF[]>();
            direction = new bool[4]{ true, true, true, true};
            pen = new Pen(Color.DarkGreen, 5);
            pointBrush = new SolidBrush(Color.Black);
            fillBrush = new SolidBrush(Color.DimGray);
            moveTimer = new System.Windows.Forms.Timer { Interval = 30};

            typeOfLine = TypeOfLine.None;
            isPointMode = false;
            isFillMode = false;
            isMoveMode = false;
            isTrailMode = false;
            bDrag = false;
            DoubleBuffered = true;
            KeyPreview = true;

            InitializeComponent();

            moveTimer.Tick += new EventHandler(TimerTickHandler);
            KeyDown += new KeyEventHandler(Form_KeyDown);

            MouseDown += new MouseEventHandler(MainForm_MouseDown);
            MouseMove += new MouseEventHandler(MainForm_MouseMove);
            MouseUp += new MouseEventHandler(MainForm_MouseUp);

            points_btn.Click += new EventHandler(Points_btn_Click);
            parametrs_btn.Click += new EventHandler(Parametrs_btn_Click);
            curve_btn.Click += new EventHandler(Curve_btn_Click);
            brokenLine_btn.Click += new EventHandler(BrokenLine_btn_Click);
            bezieLine_btn.Click += new EventHandler(BezieLine_btn_Click);
            fillColor_btn.Click += new EventHandler(FillColor_btn_Click);
            clear_btn.Click += new EventHandler(Clear_btn_Click);
            move_btn.Click += new EventHandler(Move_btn_Click);

            Paint += new PaintEventHandler(MainForm_PaintPoint);
            Paint += new PaintEventHandler(MainForm_PaintCurve);
            Paint += new PaintEventHandler(MainForm_PaintBrokenLine);
            Paint += new PaintEventHandler(MainForm_FillColor);
            Paint += new PaintEventHandler(MainForm_PaintBezieLine);
        }

        private void MainForm_PaintPoint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (PointF point in points)
                g.FillEllipse(pointBrush, point.X, point.Y, POINT_RADIUS, POINT_RADIUS);
        }

        private void Points_btn_Click(object sender, EventArgs e)
        {
            if (!isPointMode)
            {
                MouseClick += new MouseEventHandler(MainForm_MouseClickPoint);
            }
            else
            {
                MouseClick -= new MouseEventHandler(MainForm_MouseClickPoint);
            }
            isPointMode = !isPointMode;
        }

        private void MainForm_MouseClickPoint(object sender, MouseEventArgs e)
        {
            if (!bDrag)
            {
                points.Add(e.Location);
                Invalidate();
            }
        }

        private void Curve_btn_Click(object sender, EventArgs e)
        {
            if (typeOfLine != TypeOfLine.Curve)
            {
                typeOfLine = TypeOfLine.Curve;
            }
            Invalidate();
        }
        private void MainForm_PaintCurve(object sender, PaintEventArgs e)
        {
            if (points.Count > 1 && typeOfLine == TypeOfLine.Curve)
            {
                Graphics g = e.Graphics;
                if (isTrailMode)
                {
                    foreach (var trail in trails)
                    {
                        e.Graphics.FillClosedCurve(new SolidBrush(Color.FromArgb(128, Color.Cyan)), trail);
                    }
                }
                var pointForClosedLine = points.Select(p => p = new PointF(p.X + 5, p.Y + 5));
                g.DrawClosedCurve(pen, pointForClosedLine.ToArray());
            }
        }

        private void BrokenLine_btn_Click(object sender, EventArgs e)
        {
            if (typeOfLine != TypeOfLine.Broken)
            {
                typeOfLine = TypeOfLine.Broken;
            }
            Invalidate();
        }

        private void MainForm_PaintBrokenLine(object sender, PaintEventArgs e)
        {
            if (points.Count > 1 && typeOfLine == TypeOfLine.Broken)
            {
                Graphics g = e.Graphics;
                if (isTrailMode)
                {
                    foreach (var trail in trails)
                    {
                        e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(128, Color.Cyan)), trail);
                    }
                }
                var pointForClosedLine = points.Select(p => p = new PointF(p.X + 5, p.Y + 5));
                g.DrawPolygon(pen, pointForClosedLine.ToArray());
            }
        }

        private void FillColor_btn_Click(object sender, EventArgs e)
        {
            isFillMode = !isFillMode;
            Invalidate();
        }
        private void MainForm_FillColor(object sender, PaintEventArgs e)
        {
            if (points.Count > 1 && isFillMode && (typeOfLine==TypeOfLine.Curve || typeOfLine == TypeOfLine.Broken))
            {
                Graphics g = e.Graphics;
                var pointForClosedLine = points.Select(p => p = new PointF(p.X + 5, p.Y + 5));
                if(typeOfLine==TypeOfLine.Curve || typeOfLine==TypeOfLine.Bezie)
                    g.FillClosedCurve(fillBrush, pointForClosedLine.ToArray());
                else if(typeOfLine == TypeOfLine.Broken)
                    g.FillPolygon(fillBrush, pointForClosedLine.ToArray());
            }
        }

        private void BezieLine_btn_Click(object sender, EventArgs e)
        {
            if (typeOfLine != TypeOfLine.Bezie)
            {
                typeOfLine = TypeOfLine.Bezie;
            }
            Invalidate();
        }

        private void MainForm_PaintBezieLine(object sender, PaintEventArgs e)
        {
            if (points.Count > 1 && typeOfLine == TypeOfLine.Bezie && points.Count % 3 == 1)
            {
                Graphics g = e.Graphics;
                var pointForClosedLine = points.Select(p => p = new PointF(p.X + 5, p.Y + 5));
                g.DrawBeziers(pen, pointForClosedLine.ToArray());
            }
        }

        private void Parametrs_btn_Click(object sender, EventArgs e)
        {
            using (ParametrsForm parametrsForm = new ParametrsForm(pointBrush.Color, pen.Color, fillBrush.Color))
            {
                if (parametrsForm.ShowDialog() == DialogResult.OK)
                {
                    pointBrush.Color = parametrsForm.PointColor;
                    fillBrush.Color = parametrsForm.FillColor;
                    pen.Color = parametrsForm.LineColor;

                    Invalidate();
                }
            }
        }

        private void TimerTickHandler(object sender, EventArgs e)
        {
            MouseClick -= new MouseEventHandler(MainForm_MouseClickPoint);
            if (points.Count > 1 && isMoveMode && (typeOfLine == TypeOfLine.Curve || typeOfLine == TypeOfLine.Broken))
            {
                if (isTrailMode)
                {
                    trails.Add(points.ToArray());
                    if (trails.Count > 40)
                    {
                        trails.RemoveAt(0);
                    }
                }
                for (int i = 0; i < points.Count; i++)
                {
                    float offsetX = offset[i].X* speed;
                    float offsetY = offset[i].Y* speed;
                    if (points[i].X + offsetX < 15)
                        offset[i] = new PointF(-offset[i].X, offset[i].Y);
                    else if (points[i].X + offsetX >= this.Size.Width - 30)
                        offset[i] = new PointF(-offset[i].X, offset[i].Y);
                    if (points[i].Y + offsetY < 0)
                        offset[i] = new PointF(offset[i].X, -offset[i].Y);
                    else if (points[i].Y + offsetY >= this.Size.Height - 40)
                        offset[i] = new PointF(offset[i].X, -offset[i].Y);
                    points[i] = new PointF(points[i].X + offsetX, points[i].Y + offsetY);
                }
            }
            Invalidate();
        }

        private void Move_btn_Click(object sender, EventArgs e)
        {
            isPointMode = false;
            ToggleMovement();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            if (points.Count > 0)
                points.Clear();
            if (offset.Count > 0)
                offset.Clear();
            if (trails.Count > 0)
                trails.Clear();
            if (isPointMode)
                MouseClick -= new MouseEventHandler(MainForm_MouseClickPoint);
            moveTimer.Stop();
            direction = new bool[4] { true, true, true, true };
            isPointMode = false;
            isFillMode = false;
            isMoveMode = false;
            isTrailMode = false;
            bDrag = false;
            speed = 2;
            moveX = 0;
            moveY = 0;
            iDraggingPoint = -1;
            typeOfLine = TypeOfLine.None;
            Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool IsHandled = false;
            if (!isMoveMode)
            {
                switch (keyData)
                {
                    case Keys.Up:
                        if (direction[0])
                        {
                            for (int i = 0; i < points.Count; i++)
                            {
                                if (points[i].Y > 10)
                                {
                                    points[i] = new PointF(points[i].X, points[i].Y - 10);
                                    direction[1] = true;
                                }
                                else
                                {
                                    direction[0] = false;
                                    break;
                                }
                            }
                        }
                        IsHandled = true;
                        break;
                    case Keys.Down:
                        if (direction[1])
                        {
                            for (int i = 0; i < points.Count; i++)
                            {
                                if (points[i].Y <= this.Size.Height - 50)
                                {
                                    points[i] = new PointF(points[i].X, points[i].Y + 10);
                                    direction[0] = true;
                                }
                                else
                                {
                                    direction[1] = false;
                                    break;
                                }
                            }
                        }
                        IsHandled = true;
                        break;
                    case Keys.Left:
                        if (direction[2])
                        {
                            for (int i = 0; i < points.Count; i++)
                            {
                                if (points[i].X > 20)
                                {
                                    points[i] = new PointF(points[i].X - 10, points[i].Y);
                                    direction[3] = true;
                                }
                                else
                                {
                                    direction[2] = false;
                                    break;
                                }
                            }
                        }
                        IsHandled = true;
                        break;
                    case Keys.Right:
                        if (direction[3])
                        {
                            for (int i = 0; i < points.Count; i++)
                            {
                                if (points[i].X <= this.Size.Width - 40)
                                {
                                    points[i] = new PointF(points[i].X + 10, points[i].Y);
                                    direction[2] = true;
                                }
                                else
                                {
                                    direction[3] = false;
                                    break;
                                }
                            }
                        }
                        IsHandled = true;
                        break;
                }
                Invalidate();
            }
            return IsHandled;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) 
            {
                case Keys.S:
                    isPointMode = false;
                    isTrailMode = !isTrailMode;
                    if (!isTrailMode)
                    {
                        trails.Clear();
                    }
                    Invalidate();
                    break;
                case Keys.Space:
                    ToggleMovement();
                    break;
                case Keys.Add:
                case Keys.Oemplus:
                    if(speed<10)
                        speed += 1;
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    if(speed>2)
                        speed /=2;
                    break;
                case Keys.Escape:
                    Clear();
                    break;
            }
            e.Handled = true;
        }

        private void ToggleMovement()
        {
            direction = new bool[4] { true, true, true, true };
            if (!isMoveMode && (typeOfLine == TypeOfLine.Curve || typeOfLine == TypeOfLine.Broken))
            {
                isMoveMode = !isMoveMode;
                moveX = RandomizeNewCoordinate(0.5);
                moveY = RandomizeNewCoordinate(0.5);

                    for (int i = 0; i < points.Count; i++)
                    {
                        offset.Add(new PointF(moveX, moveY));
                    }

 
                moveTimer.Start();
            }
            else if (typeOfLine == TypeOfLine.Curve || typeOfLine == TypeOfLine.Broken)
            {
                isMoveMode = !isMoveMode;
                offset.Clear();
                moveTimer.Stop();
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!bDrag)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    PointF p = points[i];
                    if (Math.Abs(e.Location.X - p.X) < 50 && Math.Abs(e.Location.Y - p.Y) < 50)
                    {
                        iDraggingPoint = i;
                        bDrag = true;
                        break;
                    }
                }
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDrag && !isMoveMode)
            {
                points[iDraggingPoint] = new PointF(e.Location.X, e.Location.Y);
                Invalidate();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            bDrag = false;
        }

        private float RandomizeNewCoordinate(double offset)
        {
            Random random = new Random();
            return (float)((random.NextDouble()- offset)*offset*3);
        }
    }
}
