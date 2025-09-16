using UnityEngine;

namespace DreamPark.Attractions.RollerCoaster
{
    [RequireComponent(typeof(Rigidbody))]
    public class RCCartController : MonoBehaviour
    {
        public RCTrackController track;
        public RollerCoasterConfig config;
        public int startIndex = 0;

        Rigidbody _rb;
        int _idx;
        Vector3 _target;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (track == null || track.Count == 0) return;
            _idx = Mathf.Clamp(startIndex, 0, track.Count - 1);
            _target = track.GetPoint(_idx);
        }

        void FixedUpdate()
        {
            if (track == null || track.Count == 0) return;

            Vector3 toTarget = _target - transform.position;
            float dist = toTarget.magnitude;

            if (dist < 0.1f)
            {
                _idx = (_idx + 1) % track.Count;
                _target = track.GetPoint(_idx);
                toTarget = _target - transform.position;
            }

            Vector3 dir = toTarget.normalized;
            float targetSpeed = config ? config.maxSpeed : 10f;
            Vector3 desiredVel = dir * targetSpeed;

            Vector3 delta = desiredVel - _rb.velocity;
            float accel = config ? config.accel : 5f;
            _rb.AddForce(Vector3.ClampMagnitude(delta, accel), ForceMode.Acceleration);
        }
    }
}
