namespace OEC222.AsyncWinForms
{
    public partial class Form1 : Form
    {
        private Random rnd;
        private bool isBusy = false;
        private bool cancelPending = false;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            if (isBusy)
            {
                cancelPending = true;
                return;
            }

            isBusy = true;

            await DoWork();

            cancelPending = false;
            isBusy = false;
        }

        private async Task DoWork()
        {
            await Task.Run(() =>
            {
                SetButtonText("STOP");
                SetTxtBoxText(rnd.Next().ToString());
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    SetProgressBarValue(i);
                    if (cancelPending)
                    {
                        cancelPending = false;
                        SetButtonText("START");
                        return;
                    }
                }
                SetButtonText("START");
            });
            
        }

        private void SetButtonText(string btnText)
        {
            if (startBtn.InvokeRequired)   //thread diverso dall'UI Thread 
            {
                startBtn.Invoke(new MethodInvoker(() => startBtn.Text = btnText));
            } else
            {
                startBtn.Text = btnText;
            }
        }

        private void SetProgressBarValue(int value)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(() => progressBar.Value = value);
            }
            else
            {
                progressBar.Value = value;
            }
        }

        private void SetTxtBoxText(string txt)
        {
            if (txtBox.InvokeRequired)
                txtBox.Invoke(() => txtBox.Text = txt);
            else
                txtBox.Text = txt;
        }

        private void UpdateControl(Control control, Action func)
        {
            if (control.InvokeRequired)
                control.Invoke(func);
            else
                func();
        }

    }
}