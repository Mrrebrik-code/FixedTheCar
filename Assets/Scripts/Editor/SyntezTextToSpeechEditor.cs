using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Itibsoft.TextToSpeech.Syntez;

public class SyntezTextToSpeechEditor : EditorWindow
{
    private string _syntexTextDownload;
    private string _isId;
    private string _syntexIdDownload;
    [MenuItem("Tools/Syntez", false, 13)]
    static void OpenWindow()
    {
        SyntezTextToSpeechEditor window = GetWindow<SyntezTextToSpeechEditor>();

        window.Show();
    }
    private bool _satusSuntez;
    private void OnGUI()
    {
        EditorGUILayout.HelpBox("Status: " + _satusSuntez.ToString(), MessageType.None);
        _syntexTextDownload = EditorGUILayout.TextField("Text to convert", _syntexTextDownload);
        _syntexIdDownload = EditorGUILayout.TextField("Id to convert", _syntexIdDownload);
        _isId = EditorGUILayout.TextField("Id", _isId);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Connect"))
        {
            _satusSuntez = SyntezDownload.Instance.ConnectToGTTS();
        }
        if (GUILayout.Button("Download"))
        {
            SyntezDownload.Instance.SynthesizeHandler(_syntexTextDownload, "Russian");
        }
        GUILayout.EndHorizontal();
    }
}
