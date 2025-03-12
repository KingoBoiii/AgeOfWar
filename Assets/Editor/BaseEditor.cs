using KingoBoiii.AgeOfWarClone;
using UnityEditor;
using UnityEngine;

namespace KingoBoiii.UnityEditor
{

    [CustomEditor(typeof(Base))]
    internal sealed class BaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var @base = (Base)target;

            if(GUILayout.Button("Age Up!"))
            {
                @base.AgeUp();
            }
        }
    }

}
