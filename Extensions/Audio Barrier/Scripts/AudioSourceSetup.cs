using UnityEditor;
using UnityEngine;
#if YNL_EDITOR
using YNL.Editors.Extensions;
#endif
#if YNL_UTILITIES
using YNL.Extensions.Methods;
#endif

namespace YNL.Audios.Barrier
{
    public class AudioSourceSetup : MonoBehaviour
    {
        private SphereCollider _collider;

        private void Awake()
        {
#if YNL_UTILITIES
            _collider = this.GetOrAddComponent<SphereCollider>();
            _collider.radius = 0.2f;
            _collider.isTrigger = true;
#endif
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AudioSourceSetup))]
    public class AudioSourceEditor : Editor
    {
        private AudioSourceSetup _main;
        private AudioSource _source;

        private void OnEnable()
        {
            _main = this.target as AudioSourceSetup;

#if YNL_EDITOR
            EditorTag.AddTag("Audio Source");
            _main.gameObject.tag = "Audio Source";
#endif
#if YNL_UTILITIES
            _source = _main.GetOrAddComponent<AudioSource>();
#endif
        }

        public override void OnInspectorGUI() { }
    }
#endif
}