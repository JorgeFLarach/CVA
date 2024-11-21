// FOR PLAY TESTING IN UNITY, 
// EACH TIME YOU START A NEW GAME, OR PRESS PLAY, YOU MUST UNCOMMENT THIS CODE AND RUN IT. THEN YOU CAN COMMENT THIS CODE
// OUT AND PLAY THE GAME LIKE NORMAL


using UnityEditor;
using UnityEngine;

[InitializeOnLoad]  
public class ClearPlayerPrefsOnPlay
{
    static ClearPlayerPrefsOnPlay(){
        EditorApplication.playModeStateChanged += ClearPlayerPrefsOnPlayModeChange;
    }


    private static void ClearPlayerPrefsOnPlayModeChange(PlayModeStateChange state){
        // Check if Unity is entering play mode
        if (state == PlayModeStateChange.EnteredPlayMode) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        
        }
       }
}




