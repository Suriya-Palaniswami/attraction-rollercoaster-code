using UnityEngine;

namespace DreamPark.Attractions.RollerCoaster
{
    public class RCTrackController : MonoBehaviour
    {
        [Tooltip("Ordered waypoints the cart will follow")]
        public Transform[] trackPoints;
        public float gizmoSize = 0.05f;

        public int Count => trackPoints?.Length ?? 0;
        public Vector3 GetPoint(int i) => trackPoints[i].position;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (trackPoints == null || trackPoints.Length < 2) return;
            for (int i = 0; i < trackPoints.Length; i++)
            {
                Gizmos.DrawSphere(trackPoints[i].position, gizmoSize);
                if (i + 1 < trackPoints.Length)
                    Gizmos.DrawLine(trackPoints[i].position, trackPoints[i + 1].position);
            }
        }
#endif
    }
}
