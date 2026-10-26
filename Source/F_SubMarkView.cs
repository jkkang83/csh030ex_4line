using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSH030Ex
{
    //  보조마크(초점 밖 마크) 검사결과 확인용 팝업
    //  F_Vision 의 상단/우측 Panel 더블클릭으로 열림. 내용은 FVision.UpdateSubMarkView() 에서 채운다.
    public class F_SubMarkView : Form
    {
        PictureBox pbSub = new PictureBox();
        TextBox tbSubInfo = new TextBox();
        Label lbFrame = new Label();
        TextBox tbFrame = new TextBox();
        Button btnShowFrame = new Button();
        Button btnPrevFrame = new Button();
        Button btnNextFrame = new Button();
        Label lbFrameRange = new Label();
        int mFrameCount = 0;    //  SetFrameRange 로 받은 영상 수 ( 앞/뒤 이동 범위 )

        //  Frame 입력 후 Show(또는 Enter) 시 호출. FVision.ShowFrameView() 연결
        public Action<int> FrameRequested = null;

        public F_SubMarkView()
        {
            Text = "Sub Mark View";
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(550, 420 + 85 + 30);
            BackColor = Color.FromArgb(64, 64, 68);

            pbSub.Location = new Point(0, 0);
            pbSub.Size = new Size(550, 420);
            pbSub.BackColor = Color.Black;

            tbSubInfo.Location = new Point(0, 420);
            tbSubInfo.Size = new Size(550, 85);
            tbSubInfo.Multiline = true;
            tbSubInfo.ReadOnly = true;
            tbSubInfo.ScrollBars = ScrollBars.Vertical;
            tbSubInfo.Font = new Font("Consolas", 9F);
            tbSubInfo.BackColor = Color.Black;
            tbSubInfo.ForeColor = Color.White;

            lbFrame.Location = new Point(6, 512);
            lbFrame.Size = new Size(50, 18);
            lbFrame.Text = "Frame";
            lbFrame.ForeColor = Color.White;

            btnPrevFrame.Location = new Point(58, 507);
            btnPrevFrame.Size = new Size(28, 24);
            btnPrevFrame.Text = "<";
            btnPrevFrame.BackColor = Color.Gainsboro;
            btnPrevFrame.Click += (s, e) => StepFrame(-1);

            tbFrame.Location = new Point(88, 508);
            tbFrame.Size = new Size(60, 22);
            tbFrame.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { RequestFrame(); e.SuppressKeyPress = true; } };
            //  휠 위 : 다음 frame, 휠 아래 : 이전 frame
            tbFrame.MouseWheel += (s, e) =>
            {
                StepFrame(e.Delta > 0 ? 1 : -1);
                ((HandledMouseEventArgs)e).Handled = true;
            };

            btnNextFrame.Location = new Point(150, 507);
            btnNextFrame.Size = new Size(28, 24);
            btnNextFrame.Text = ">";
            btnNextFrame.BackColor = Color.Gainsboro;
            btnNextFrame.Click += (s, e) => StepFrame(1);

            btnShowFrame.Location = new Point(182, 507);
            btnShowFrame.Size = new Size(56, 24);
            btnShowFrame.Text = "Show";
            btnShowFrame.BackColor = Color.Gainsboro;
            btnShowFrame.Click += (s, e) => RequestFrame();

            lbFrameRange.Location = new Point(244, 512);
            lbFrameRange.Size = new Size(300, 18);
            lbFrameRange.ForeColor = Color.White;

            Controls.Add(pbSub);
            Controls.Add(tbSubInfo);
            Controls.Add(lbFrame);
            Controls.Add(btnPrevFrame);
            Controls.Add(tbFrame);
            Controls.Add(btnNextFrame);
            Controls.Add(btnShowFrame);
            Controls.Add(lbFrameRange);
        }

        //  Load BMP 로 불러온 영상 수
        public void SetFrameRange(int count)
        {
            mFrameCount = count;
            lbFrameRange.Text = count > 0 ? string.Format("유효 Index : 0 ~ {0}", count - 1) : "유효 Index : 없음 (Load BMP 영상만 지원)";
        }

        public void SetFrame(int frame)
        {
            tbFrame.Text = frame.ToString();
        }

        //  현재 입력된 frame 에서 step 만큼 이동 ( 유효 범위 밖이면 이동하지 않음 )
        void StepFrame(int step)
        {
            int frame;
            if (!int.TryParse(tbFrame.Text, out frame))
                frame = step > 0 ? -1 : mFrameCount;
            frame += step;
            if (frame < 0 || frame >= mFrameCount)
                return;

            tbFrame.Text = frame.ToString();
            RequestFrame();
        }

        void RequestFrame()
        {
            int frame;
            if (!int.TryParse(tbFrame.Text, out frame) || frame < 0)
            {
                MessageBox.Show("Frame 번호를 입력하세요.");
                return;
            }
            if (FrameRequested != null)
                FrameRequested(frame);
        }

        public void SetView(Bitmap img, string info)
        {
            Image old = pbSub.Image;
            pbSub.Image = img;
            if (old != null) old.Dispose();
            tbSubInfo.Text = info;
        }
    }
}
