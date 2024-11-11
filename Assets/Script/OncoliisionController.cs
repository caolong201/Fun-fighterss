using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Windows.WebCam.VideoCapture;

public class OncoliisionController : MonoBehaviour
{

    [SerializeField] float TimeLoad = 2f;
    [SerializeField] AudioClip collisionRocket;
    [SerializeField] AudioClip nextLV;
    [SerializeField] ParticleSystem ParticleFailure;
    [SerializeField] ParticleSystem ParticleSuccess;
    ParticleSystem ParticRocket;
    AudioSource AudioCollision;
    Collider Collider;
    //AudioSource NextLevels;
    bool Audiostatus = false;
    bool ColliderKey = false;
    void Start()
    {
        //ParticRocket = GetComponent<ParticleSystem>();
        AudioCollision = GetComponent<AudioSource>();
        Collider = GetComponent<Collider>();
    }

    private void Update()
    {
        KeyLevel();
   
    }
 
    void KeyLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadLVTime();
            ParticleSuccess.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ColliderKey = !ColliderKey; //ColliderKeythành falsevà sau đó chuyển thành true.
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (Audiostatus || ColliderKey) { return; } // phương thức kiểm tra xem Audiostatus đã là true chưa, Nếu đã là , nó sẽ ngay lập tức thoát khỏi phương thức{ return; }Điều này ngăn chặn bất kỳ thực thi mã nào nữa cho va chạm này, đảm bảo rằng âm thanh không phát nhiều lần cho cùng một sự kiện.
        {
            switch (other.gameObject.tag)            //ColliderKey thành true vô hiệu hóa va chạm
            {
                case "Fridendly":
                    Debug.Log(" xuat phat");
                    break;
                case "Finish":
                    LoadLVTime();
                    //NextLevel();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }
    }


    public void LoadLVTime()
    {
        Audiostatus = true;//Audiostatus đã là true ,nhằm ngăn chặn âm thanh tiếp theo phát trong chuỗi này.
        AudioCollision.Stop();//Khi phương thức này được thực thi, nó **ngay lập tức dừng bất kỳ âm thanh nào** hiện đang phát qua `AudioSource`. -
        AudioCollision.PlayOneShot(nextLV);
        ParticleSuccess.Play();// kích hoạt hạt khi chạm đích
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", TimeLoad);
    }
    public void StartCrashSequence()
    {
       
        Audiostatus = true; //Audiostatus đã là true ,nhằm ngăn chặn âm thanh tiếp theo phát trong chuỗi này.
        AudioCollision.Stop();
        AudioCollision.PlayOneShot(collisionRocket);
        ParticleFailure.Play();// kích hoạt hạt khi va chạm
        GetComponent<Movement>().enabled = false;
        Invoke("failure", TimeLoad);
    }
    void failure()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//sử dụng chỉ số đó để tải lại cảnh chính đó
        SceneManager.LoadScene(currentSceneIndex);
        //SceneManager.GetActiveScene():Lệnh này trả về đại diện Scene tượng trưng cho cảnh hiện đang được tải trong trò chơi.
        //.buildIndex: Đây là thuộc tính của đối tượng Scene trả về chỉ số(chỉ mục) của cảnh trong Cài đặt bản dựng.
        //    }
    }

    public void NextLevel()
    {
        int currentSceneIndexx = SceneManager.GetActiveScene().buildIndex;
        int LoadLevel = currentSceneIndexx + 1; // xác định cảnh tiếp theo bằng cách cộng thêm 1 vào chỉ số của cảnh hiện tại, rồi lưu giá trị này vào biến LoadLevel.

        if (LoadLevel == SceneManager.sceneCountInBuildSettings)  //SceneManager.sceneCountInBuildSettings tong all cac scen trong buil Setting
        {
            LoadLevel = 0;
        }
      
        SceneManager.LoadScene(LoadLevel);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;// ấy cảnh hiện tại đang chạy trong Unity.
// trả về chỉ số của cảnh hiện tại trong Build Settings. Chỉ số này là một số nguyên đại diện cho thứ tự của cảnh khi được thêm vào Build Settings.
        SceneManager.LoadScene(currentSceneIndex);// tải lại cảnh hiện tại bằng cách nạp lại nó từ đầu.
    }

}
