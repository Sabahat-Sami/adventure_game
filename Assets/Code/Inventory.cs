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

    //public bool haveBoots = false;
    //public bool haveGoggles = false;
    //public bool haveBridge = false;
    //public bool haveKey = false;
    //public bool haveBow = false;


    private void Start()
    {
        updateInventory();

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Boots":
                print("hit boots");
                Destroy(other.gameObject);
                PublicVars.items["boots"] = true;
                break;

            case "Bow":
                Destroy(other.gameObject);
                PublicVars.items["bow"] = true;
                break;

            case "Goggles":
                Destroy(other.gameObject);
                PublicVars.items["goggles"] = true;
                break;

            case "Bridge":
                Destroy(other.gameObject);
                PublicVars.items["bridge"] = true;
                break;

            case "Key":
                print("hit key");
                Destroy(other.gameObject);
                PublicVars.items["key"] = true;
                break;
        }

        updateInventory();
    }

    public void updateInventory()
    {
        if (PublicVars.items["boots"])
        {
            inventory[0].sprite = boots;
            inventory[0].transform.Rotate(new Vector3(0, 0, -90));

        }
        else{
            inventory[0].sprite = empty;
        }
        if (PublicVars.items["goggles"])
        {
            inventory[1].sprite = goggles;
        }
        else
        {
            inventory[1].sprite = empty;
        }
        if (PublicVars.items["bridge"])
        {
            inventory[2].sprite = bridge;
        }
        else
        {
            inventory[2].sprite = empty;
        }
        if (PublicVars.items["key"])
        {
            inventory[3].sprite = key;
        }
        else
        {
            inventory[3].sprite = empty;
        }
        if (PublicVars.items["bow"])
        {
            inventory[4].sprite = bow;
        }
        else
        {
            inventory[4].sprite = empty;
        }


    }

}