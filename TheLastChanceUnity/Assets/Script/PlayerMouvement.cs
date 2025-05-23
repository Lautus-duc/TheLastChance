using UnityEngine;
using System;
using Photon.Pun;
public class PlayerMouvement : MonoBehaviourPun
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    GameObject InventaryGO;
    [SerializeField]
    Vector2 dir;
    [SerializeField]
    Animator anim;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    GameObject InventoryCanvas;
    public bool isHere;
    public MonoBehaviour[] componentsToDisable;
    void Start()
    {
        if (!photonView.IsMine)
        {
            foreach (var comp in componentsToDisable)
            {
                comp.enabled = false;
            }
        }
        else
        {
            Camera cam = GetComponentInChildren<Camera>();
            cam.gameObject.SetActive(true);

            FindFirstObjectByType<UIManager>().HideTransition();
        }
        isHere = true;

    }
    void Update()
    {
        if (!photonView.IsMine) return;
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            isHere = false;
            InventaryGO.SetActive(true);
        }
        else if (isHere)
        {
            //Mouvement du Hero
            dir.x = Input.GetAxisRaw("Horizontal");
            dir.y = Input.GetAxisRaw("Vertical");
            if ((dir.x == 1 || dir.x == -1) && (dir.y == 1 || dir.y == -1))
            {
                dir.x *= 3f / 4f;
                dir.y *= 3f / 4f;
            }
            rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
            SetParam();
            spriteRenderer.sortingOrder = -(int)Math.Floor(rb.position.y);
        }
        else
        {
            if (!InventoryCanvas.activeInHierarchy) isHere = true;
        }
    }
    public void IsBackInGame()
    {
        InventaryGO.SetActive(false);
        isHere = true;
    }
    void SetParam()
    {
        if (dir.x == 0 && dir.y == 0)
        {
            anim.SetInteger("direction", 0);
        }
        else if (dir.y < 0) //bas
        {
            anim.SetInteger("direction", 1);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x > 0) //droite
        {
            anim.SetInteger("direction", 2);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x < 0) //gauche
        {
            anim.SetInteger("direction", 2);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.y > 0) //haut
        {
            anim.SetInteger("direction", 3);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public Camera playerCamera;
    public void HandleDeath()
    {
        playerCamera.transform.SetParent(null);

        playerCamera.gameObject.AddComponent<CameraAfterDeath>();

        PhotonNetwork.Destroy(gameObject); // ou Destroy(gameObject)
    }
}