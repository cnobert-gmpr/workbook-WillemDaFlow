using UnityEngine;
using UnityEngine.UIElements;

namespace GMPR2512.Lesson08ScenesAndUI
{
    public class Scene_00_Button_Handler : MonoBehaviour
    {
        private Button _changeToScene01Button;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _changeToScene01Button = root.Q<Button>("ChangeToScene01Button");
        }

        private void OnDisable()
        {
            
        }
    }
}
