//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Assets.Editor.CodeGenerators.ComponentAllEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : IAssetEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Assets.Scripts.Features.Game.Assets.AssetComponent asset { get { return (Assets.Scripts.Features.Game.Assets.AssetComponent)GetComponent(GameComponentsLookup.Asset); } }
    public bool hasAsset { get { return HasComponent(GameComponentsLookup.Asset); } }

    public void AddAsset(string newAssetPath) {
        var index = GameComponentsLookup.Asset;
        var component = (Assets.Scripts.Features.Game.Assets.AssetComponent)CreateComponent(index, typeof(Assets.Scripts.Features.Game.Assets.AssetComponent));
        component.assetPath = newAssetPath;
        AddComponent(index, component);
    }

    public void ReplaceAsset(string newAssetPath) {
        var index = GameComponentsLookup.Asset;
        var component = (Assets.Scripts.Features.Game.Assets.AssetComponent)CreateComponent(index, typeof(Assets.Scripts.Features.Game.Assets.AssetComponent));
        component.assetPath = newAssetPath;
        ReplaceComponent(index, component);
    }

    public void RemoveAsset() {
        RemoveComponent(GameComponentsLookup.Asset);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAsset;

    public static Entitas.IMatcher<GameEntity> Asset {
        get {
            if (_matcherAsset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Asset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAsset = matcher;
            }

            return _matcherAsset;
        }
    }
}
