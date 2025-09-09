using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityBar : MonoBehaviour
{
    public List<Entity> entities = new ();
    public List<Image> entitySlots = new ();
    
    public void AddEntity(Entity entity)
    {
        var entityInstance = Instantiate(entity, entitySlots[entities.Count].transform);
        entityInstance.gameObject.SetActive(false);
        entities.Add(entityInstance);
        UpdateEntityBar();
    }
    
    private void UpdateEntityBar()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entitySlots[i].sprite = entities[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
