﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class InstanceHandler
	{
		private static List<Cpu> instances = new();

		private static Cpu InstanceWithIndex(int index) 
		{
			while (instances.Count <= index) { AddInstance(); }
			return instances[index];
		}

		public static void AddInstance() { instances.Add(new()); }

		public static void RemoveInstance() 
		{
			if (instances.Count > 0) { instances.RemoveAt(instances.Count - 1); }
		}

		public static void RemoveInstanceAt(int index) { instances.RemoveAt(index); }

		public static Cpu GetCpu(int instanceIndex) { return InstanceWithIndex(instanceIndex); }
	}
}
