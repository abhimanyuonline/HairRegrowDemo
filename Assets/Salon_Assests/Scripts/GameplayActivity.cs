using UnityEngine;

public class GameplayActivity : MonoBehaviour
{
    [SerializeField]
    private float cuttingFactor = 0.05f;
    [SerializeField]
    private float maxHairLength = 6.0f;

    public void HairCuttingActtivity(Transform obj)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        BoxCollider collider = obj.GetComponent<BoxCollider>();
        if (spriteRenderer != null && spriteRenderer.enabled)
        {
            if (spriteRenderer.size.y > 1)
            {
                spriteRenderer.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y - cuttingFactor);
                collider.size = new Vector3(spriteRenderer.size.x, spriteRenderer.size.y, collider.size.z);
                collider.center = new Vector3(collider.center.x, (-1) * spriteRenderer.size.y / 2, collider.center.z);
            }
        }
    }
    public void HairTrimmingActivity(Transform obj)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        BoxCollider collider = obj.GetComponent<BoxCollider>();

        if (spriteRenderer.size.y > 1)
        {
            spriteRenderer.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y - cuttingFactor);
            collider.size = new Vector3(spriteRenderer.size.x, spriteRenderer.size.y, collider.size.z);
            collider.center = new Vector3(collider.center.x, (-1) * spriteRenderer.size.y / 2, collider.center.z);
        }
        else
        {
            spriteRenderer.enabled = false;
        }

    }
    public void HairRegrowActivity(Transform obj)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        BoxCollider collider = obj.GetComponent<BoxCollider>();

        if (!spriteRenderer.enabled)
            spriteRenderer.enabled = true;

        if (spriteRenderer.size.y < maxHairLength)
        {
            spriteRenderer.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y + cuttingFactor);
            collider.size = new Vector3(spriteRenderer.size.x, spriteRenderer.size.y, collider.size.z);
            collider.center = new Vector3(collider.center.x, (-1) * spriteRenderer.size.y / 2, collider.center.z);
        }


    }
}
