using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    List<float> nums = new List<float>();
    List<Vector2> movement = new List<Vector2>();
    private Rigidbody2D rb;
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.A)))
        {
            var x = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            movement.Add(x);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("PlayBack");
        }
    }

    IEnumerator PlayBack()
    {
        for (int i = 0; i < movement.Count; i++)
        {
            Debug.Log(movement[i].x);
            rb.velocity = new Vector2(moveSpeed * movement[i].x, movement[i].y);
            yield return new WaitForSeconds(1);
        }

    }
}
