using KingoBoiii.AgeOfWarClone.UI;
using UnityEditor;
using UnityEditor.UI;

namespace KingoBoiii.UnityEditor
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(BuyUnitButton), true)]
    internal sealed class BuyUnitButtonEditor : SelectableEditor
    {
        private SerializedProperty onClickProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            onClickProperty = serializedObject.FindProperty("_onClick");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            serializedObject.Update();
            EditorGUILayout.PropertyField(onClickProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }

}
