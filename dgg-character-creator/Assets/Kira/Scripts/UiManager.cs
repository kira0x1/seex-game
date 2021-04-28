using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kira
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _speedText;
        [SerializeField] private Slider _speedSlider;

        public delegate void OnSpeedChangeDelegate(float speed);
        public static OnSpeedChangeDelegate onSpeedChange;

        public void UpdateSpeed(float speed)
        {
            UpdateSpeedText(speed);
        }

        private void Start()
        {
            _speedSlider.onValueChanged.AddListener(OnSpeedChange);
            OnSpeedChange(_speedSlider.value);
        }

        private void OnSpeedChange(float speed)
        {
            onSpeedChange?.Invoke(speed);
            UpdateSpeedText(speed);
        }

        private void UpdateSpeedText(float speed)
        {
            _speedText.text = $"{speed:F1}";
        }
    }
}