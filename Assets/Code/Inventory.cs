using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //public Image image;
    public Sprite empty;
    public Sprite boots;
    public Sprite goggles;
    public Sprite bridge;
    public Sprite key;
    public Sprite bow;
    [SerializeField] private Image[] inventory;

    public bool haveBoots = false;
    public bool haveGoggles = false;
    public bool haveBridge = false;
    public bool haveKey = false;
    public bool haveBow = false;

    int speed = -25;

    private void Start()
    {
        updateInventory();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed*Time.deltaTime, 0, Space.World) ;      
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Boots":
                Destroy(other.gameObject);
                haveBoots = true;
                break;

            case "Bow":
                Destroy(other.gameObject);
                haveBow = true;
                break;

            case "Goggles":
                Destroy(other.gameObject);
                haveGoggles = true;
                break;

            case "Bridge":
                Destroy(other.gameObject);
                haveBridge = true;
                break;

            case "Key":
                Destroy(other.gameObject);
                haveKey = true;
                break;
        }

        updateInventory();
    }

    public void updateInventory()
    {
        if (haveBoots)
        {
            inventory[0].sprite = boots;
            inventory[0].transform.Rotate(new Vector3(0, 0, -90));

        }
        else{
            inventory[0].sprite = empty;
        }
        if (haveGoggles)
        {
            inventory[1].sprite = goggles;
        }
        else
        {
            inventory[1].sprite = empty;
        }
        if (haveBridge)
        {
            inventory[2].sprite = bridge;
        }
        else
        {
            inventory[2].sprite = empty;
        }
        if (haveKey)
        {
            inventory[3].sprite = key;
        }
        else
        {
            inventory[3].sprite = empty;
        }
        if (haveBow)
        {
            inventory[4].sprite = bow;
        }
        else
        {
            inventory[4].sprite = empty;
        }


    }

}
