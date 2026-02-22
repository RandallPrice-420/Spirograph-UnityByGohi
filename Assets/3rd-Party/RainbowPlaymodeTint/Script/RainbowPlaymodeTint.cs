using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System;


/* Created by PEROT Nicolas: https://nicolas-perot.go.yj.fr/ the 14/10/2022 with Unity 2020.3.17f1
 * 
 * Help with this forum for search the field of Playmode Tint in the Assembly: https://answers.unity.com/questions/759634/unity-editor-playmode-tint-change-by-script.html
 * 
 */

#if UNITY_EDITOR
public class RainbowPlaymodeTint : MonoBehaviour
{
    public static RainbowPlaymodeTint Instance { get; private set; }

    public Color ActualColorDebug;
    public float SpeedColor = 0.05f;
    public Color StartColor = new(1f, 0.5f, 0.5f, 1f);

    private float H;
    private float S;
    private float V;

    private static FieldInfo m_PrefsField     = null;
    private static FieldInfo m_PrefColorField = null;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }   // Awake()

    private static Type GetEditorType(string aName)
    {
        return typeof(Editor).Assembly.GetTypes().Where((a) => a.Name == aName).FirstOrDefault();

    }   // GetEditorType()


    private static object GetPref(string aName)
    {
        return ((SortedList<string, object>)m_PrefsField.GetValue(null))[aName];

    }   // GetPref()



    private void Start()
    {
        // Setup first color RGB to HSV.
        Color.RGBToHSV(StartColor, out H, out S, out V);

        Type settingsType = GetEditorType("PrefSettings")
            ;
        Type prefColorType = GetEditorType("PrefColor");
        if (settingsType == null || prefColorType == null)
        {
            Debug.Log("settingsType or prefColorType have changed types cause to different Unity version");
        }

        m_PrefsField = settingsType.GetField("m_Prefs", BindingFlags.Static | BindingFlags.NonPublic);
        m_PrefColorField = prefColorType.GetField("m_Color", BindingFlags.Instance | BindingFlags.NonPublic);

    }   // Start()


    private void Update()
    { 
        // Rainbow fade.
        H += Time.deltaTime * SpeedColor;
        H  = Mathf.Min(1f, H);
        if (H >= 1) H = 0; //Loop Rainbow

        // Convert HSV to RGB.
        Color rgb = Color.HSVToRGB(H, S, V);
        ActualColorDebug = rgb;

        object p = GetPref("Playmode tint");

        // Change the field Playmode Tint in "Edit/Preferences/Colors/Playmode tint".
        m_PrefColorField.SetValue(p, rgb);

        // Change the regedix line (Synchronisation between windows. Tool bars only on highlight).
        EditorPrefs.SetString("Playmode tint", "Playmode tint;" + rgb.r.ToString()+ ";" + rgb.g.ToString() + ";" + rgb.b.ToString() + ";" + rgb.a.ToString());

    }   // Update()


}   // class RainbowPlaymodeTint


public class PlaymodeTintWindow : EditorWindow
{
    private bool  _scriptCreated = false;
    private float _speedColor    = 0.05f;
    private Color _startColor    = new(1f, 0.5f, 0.5f, 1f);



    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/==== Rainbow Playmode Tint Window ====")]



    private void Awake()
    {
        RainbowPlaymodeTint script = FindFirstObjectByType<RainbowPlaymodeTint>();
        _scriptCreated = (script != null);

    }   // Awake()


    private static void Init()
    {
        // Get existing open window or if none, make a new one:
        PlaymodeTintWindow window = (PlaymodeTintWindow)EditorWindow.GetWindow(typeof(PlaymodeTintWindow));
        window.Show();

    }   // Init()


    private void OnGUI()
    {
        GUILayout.Label("Rainbow Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);
        _speedColor = EditorGUILayout.FloatField("Speed Color", _speedColor);
        _startColor = EditorGUILayout.ColorField("Start Color", _startColor);
        GUILayout.Space(20);

        if (!_scriptCreated)
        {
            if (GUILayout.Button("Create the Rainbow Component"))
            {
                if (FindFirstObjectByType<RainbowPlaymodeTint>() == null)
                {
                    GameObject gameObject = new()
                    {
                        name = "Rainbow Playmode Tint"
                    };
                    gameObject.AddComponent<RainbowPlaymodeTint>().SpeedColor = _speedColor;
                    gameObject.GetComponent<RainbowPlaymodeTint>().StartColor = _startColor;
                    _scriptCreated = true;
                }
            }
        }
        else
        {
            if (GUILayout.Button("Delete the Rainbow Component"))
            {
                RainbowPlaymodeTint script = FindFirstObjectByType<RainbowPlaymodeTint>();
                if (script != null)
                {
                    DestroyImmediate(script.gameObject);
                }
                _scriptCreated = false;
            }
        }

    }   // OnGUI()


}   // class PlaymodeTintWindow
#endif