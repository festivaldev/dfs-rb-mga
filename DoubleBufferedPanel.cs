using System.Windows.Forms;

namespace DFSRBMGA
{
    public partial class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel() {
            DoubleBuffered = true;
        }
    }
}
