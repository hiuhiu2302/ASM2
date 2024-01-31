using UnityEngine;

public class emety_dichuyen : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool shouldTurnAround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (!shouldTurnAround)
        {
            // Di chuyển đối tượng
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        else
        {
            // Quay đầu lại khi va chạm
            speed = -speed;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.Rotate(0f, 180f, 0f);
            // Đặt lại trạng thái quay đầu
            shouldTurnAround = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra va chạm với đối tượng có tag là "TagDat"
        if (collision.gameObject.CompareTag("TagDat"))
        {
            // Đặt trạng thái quay đầu khi va chạm
            shouldTurnAround = true;
        }
    }

   
}
