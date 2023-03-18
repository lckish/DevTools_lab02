using System;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MSBuildCustomTasks
{
	public class IncrementBuild : Task
	{
		private string _csprojFileName;

		[Required]
		public string CsprojFileName
		{
			get { return _csprojFileName; }
			set { _csprojFileName = value; }
		}

		[Output]
		public string Version { get; set; }

		public override bool Execute()
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(CsprojFileName);
			XmlNode xVersionPrefix = xmlDoc.SelectSingleNode(@"/Project/PropertyGroup/VersionPrefix");
			string oldVersion = xVersionPrefix.InnerText;

			string[] version = string.IsNullOrEmpty(oldVersion) ? "0.0.1".Split('.') : oldVersion.Split('.');

			int build = Convert.ToInt32(version[version.Length - 1]);
			build++;

			version[version.Length - 1] = build.ToString();

			Version = string.Join(".", version);

			xVersionPrefix.InnerText = Version;
			xmlDoc.Save(CsprojFileName);

			return true;
		}
	}
}
