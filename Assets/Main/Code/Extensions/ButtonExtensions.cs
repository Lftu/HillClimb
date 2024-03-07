using UnityEngine.Events;
using UnityEngine.UI;

namespace Main.Code.Extentions
{
    public static class ButtonExtensions
    {
        public static void AddListener(this Button button, UnityAction eventAction)
        {
            button.onClick.AddListener(eventAction);
        }
        
        public static void RemoveListener(this Button button, UnityAction eventAction)
        {
            button.onClick.RemoveListener(eventAction);
        }
    }
}