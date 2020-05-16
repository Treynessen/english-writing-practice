using System.Collections.Generic;

namespace Treynessen.UI
{
    public partial class Buttons
    {
        public IEnumerator<Button> GetEnumerator()
        {
            foreach (var buttonLine in buttonGrid)
            {
                foreach (var button in buttonLine)
                {
                    yield return button;
                }
            }
        }
    }
}