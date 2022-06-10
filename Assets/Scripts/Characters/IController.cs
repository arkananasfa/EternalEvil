using UnityEngine;
using UnityEngine.Events;

public interface IController {

    Transform Target { get; set; }
    
    void Acting();

}