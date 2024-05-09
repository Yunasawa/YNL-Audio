using UnityEditor;
using UnityEngine;
using YNL.Editors.Extensions;
using YNL.Extensions.Methods;

namespace YNL.Audio.Barrier
{
    public class AudioListenerSetup : MonoBehaviour
    {
        private SphereCollider _collider;

        private void Awake()
        {
            _collider = this.GetOrAddComponent<SphereCollider>();
            _collider.radius = 0.1f;
            _collider.isTrigger = true;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AudioListenerSetup))]
    public class AudioListenerEditor : Editor
    {
        private AudioListenerSetup _main;

        private void OnEnable()
        {
            _main = this.target as AudioListenerSetup;
            if (!_main.HasComponent<UnityEngine.AudioListener>()) _main.gameObject.AddComponent<UnityEngine.AudioListener>();

            EditorTag.AddTag("Audio Listener");
            _main.gameObject.tag = "Audio Listener";
        }

        public override void OnInspectorGUI() { }
    }
#endif
}