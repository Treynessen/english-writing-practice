using System.Threading.Tasks;

namespace Treynessen.UI
{
    public partial class ButtonInterface
    {
        public async Task Display()
        {
            UpdateInterface();
            await ControlAsync();
        }
    }
}