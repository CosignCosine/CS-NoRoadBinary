using ICities;

namespace CS_NoRoadBinary
{
    public class Mod : IUserMod
    {
        public string Name => "No Road Binary";
        public string Description => "Save roads the way god intended.";
    }

    public class LoadingExtension : LoadingExtensionBase
    {
        public void RemoveRoadBinary(PrefabInfo newPrefab)
        {
            if (newPrefab as NetInfo == null) return;

            if(newPrefab.name.EndsWith("0") || newPrefab.name.EndsWith("1"))
            {
                newPrefab.name = newPrefab.name.Substring(0, newPrefab.name.Length - 1);
            }

            NetInfo net = newPrefab as NetInfo;

            NetInfo elevated = AssetEditorRoadUtils.TryGetElevated(net);
            NetInfo bridge = AssetEditorRoadUtils.TryGetBridge(net);
            NetInfo slope = AssetEditorRoadUtils.TryGetSlope(net);
            NetInfo tunnel = AssetEditorRoadUtils.TryGetTunnel(net);
            if (elevated != null)
            {
                if (elevated.name.EndsWith("0") || elevated.name.EndsWith("1"))
                {
                    elevated.name = elevated.name.Substring(0, elevated.name.Length - 1);
                }
            }

            if (bridge != null)
            {
                if (bridge.name.EndsWith("0") || bridge.name.EndsWith("1"))
                {
                    bridge.name = bridge.name.Substring(0, bridge.name.Length - 1);
                }
            }

            if (slope != null)
            {
                if (slope.name.EndsWith("0") || slope.name.EndsWith("1"))
                {
                    slope.name = slope.name.Substring(0, slope.name.Length - 1);
                }
            }

            if (tunnel != null)
            {
                if (tunnel.name.EndsWith("0") || tunnel.name.EndsWith("1"))
                {
                    tunnel.name = tunnel.name.Substring(0, tunnel.name.Length - 1);
                }
            }
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            ToolsModifierControl.toolController.eventEditPrefabChanged += RemoveRoadBinary;
        }
    }
}
