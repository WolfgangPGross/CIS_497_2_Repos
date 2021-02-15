using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    //We want to update Left and Right firing, force in up/down, force in left/right,
    void UpdateData(bool firing, float forceForwards, float forceSideways, float forceVertical);

}
