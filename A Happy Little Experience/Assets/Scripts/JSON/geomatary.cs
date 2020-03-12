﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geomatary : MonoBehaviour
{
    public static geomatary instance;
    public int cube_id;
    public Vector3 cube_positions;
    public GameObject cube;

    private float moveH, moveV;

    [SerializeField] private float moveSpeed;

    void Start()
    {
       cube_id = 1;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);

            }
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        cube_positions = this.gameObject.transform.position;

        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
        cube_positions = new Vector2(moveH, moveV);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DIE!!!!!!!!!!!!!!!!");
            Destroy(cube);
        }
    }
}