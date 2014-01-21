//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.IO;
using LitJson;


namespace NeolithLib.Config
{
	[Serializable]
	public class NeolithConfig
	{
		public NeolithConfig ()
		{
			ModDirectoryPath = "mods";
			ModFilePattern = "*_mod";
			ConfigDirectoryPath = Path.Combine("mods", "config");
		}
		
		public string ModDirectoryPath { get; set; }
		public string ModFilePattern { get; set; }
		public string ConfigDirectoryPath { get; set; }
		
		public bool Read(string leatherConfigPath) {
			string leatherConfigData = File.ReadAllText (leatherConfigPath);
			var leatherOutData = JsonMapper.ToObject (leatherConfigData);
			
			JsonData modsDir = leatherOutData ["modDirectoryPath"];
			JsonData filePattern = leatherOutData ["modFilePattern"];
			JsonData configDir = leatherOutData ["configDirectoryPath"];
			
			if (modsDir == null || string.IsNullOrEmpty (modsDir.AsString))
				return false;
			if (filePattern == null || string.IsNullOrEmpty(filePattern.AsString))
				return false;
			if (configDir == null || string.IsNullOrEmpty (configDir.AsString))
				return false;
			
			this.ModDirectoryPath = modsDir.AsString;
			this.ModFilePattern = filePattern.AsString;
			this.ConfigDirectoryPath = configDir.AsString;
			return true;
		}
	}
}
