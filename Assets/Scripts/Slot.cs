using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public string slotName;


    public Slot(string slotName)
    {
        this.slotName = slotName;
    }
    public string GetName()
    {
        return slotName;
    }
    public bool IsCompatible(Card card)
    {
        return slotName == card.type || card.type == "all";
    }
    public void OnDrop(PointerEventData pointerEventData)
    {
        Card droppedCard = pointerEventData.pointerDrag.GetComponent<Card>();

        if (droppedCard != null && IsCompatible(droppedCard))
        {
            Template template = FindObjectOfType<Template>();
            template.TestCard(droppedCard, this);
        }
    }
}
