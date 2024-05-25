#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEditor;
using UnityEngine;
using YNL.Audios.AudioBarrier;
using YNL.Editors.Extensions;
using YNL.Extensions.Methods;

public partial class AudioSourceSetupEditor : Editor
{
    private AudioSourceSetup _main;
    private AudioSource _source;

    private void OnEnable()
    {
        _main = this.target as AudioSourceSetup;

        EditorTag.AddTag("Audio Source");
        _main.gameObject.tag = "Audio Source";

        _source = _main.GetOrAddComponent<AudioSource>();
    }

    public override void OnInspectorGUI() { }
}
#endif
#endif
#endif