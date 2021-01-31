using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryRunner : MonoBehaviour
{
    [SerializeField] int pageId;
    [SerializeField] GameObject[] storyImage;
    [SerializeField] int nextSceneId;

    private void Start()
    {
        for (int i = 0; i < storyImage.Length; i++)
        {
            storyImage[i].SetActive(false);
        }
        storyImage[0].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            storyImage[pageId].SetActive(false);
            pageId++;
            print(pageId + ":" + storyImage.Length);
            if (pageId == storyImage.Length) SceneManager.LoadScene(nextSceneId);
            //if (pageId < storyImage.Length) print("small");
            else storyImage[pageId].SetActive(true);
        }
    }
}
