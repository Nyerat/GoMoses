using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOnContact : MonoBehaviour
{
    public PlayerController player;

    private Rigidbody2D rb2d;

    public float knockback;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        rb2d = GetComponent<Rigidbody2D>();
    }

    





}
