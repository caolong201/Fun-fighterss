using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    public GameObject dialogShop;
    public GameObject Settings;
    public GameObject MainRocket;
    public float move = 2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneOne()
    {
        int currentSceneIndexx = SceneManager.GetActiveScene().buildIndex;// SceneManager.GetActiveScene(): Lệnh này dùng để lấy cảnh (scene) đang hoạt động.
        int load = currentSceneIndexx + 1;
        SceneManager.LoadScene(load);
    }
    public void ShowDialog()
    {
        dialogShop.transform.DOLocalMoveX(0, move);
        MainRocket.SetActive(false);
    }

    public void ClosdShop()
    {

        dialogShop.SetActive(false);
        MainRocket.SetActive(true);
    }

    public void Setting()
    {
        Settings.transform.DOLocalMoveY(0, move);
       MainRocket.SetActive(false);
    }
}
