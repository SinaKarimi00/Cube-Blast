using UnityEngine;
using UnityEngine.UIElements;


namespace UI.Behaviour
{
    public class ResetButton : MonoBehaviour
    {
        private void Awake()
        {
            VisualElement rootVisual = GetComponent<UIDocument>().rootVisualElement;
            rootVisual.Q<Button>("ResetButton").clicked += () => ResetGame();

            void ResetGame() => Debug.Log("Reset");
        }
    }
}