using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //public or private identify
    //data type (int, float, bool, strings)
    //every variable has a NAME
    //optional value assigned

    //laser object projectile
    [SerializeField]
    private GameObject _laserPrefab;

    //fire cooldown
    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;


    [SerializeField]
    private float _speed = 10.0f;


	// Use this for initialization
	void Start () {
        // set new position
        transform.position = new Vector3(0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
        movement();

        //if space key is pressed
        //spawn laser at player position
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();   
        }
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        }
    }

    private void shoot()
    {
        if (Time.time > _canFire)
            {
                //spawns laser
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);

                _canFire = Time.time + _fireRate;
            }
            
    }
}
