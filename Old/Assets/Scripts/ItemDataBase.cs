using UnityEngine;
using System.Collections;

[System.Serializable]
public class ItemDataBase
{

    public string Name;//Имя 
    public int Id;//Идентификатор сущности 
    public string IconPatch;//путь к иконке 
    [Multiline] public string Description;//описание предмета(tooltip) 
}