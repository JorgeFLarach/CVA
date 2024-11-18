/*
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]  
public class ClearPlayerPrefsOnPlay
{
    static ClearPlayerPrefsOnPlay(){
        // Subscribe to the play mode state change event
        EditorApplication.playModeStateChanged += ClearPlayerPrefsOnPlayModeChange;
    }

    // This method will be called whenever the play mode state changes
    private static void ClearPlayerPrefsOnPlayModeChange(PlayModeStateChange state){
        // Check if Unity is entering play mode
        if (state == PlayModeStateChange.EnteredPlayMode) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        
        }
       }
}
*/


