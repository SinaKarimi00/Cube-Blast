using UnityEngine;
using UnityEngine.UIElements;


namespace UI.Behaviour
{
    public class ButtonManager : MonoBehaviour
    {
        private void Awake()
        {
            VisualElement rootVisual = GetComponent<UIDocument>().rootVisualElement;
            rootVisual.Q<Button>("StartGameButton").clicked += () => StartGame(rootVisual);
        }

        private void StartGame(VisualElement rootVisual)
        {
            rootVisual.Q<Label>("GuidanceLabel").visible = false;
        }
    }
}