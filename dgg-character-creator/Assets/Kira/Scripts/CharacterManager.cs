using UnityEngine;

namespace Kira
{
    public class CharacterManager : MonoBehaviour
    {
        private Animator _animator;
        private FaceManager _faceBottom;
        private FaceManager _faceTop;

        public static CharacterManager Instance { get; private set; }
        private static readonly int SpeedMultiplier = Animator.StringToHash("Speed");

        private void Init()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("Found multiple character managers!", this);
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            _animator = transform.GetChild(0).GetComponent<Animator>();

            var faces = GetComponentsInChildren<FaceManager>();
            _faceBottom = faces[0];
            _faceTop = faces[1];
        }

        private void Awake()
        {
            Init();
            UiManager.onSpeedChange += UpdateAnimSpeed;
        }

        private void OnDisable() => UiManager.onSpeedChange -= UpdateAnimSpeed;

        private void UpdateAnimSpeed(float speed)
        {
            _animator.SetFloat(SpeedMultiplier, speed);
            _faceTop.UpdateSpeed(speed);
            _faceBottom.UpdateSpeed(speed);
        }

        public void OnSwap()
        {
            var topCharacter = _faceTop.GetCharacter();
            var bottomCharacter = _faceBottom.GetCharacter();

            _faceTop.SetCharacter(bottomCharacter);
            _faceBottom.SetCharacter(topCharacter);
        }

        public void SetTopFace(Character_SO character) => _faceTop.SetCharacter(character);
        public void SetBottomFace(Character_SO character) => _faceBottom.SetCharacter(character);
    }
}