using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class comandos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void irPara(string _cena)
    {
        SceneManager.LoadScene(_cena);
    }

    public void exitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        
    }
}
