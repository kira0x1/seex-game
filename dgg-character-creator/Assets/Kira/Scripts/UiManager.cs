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

#if UNITY_EDITOR
        private void OnValidate()
        {
            _speedText.text = $"{_speedSlider.value:F1}";
        }
#endif

        private void Start()
        {
            _speedSlider.onValueChanged.AddListener(OnSpeedChange);
            OnSpeedChange(_speedSlider.value);
        }

        private void OnSpeedChange(float speed)
        {
            onSpeedChange?.Invoke(speed);
            _speedText.text = $"{speed:F1}";
        }
    }
}