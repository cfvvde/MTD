using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue2 : MonoBehaviour
{
    public List<string> sentances;
    public List<Texture> images;
    public Dialogue2(List<string> sentances)
    {

    }

    public IEnumerator type()
    {
        foreach (string sentance in sentances)
        {

            foreach (char c in sentance)
            {


                yield return null;
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

    }
}
