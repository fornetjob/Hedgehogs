//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Assets.Editor.CodeGenerators.ComponentAllEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IRiseListenerEntity:IEntityProjection {
    RiseListenerComponent riseListener { get; }
    bool hasRiseListener { get; }
    void AddRiseListener(System.Collections.Generic.List<IRiseListener> newValue);
    void ReplaceRiseListener(System.Collections.Generic.List<IRiseListener> newValue);
    void RemoveRiseListener();
    
    void AddRiseListener(IRiseListener value);
    void RemoveRiseListener(IRiseListener value, bool removeComponentWhenEmpty = true);
}