using UnityEngine;

namespace Kira
{
    public class FaceManager : MonoBehaviour
    {
        [SerializeField] private Character_SO _character;
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;
        private Animator _animator;
        private static readonly int SpeedMultiplier = Animator.StringToHash("SpeedMultiplier");

        private void Awake()
        {
            _transform = transform;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            RefreshCharacter();
        }

        public void UpdateSpeed(float speed)
        {
            _animator.SetFloat(SpeedMultiplier, speed);
        }

        public Sprite GetSprite() => _spriteRenderer.sprite;

        public void SwapFace(Sprite sprite, Vector3 size)
        {
            _spriteRenderer.sprite = sprite;
            transform.localScale = size;
        }

        public void SetCharacter(Character_SO character)
        {
            _character = character;
            RefreshCharacter();
        }

        public Character_SO GetCharacter() => _character;

        private void RefreshCharacter()
        {
            _spriteRenderer.sprite = _character.Face;
            _transform.localScale = Vector3.one * _character.Scale;
        }
    }
}