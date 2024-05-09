using System.Collections.Generic;
using UnityEngine;
using YNL.Extensions.Methods;

namespace YNL.Audio.Barrier
{
    public class AudioBarrier : MonoBehaviour
    {
        public enum BarrierType { Sphere, Box }

        public float Size = 5;
        public BarrierType Type = BarrierType.Box;

        private BoxCollider _boxCollider;
        private SphereCollider _sphereCollider;
        private Rigidbody _rigid;

        private List<Transform> _sources = new();
        private Transform _listener;

        public LayerMask Layer;

        private const float _multiply = 3;

        private Vector3 _position => this.transform.position;

        public bool EnableGizmos = false;

        private void Awake()
        {
            if (Type == BarrierType.Box)
            {
                _boxCollider = this.gameObject.AddComponent<BoxCollider>();
                _boxCollider.size = Vector3.one * Size * 2f;
                _boxCollider.isTrigger = true;
            }
            else if (Type == BarrierType.Sphere)
            {
                _sphereCollider = this.gameObject.AddComponent<SphereCollider>();
                _sphereCollider.radius = Size;
                _sphereCollider.isTrigger = true;
            }

            _rigid = this.gameObject.AddComponent<Rigidbody>();
            _rigid.isKinematic = true;
        }

        private void OnValidate()
        {
            if (_boxCollider == null) return;
            _boxCollider.size = Vector3.one * Size * 2f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Audio Listener")
            {
                _listener = other.transform;
            }
            if (other.gameObject.tag == "Audio Source")
            {
                if (!_sources.Contains(other.transform)) _sources.Add(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Audio Listener")
            {
                foreach (var source in _sources) source.localPosition = Vector3.zero;
                _sources.Clear();
                _listener = null;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Audio Listener")
            {
                if (_listener == null) _listener = other.transform;
            }
            if (other.gameObject.tag == "Audio Source")
            {
                if (!_sources.Contains(other.transform)) _sources.Add(other.transform);
                if (_listener == null)
                {
                    foreach (var source in _sources) source.localPosition = Vector3.zero;
                    _sources.Clear();
                }
            }
        }

        private void Update()
        {
            if (_listener == null) return;

            if (Type == BarrierType.Box)
            {
                float right = Size + _position.x - _listener.position.x;
                float left = Size * 2 - right;
                float front = Size + _position.z - _listener.position.z;
                float back = Size * 2 - front;
                float up = Size + _position.y - _listener.position.y;
                float down = Size * 2 - up;
                float min = Mathf.Min(right, left, front, back, up, down);

                foreach (var source in _sources) source.transform.localPosition = Vector3.forward * min;
            }
            else if (Type == BarrierType.Sphere)
            {
                float distance = Size - (this._position - _listener.position).magnitude;

                Vector3 position = Vector3.forward * distance;
                foreach (var source in _sources) source.transform.localPosition = position;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!EnableGizmos) return;

            Vector3 position = _position;
            float halfSize = Size / 2;

            if (Type == BarrierType.Box)
            {
                MDrawer.DrawWireBoxGizmos(position, Size, Size, Size);
                MDrawer.DrawWireBoxGizmos(position.AddY(-halfSize), Size, halfSize, Size);
            }
            else if (Type == BarrierType.Sphere)
            {
                Gizmos.DrawWireSphere(position, Size);

                if (Camera.current == null) return;

                Matrix4x4 oldMatrix = Gizmos.matrix;
                Gizmos.matrix = Matrix4x4.TRS(this.transform.position, Quaternion.LookRotation(Camera.current.transform.up), new Vector3(1, 0, 1));
                Gizmos.DrawWireSphere(Vector3.zero, Size);
                Gizmos.matrix = oldMatrix;
            }
        }
#endif
    }
}