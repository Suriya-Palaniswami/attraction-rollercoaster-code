using UnityEngine;

namespace DreamPark.Attractions.RollerCoaster
{
    [CreateAssetMenu(menuName = "DreamPark/RollerCoaster/Config")]
    public class RollerCoasterConfig : ScriptableObject
    {
        [Range(1f, 50f)] public float maxSpeed = 18f;
        [Range(0.1f, 20f)] public float accel = 6f;
        public AnimationCurve brakeCurve = AnimationCurve.Linear(0, 0, 1, 1);
    }
}
