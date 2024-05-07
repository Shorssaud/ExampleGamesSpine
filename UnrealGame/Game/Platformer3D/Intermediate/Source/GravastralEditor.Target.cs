using UnrealBuildTool;

public class GravastralEditorTarget : TargetRules
{
	public GravastralEditorTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.V3;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Editor;
		ExtraModuleNames.Add("Gravastral");
	}
}
