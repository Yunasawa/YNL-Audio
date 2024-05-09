#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using YNL.Editors.Extensions;
using YNL.Extensions.Methods;

namespace YNL.Audio.Barrier
{
    [CustomEditor(typeof(AudioBarrier), true)]
    public class AudioBarrierEditor : Editor
    {
        private AudioBarrier _main;
        private Transform _target;
        private Vector3 _position;
        private float _size;
        private float _halfSize;
        private float _thickness = 1;

        private void OnSceneGUI()
        {
            _main = this.target as AudioBarrier;
            _position = _main.transform.position;
            _size = _main.Size;

            if (_main.Size < 0) _main.Size = 0;

            if (Camera.current == null) _target = _main.transform;
            else _target = Camera.current.transform;

            Handles.color = Color.yellow;
            if (_main.Type == AudioBarrier.BarrierType.Sphere)
            {
                Handles.DrawWireDisc(_position, _main.transform.up, _size, _thickness);
                Handles.DrawWireDisc(_position, _main.transform.forward, _size, _thickness);
                Handles.DrawWireDisc(_position, _main.transform.right, _size, _thickness);

                Handles.DrawWireDisc(_position, _target.forward, _size, _thickness);

                Handles.DrawLine(_position.SetX(_position.x - _size), _position.SetX(_position.x + _size), _thickness);
                Handles.DrawLine(_position.SetZ(_position.z - _size), _position.SetZ(_position.z + _size), _thickness);
            }
            else if (_main.Type == AudioBarrier.BarrierType.Box)
            {
                _halfSize = _size / 2;

                MDrawer.DrawWireBox(_position, _size, _size, _size, _thickness);
                MDrawer.DrawWireBox(_position.AddY(-_halfSize), _size, _halfSize, _size, _thickness);

                Handles.DrawLine(_position.SetX(_position.x - _size), _position.SetX(_position.x + _size), _thickness);
                Handles.DrawLine(_position.SetZ(_position.z - _size), _position.SetZ(_position.z + _size), _thickness);
            }

            EditorLayer.AddLayer("Audio Barrier");
            EditorTag.AddTag("Audio Source");
            EditorTag.AddTag("Audio Listener");
        }
    }
}
#endif