using UnityEngine;

namespace Kira
{
    [CreateAssetMenu]
    public class Character_SO : ScriptableObject
    {
        [SerializeField]
        private Sprite _face;

        [SerializeField, Range(0, 2)]
        private float _scale = 1.0f;

        public Sprite Face => _face;
        public float Scale => _scale;
    }
}