#if UNITY_EDITOR && YNL_EDITOR && YNL_UTILITIES
using UnityEditor;
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Flexs;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Addons;
using YNL.Editors.UIElements.Plained;
using YNL.Audios.Statics;
using YNL.Editors.Utilities;

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
                .AddDocumentation(StaticLink.AudioBarrierDocumentation)
                .AddBottomSpace(10));

            FlexElementGroup _container = new FlexElementGroup()
            .AddElements(new PlainedFloatField(_propertySize).SetAsHorizontalBox().SetLabelWidth(40).SetFontDefinition(EditorFontAsset.Somatic))
            .AddVSpace(5)
            .AddElements(new EnableGizmosBox(_propertyEnableGizmos, "Gizmos"));

            _root.AddElements(_container, new BarrierTypeBox(_propertyType));
        }
    }
}
#endif