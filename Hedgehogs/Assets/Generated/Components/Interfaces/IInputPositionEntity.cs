//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Assets.Editor.CodeGenerators.ComponentAllEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IInputPositionEntity:IEntityProjection {
    Assets.Scripts.Features.Input.InputPosition.InputPositionComponent inputPosition { get; }
    bool hasInputPosition { get; }
    void AddInputPosition(UnityEngine.Vector2 newWorldPos);
    void ReplaceInputPosition(UnityEngine.Vector2 newWorldPos);
    void RemoveInputPosition();
    
}
