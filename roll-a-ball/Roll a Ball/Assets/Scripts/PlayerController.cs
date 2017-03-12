using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        this.count = 0;
        this.SetCountText();
        this.winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update is called before physics
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            this.count = this.count + 1;
            this.SetCountText();
        }
    }

    private void SetCountText()
    {
        this.countText.text = "Count: " + this.count.ToString();
        if(this.count >= 12)
        {
            this.winText.text = "You win!";
        }
    }
}
