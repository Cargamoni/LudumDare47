﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

    public static Player instance;

    public Transform exit;

    public Camera cam;
    public AudioSource heartbeat;
    public Material mat;

    private Rigidbody rb;
    public Collider camCollider;

    private RaycastHit hit;
    private Rigidbody objectBody;
    private Vector3 objectPosition;
    private bool isDeath;
    private float exitDistance;
    private FirstPersonController controller;

    public float walkSpeed;
    public float runSpeed;

    private void Awake() {
        instance = this;
        exitDistance = Vector3.Distance(transform.position, exit.position);
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<FirstPersonController>();
    }

    public void die() {
        if (isDeath) return;
        rb.isKinematic = false;
        enabled = false;
        isDeath = true;
        camCollider.enabled = true;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
        cam.GetComponent<Cam>().enabled = false;
        UIManager.instance.ChangeScreen((int)Screens.Lose);
    }

    private void Update() {

        if (isDeath) return;
        if (Input.GetKeyDown(KeyCode.K)) die();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameManager.currentState = GameStates.Menu;
            SceneManager.LoadScene("Play");
        }

        if (objectBody != null) {
            controller.m_WalkSpeed = walkSpeed * 0.25f;
            controller.m_RunSpeed = runSpeed * 0.25f;
        }
        else {
            controller.m_WalkSpeed = walkSpeed;
            controller.m_RunSpeed = runSpeed;
        }


        var dist = Vector3.Distance(transform.position, exit.position);
        var blood = Mathf.Clamp01(dist / exitDistance);
        mat.SetFloat("_Blood", blood);
        heartbeat.pitch = 1f + blood * 0.5f;


        if (transform.position.y < 0) die();

        //al
        var actionText = "";

        if (!GameManager.IsPlaying()) return;
        
        if (objectBody == null) {

            if (Physics.Raycast(cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), out hit, 2f)) {

                //obje kullanılabilir mi?
                var action = hit.collider.GetComponent<Action>();
                if (action != null) {

                    //text göster
                    actionText = action.getText();

                    //kullan
                    if (Input.GetMouseButtonDown(0)) {
                        action.invoke();
                    }

                }

                //al
                else if (hit.collider.CompareTag("Pickup")) {
                    if (Input.GetMouseButtonDown(0)) {
                        objectBody = hit.rigidbody;
                        objectBody.useGravity = false;
                        objectBody.transform.SetParent(Player.instance.cam.transform);
                        objectPosition = objectBody.transform.localPosition;
                    }
                    else {
                        actionText = "taşı";
                    }
                }

            }

            //action temizle
            else {
                ActionText.instance.setText("");
            }

        }

        //bırak
        else if (Input.GetMouseButtonUp(0)) {
            objectBody.isKinematic = false;
            objectBody.useGravity = true;
            objectBody.transform.SetParent(null);
            objectBody = null;
        }

        //fırlat
        else if(Input.GetMouseButtonDown(1)) {
            objectBody.isKinematic = false;
            objectBody.useGravity = true;
            objectBody.transform.SetParent(null);
            objectBody.AddForce(Player.instance.cam.transform.forward * 500f, ForceMode.Acceleration);
            objectBody = null;
        }

        //durdur
        if (objectBody != null) {
            objectBody.velocity = Vector3.zero;
            objectBody.angularVelocity = Vector3.zero;
            objectBody.transform.localPosition = Vector3.Lerp(objectBody.transform.localPosition, objectPosition, 1f * Time.deltaTime);
        }

        //text güncelle
        ActionText.instance.setText(actionText);

    }

}