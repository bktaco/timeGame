using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    List<float> nums = new List<float>();
    private Rigidbody2D rb;
    private float moveSpeed = 10f;

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
            nums.Add(Input.GetAxisRaw("Horizontal"));
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Playback");
        }
    }

    IEnumerator Playback()
    {
        for (int i = 0; i < nums.Count; i += 1)
        {
            rb.velocity = new Vector2(moveSpeed * nums[i], rb.position.y);
            yield return new WaitForSeconds(1);
        }
        nums = new List<float>();
    }
}
