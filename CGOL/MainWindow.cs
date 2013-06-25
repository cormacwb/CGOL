using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace CGOL
{
    public partial class MainWindow : Form
    {

        IGameOfLife gameOfLife;
        private int _cellSize = 30;
        private int _worldLength = 50;
        private int _initialLifeDensityPercentage = 20;

        private const int HEIGHT_BUFFER = 80;
        private const int WIDTH_BUFFER = 180;
        private const int CELL_BUFFER = 2;
        private const int INTERFACE_ORIGIN = 10;
        private const int SLEEP_TIME_IN_MILLIS = 1000;
        private const int DESIRED_WINDOW_SIZE = 600;
        
        public MainWindow()
        {
            InitializeComponent();
            _cellSize = DESIRED_WINDOW_SIZE / _worldLength;
            gameOfLife = new World(_worldLength, _initialLifeDensityPercentage);
            this.DoubleBuffered = true;
            this.Height = (_cellSize * _worldLength) + HEIGHT_BUFFER;
            this.Width = (_cellSize * _worldLength) + WIDTH_BUFFER;
            setPanelsPosition();
        }

        
        private void setPanelsPosition()
        {
            UserControlsLayoutPanel.Location = new Point(INTERFACE_ORIGIN, (_cellSize * _worldLength) + (HEIGHT_BUFFER / 8));
            StatisticsLayoutPanel.Location = new Point((_cellSize * _worldLength) + (WIDTH_BUFFER / 8), INTERFACE_ORIGIN);
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics, new Pen(Color.Black), _cellSize, _worldLength);

            for (int i = 0; i < _worldLength; i++)
            {
                int iPixelIndex = i * _cellSize;
                for (int j = 0; j < _worldLength; j++)
                {
                    int jPixelIndex = j * _cellSize;
                    SolidBrush solidBrush;
                    if (gameOfLife.GetCells()[i, j].State == Cell.CellState.Alive)
                        solidBrush = new SolidBrush(Color.Red);
                    else
                        solidBrush = new SolidBrush(Color.Blue);

                    e.Graphics.FillRectangle(solidBrush,
                        new Rectangle
                            (iPixelIndex + CELL_BUFFER,
                            jPixelIndex + CELL_BUFFER,
                            _cellSize - (CELL_BUFFER * 2) + 1,
                            _cellSize - (CELL_BUFFER * 2) + 1
                            )
                        );
                }
            }
        }

        private void DrawGrid(Graphics graphics, Pen pen, int cellSize, int worldLength)
        {
            for (int i = 0; i < (worldLength + 1) * cellSize; i += cellSize)
            {
                graphics.DrawLine(pen, i, 0, i, _cellSize * worldLength);
                graphics.DrawLine(pen, 0, i, _cellSize * worldLength, i);
            }
        }        

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            MainGameLoop(bw);

            if (bw.CancellationPending)
                e.Cancel = true;           
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            Update_Statistics();
            this.Refresh();
        }

        private void MainGameLoop(BackgroundWorker bw)
        {
            while (true)
            {
                if ((bw.CancellationPending == true))
                    break;

                gameOfLife.MoveToNextState();
                bw.ReportProgress(1);
                Thread.Sleep(SLEEP_TIME_IN_MILLIS);
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync(1);
            Run.Enabled = false;
            Step.Enabled = false;
            Pause.Enabled = true;
        }

        private void Step_Click(object sender, EventArgs e)
        {
            gameOfLife.MoveToNextState();
            Update_Statistics();
            this.Refresh();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                Step.Enabled = true;
                Pause.Text = "Resume";
            }
            else
            {
                backgroundWorker1.RunWorkerAsync(1);
                Step.Enabled = false;
                Pause.Text = "Pause";
                Pause.Enabled = true;
            }
        }

        private void Update_Statistics()
        {
            GenerationNumber.Text = gameOfLife.GetGenerationNumber().ToString();
            AliveCellCount.Text = gameOfLife.GetLiveCellCount().ToString();
        }
    }
}