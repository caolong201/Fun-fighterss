using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 StarttingPosition;// lưu lại vị trí ban đầu của đối tượng khi trò chơi bắt đầu.
    [SerializeField] Vector3 movementVector; //Một vector 3 chiều chỉ định hướng di chuyển của đối tượng.
/*    [SerializeField][Range(0,1)]*/ float movementFactor; //sẽ bị giới hạn trong khoảng từ 0 đến 1 khi được chỉnh sửa 
    [SerializeField] float period = 2f;
    void Start()
    {
        StarttingPosition = transform.position; // vị trí bắt đầu sẽ = vị trí ban đầu

    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // so sánh với 0 bằng 0 hay  gần bằng 0 biểu thị giá trị float dương nhỏ nhất lớn hơn 0 
        float cycles = Time.time / period; // chu kỳ thời gian , khi  period thành 0 sẽ sãy ra lổi bất kề thời gian bn /0 lổi 
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau); // sóng sine đi từ -1 đến 1 

        // chuyển đổi movementFactor
        movementFactor = (rawSinWave + 1f) / 2f;


        Vector3 offset = movementVector * movementFactor; //là sự dịch chuyển một đối tượng từ vị trí gốc của  Xáịnh hướng và mức độ dịch chuyển của đối tượng theo tỷ lệ của movementFactor.
        transform.position = StarttingPosition + offset;


    }
}
