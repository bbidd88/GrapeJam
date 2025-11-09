using UnityEngine;

public abstract class YPopup : YCanvas
{
    public void Close()
    {
        this.transform.parent = null;
        Destroy(gameObject);
    }
}
