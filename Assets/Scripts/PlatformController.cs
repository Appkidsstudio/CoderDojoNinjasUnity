﻿using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

    [Header("Platform")]
    public GameObject platform;

    [Header("Activate Movement")]
    public bool moveX;
    public bool moveY;
    public bool moveZ;

    [Header("Movement Speeds")]
    public float speedY;
    public float speedX;
    public float speedZ;

    [Header("X Limit")]
    public bool useXLimit;
    public float XLimitAmount;

    private float _platformStartX;
    private float _minXPosition;
    private float _maxXPosition;

    [Header("Y Limit")]
    public bool useYLimit;
    public float YLimitAmount;

    private float _platformStartY;
    private float _minYPosition;
    private float _maxYPosition;

    [Header("Z Limit")]
    public bool useZLimit;
    public float ZLimitAmount;

    private float _platformStartZ;
    private float _minZPosition;
    private float _maxZPosition;

    // Use this for initialization
    void Start () {
        _platformStartX = platform.transform.position.x;
        _platformStartY = platform.transform.position.y;
        _platformStartZ = platform.transform.position.z;

        _minYPosition = _platformStartY - YLimitAmount;
        _maxYPosition = _platformStartY + YLimitAmount;

        _minXPosition = _platformStartX - XLimitAmount;
        _maxXPosition = _platformStartX + XLimitAmount;

        _minZPosition = _platformStartZ - ZLimitAmount;
        _maxZPosition = _platformStartZ + ZLimitAmount;
    }
	
	// Update is called once per frame
	void Update () {

        movePlatforms();
    }

    private void movePlatforms() {

        if (moveX){

            if (useXLimit){

                if (platform.transform.position.x > _maxXPosition) { speedX = speedX * -1; }
                if (platform.transform.position.x < _minXPosition) { speedX = speedX * -1; }
            }

            platform.transform.Translate(Vector3.right * (speedX / 1000));
        }

        if (moveY){

            if (useYLimit){

                if (platform.transform.position.y > _maxYPosition) { speedY = speedY * -1; }
                if (platform.transform.position.y < _minYPosition) { speedY = speedY * -1; }
            }

            platform.transform.Translate(Vector3.up * (speedY / 1000));

        }

        if (moveZ){

            if (useZLimit){

                if (platform.transform.position.z > _maxZPosition) { speedZ = speedZ * -1; }
                if (platform.transform.position.z < _minZPosition) { speedZ = speedZ * -1; }
            }

            platform.transform.Translate(Vector3.forward * (speedZ / 1000));
        }
    }
}