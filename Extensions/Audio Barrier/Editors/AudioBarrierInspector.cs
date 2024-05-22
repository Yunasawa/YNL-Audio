#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEditor;
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Plained;
using YNL.Editors.UIElements.Flexs;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Addons;
using UnityEditor.UIElements;

namespace YNL.Audios.AudioBarrier
{
    [CustomEditor(typeof(AudioBarrier))]
    [CanEditMultipleObjects]
    public partial class AudioBarrierEditor : Editor
    {
        private VisualElement _root;

        private SerializedProperty _propertySize;
        private SerializedProperty _propertyType;
        private SerializedProperty _propertyEnableGizmos;

        public override VisualElement CreateInspectorGUI()
        {
            FindProperties();
            InitializeEditor();
            Compose();
            
            return _root;
        }

        private void FindProperties()
        {
            _propertySize = serializedObject.FindProperty("Size");
            _propertyType = serializedObject.FindProperty("Type");
            _propertyEnableGizmos = serializedObject.FindProperty("EnableGizmos");
        }

        private void InitializeEditor()
        {
            _root = new VisualElement();
        }

        private void Compose()
        {
            _root.AddStyle("Style Sheets/AudioBarrier").SetAsFlexInsppector();

            _root.AddElements(new FlexComponentHeader()
                .SetGlobalColor("#FDC008")
                .AddIcon("Textures/Audio Barrier Icon (White)", MAddressType.Resources)
                .AddTitle("Audio Barrier")
                .AddDocumentation("https://github.com/Yunasawa/YNL-Audio/tree/main/Extensions/Audio%20Barrier"));

            InspectorElement.FillDefaultInspector(_root, serializedObject, this);

            //_root.AddElements(new EFloatField(_propertySize), new EEnumField(_propertyType, "YNL.Audios.AudioBarrier.BarrierType"), new EToggleField(_propertyEnableGizmos));
            //_root.AddHSpace(20);
            //_root.AddElements(new Image().AddClass("Circle"));
        }
    }
}
#endif
#endif
#endif