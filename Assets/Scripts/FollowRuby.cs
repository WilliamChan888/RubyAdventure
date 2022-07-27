﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRuby : MonoBehaviour
{
    public Transform rubyTransform;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - rubyTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + rubyTransform.position;
    }
}
