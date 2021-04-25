using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kira
{
    public class FaceSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Character_SO _character;
        [SerializeField] private Image _image;

        private void Awake() => RefreshImage();

#if UNITY_EDITOR
        private void OnValidate() => RefreshImage();
#endif

        private void RefreshImage() => _image.sprite = _character.Face;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                CharacterManager.Instance.SetTopFace(_character);
            }
            else if (eventData.button == PointerEventData.InputButton.Left)
            {
                CharacterManager.Instance.SetBottomFace(_character);
            }
        }
    }
}