using UnityEngine;
using System;
public interface IAnimalBehaviour
{
    bool IsInterrumpible { get; set; }


    /// <summary>
    /// Enum con los tipos de estados que pueden tener los animales
    /// </summary>
    public enum StateClass
    {
        IDLE,
        WALK,
        GREET,
        GIVE_PRESENT,
        RETURN_PRESENT
    }
    /// <summary>
    /// Metodo que se ejecuta cuando un animal cambia a este estado
    /// </summary>
    void Enter();

    /// <summary>
    /// Metodo que se ejecuta cuando un animal cambia a otro estado
    /// </summary>
    void Exit();

    /// <summary>
    /// Mientras sea el estado activo, se ejecuta este metodo cada frame
    /// </summary>
    void UpdateState();

    /// <summary>
    /// Identificador de la clase de cada estado
    /// </summary>
    StateClass StateName
    {
        get;
    }

    //void Interact(RaycastHit hit);
}
