using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiCombiner : MonoBehaviour
{
    private int _layerIndex;
    private MochiInfo _info;

    private void Awake()
    {
        _info = GetComponent<MochiInfo>();
        _layerIndex = gameObject.layer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerIndex)
        {
            MochiInfo info = collision.gameObject.GetComponent<MochiInfo>();
            if (info != null)
            {
                if (info.MochiIndex == _info.MochiIndex)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID = collision.gameObject.GetInstanceID();

                    if (thisID > otherID)
                    {
                        //grab the point value when fruits combine
                        GameManager.instance.IncreaseScore(_info.PointsWhenDestroyed);

                        if (_info.MochiIndex == MochiSelector.instance.Mochi.Length - 1)
                        {
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }

                        else
                        {
                            Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                            GameObject go = Instantiate(SpawnCombinedMochi(_info.MochiIndex), GameManager.instance.transform);
                            go.transform.position = middlePosition;

                            ColliderInformer informer = go.GetComponent<ColliderInformer>();
                            if (informer != null)
                            {
                                informer.WasCombinedIn = true;
                            }

                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    private GameObject SpawnCombinedMochi(int Index)
    {
        GameObject go = MochiSelector.instance.Mochi[Index + 1];
        return go;
    }
}
