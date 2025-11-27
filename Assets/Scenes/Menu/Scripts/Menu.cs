using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void SwampMap(string MapName)
    {
        SceneManager.LoadScene(MapName);
    }

}
