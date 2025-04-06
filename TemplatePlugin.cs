using BepInEx;
using BepInEx.Unity.Mono;
using HarmonyLib;
using RhythmFramework;
using RhythmFramework.Interfaces;
using RhythmFramework.Options;
using RhythmFramework.Options.Enum;

namespace TemplatePlugin;

[BepInAutoPlugin]
[BepInProcess("Rhythm Doctor.exe")]
[BepInDependency(RhythmFrameworkPlugin.Id)]
public partial class Main : BaseUnityPlugin, IRhythmPlugin
{
    public Harmony Harmony { get; } = new(Id);

    public string ModID { get; } = "TemplatePlugin";

    private void Awake()
    {
        Harmony.PatchAll();
        
        OptionController.RegisterOption(new GameOptionBuilder()
            .Name("Test Option")
            .Description("A template option.")
            .Category(OptionCategory.GameAndMenu)
            .Values(0, "#1", "second option", "why not a third")
            .BindString(s => Logger.LogInfo(s))
            .Build());
        
        Logger.LogInfo($"Template Plugin is loaded!");
    }
}