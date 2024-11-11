using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{

    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float RotateSpeed = 100f;
    [SerializeField] AudioClip mainAudio;
    [SerializeField] private  ParticleSystem MainEnginParticles;
    [SerializeField] ParticleSystem RightMainEnginParticles;
    [SerializeField] ParticleSystem LeftMainEnginParticles;
    AudioSource Rocket;
    Rigidbody Rg;
    OncoliisionController oncoliisionController = new OncoliisionController();
    void Start()
    {
        Rg = GetComponent<Rigidbody>();
        Rocket = GetComponent<AudioSource>();
    }
    void Update()
    {
        jump();
        Movee();
      
    }

  
    public void jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ProcessThrust();
        }
        else
        {
            SoundStop();
        }
    }

    void Movee()
    {
        if (Input.GetKey(KeyCode.A))
        {
            KeyLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            KeyRight();
        }
        else
        {
            ProcessRotation();
        }
        // nếu muốn 2 lực khác nhau thêm biến tốc độ 
        // để phương thức di chuyển có thể được sử dụng mục đính khác,giúp code ngắn gọn hơn
    }

    void ProcessThrust()
    {
        Rg.AddRelativeForce(Vector3.up * moveSpeed * Time.deltaTime);

        if (!Rocket.isPlaying)// nếu âm thanh không phát Rocket.Play(); được gọi Rocket.isPlaying cho biết liệu âm thanh được liên kết với thành phần  Rocket có đang phát hay không.
        {
            Rocket.PlayOneShot(mainAudio);
        }

        if (!MainEnginParticles.isPlaying)
        {
            MainEnginParticles.Play();
        }

    }
 
    void KeyLeft()
    {
        ApplyRotation(RotateSpeed);
        if (!LeftMainEnginParticles.isPlaying)
        {
            LeftMainEnginParticles.Play();
        }
    }
    void KeyRight()
    {
        ApplyRotation(-RotateSpeed);
        if (!RightMainEnginParticles.isPlaying)
        {
            RightMainEnginParticles.Play();
        }
    }
    void ProcessRotation()
    {
        LeftMainEnginParticles.Stop();
        RightMainEnginParticles.Stop();
    }
    void SoundStop()
    {
        Rocket.Stop();
        MainEnginParticles.Stop();
    }
    //thêm 1 biến float thiết lập để có 1  - vector3
    void ApplyRotation(float SpeedRotate)  //truyền giá trị của biến RotateSpeed vào tham số SpeedRotate để phương thức này biết được cần quay đối tượng với tốc độ bao nhiêu.
    {
        Rg.freezeRotation = true; //dừng tính năng quay vật lý của đối tượng để ngăn bất kỳ ảnh hưởng bên ngoài nào làm thay đổi trạng thái quay trong khi người dùng đang điều khiển.
        transform.Rotate(Vector3.forward * SpeedRotate * Time.deltaTime);
        Rg.freezeRotation = false; //Sau khi hoàn thành việc xoay thủ công, tính năng quay vật lý của đối tượng được bật lại để đối tượng có thể phản ứng với lực hoặc va chạm từ môi trường nếu cần thiết.
    }
    // thiết lập tham số của riêng mình chuyển rotate vào vòng quay
}
