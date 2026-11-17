using System.Drawing;
using System.Windows.Forms;

namespace CSH030Ex
{
    //  CSH030Ex_Offline 전용 (OFFLINE 심볼) : 카메라/MIL 보드/DLN 없이 BMP 로드 후 마크 검출만 사용
    static class OfflineMode
    {
        //  기존 Form 배경색 (96, 96, 100) 과 구분하기 위한 배경색
        public static readonly Color BackColor = Color.FromArgb(0x1F, 0x2A, 0x44);
        public const string TitleTag = "[OFFLINE] ";

        //  장비 관련 컨트롤 비활성화
        public static void Disable(params Control[] controls)
        {
            foreach (Control c in controls)
                c.Enabled = false;
        }
    }
}
