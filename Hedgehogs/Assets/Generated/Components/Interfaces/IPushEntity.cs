//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Assets.Editor.CodeGenerators.ComponentAllEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IPushEntity:IEntityProjection {
    Assets.Scripts.Features.Game.Push.PushComponent push { get; }
    bool hasPush { get; }
    void AddPush(UnityEngine.Vector2 newDirection, float newForce);
    void ReplacePush(UnityEngine.Vector2 newDirection, float newForce);
    void RemovePush();
    
}