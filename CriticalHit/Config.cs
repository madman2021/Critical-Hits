﻿using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CriticalHit
{
	public class Config
	{
		public Dictionary<string, int[]> Messages = new Dictionary<string, int[]>();

		public void Write(string path)
		{
			using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
			{
				Write(fs);
			}
		}

		public void Write(Stream stream)
		{
			string str = JsonConvert.SerializeObject(this, Formatting.Indented);
			using (StreamWriter sw = new StreamWriter(stream))
			{
				sw.Write(str);
			}
		}

		public void Read(string path)
		{
			if (!System.IO.File.Exists(path))
				return;
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				Read(fs);
			}
		}

		public void Read(Stream stream)
		{
			using (StreamReader sr = new StreamReader(stream))
			{
				Config c = JsonConvert.DeserializeObject<Config>(sr.ReadToEnd());
				Messages = c.Messages;
			}
		}
	}
}
