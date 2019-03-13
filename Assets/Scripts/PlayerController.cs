using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Text countText;
    public Text winText;

    private GameObject[] allPickups;
    private int count;

    private void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        allPickups = GameObject.FindGameObjectsWithTag("Pickup");
        UpdateCountText();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            count += 1;
            UpdateCountText();
        }
    }

    private void UpdateCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= allPickups.Length)
        {
            winText.text = "YOU WON";
            winText.gameObject.SetActive(true);
        }
    }
}
