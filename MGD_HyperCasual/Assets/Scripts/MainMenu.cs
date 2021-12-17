using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //public SpriteRenderer sr;
    //public List<Sprite> skins = new List<Sprite>();
    //private int selectedSkin = 0;
    //public GameObject playerskin;

    public void PlayGame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selectedskin.prefab");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

//    public void NextOption()
//    {
//        selectedSkin = selectedSkin + 1;
//        if (selectedSkin == skins.Count)
//        {
//            selectedSkin = 0;
//        }
//        sr.sprite = skins[selectedSkin];
//    }

//    public void BackOption()
//    {
//        selectedSkin = selectedSkin - 1;
//        if (selectedSkin < 0)
//        {
//            selectedSkin = skins.Count -1;
//        }
//        sr.sprite = skins[selectedSkin];
//    }
}


