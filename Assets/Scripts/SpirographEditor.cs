using UnityEditor;
using UnityEngine;



[CanEditMultipleObjects, CustomEditor(typeof(Spirograph))]
public class SpirographEditor : Editor
{
    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnInspectorGUI()
    // -------------------------------------------------------------------------

    #region .  OnInspectorGUI()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnInspectorGUI()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Spirograph controller = target as Spirograph;

        EditorGUILayout.Space(5);

        GUILayout.BeginHorizontal();

            if (GUILayout.Button("Stop"))
            {
                controller.ClearLineVisuals();
            }

        GUILayout.EndHorizontal();

    }   //  OnInspectorGUI()
    #endregion


}   // class SpiroGraphEditor
