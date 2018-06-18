 ﻿using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 public static class Utils {
 
     public static void RemoveAllChildsIn(Transform container)
     {
         int num = container.transform.childCount;
         for (int i = 0; i < num; i++) UnityEngine.Object.DestroyImmediate(container.transform.GetChild(0).gameObject);
     }
     public static void ShuffleListTexts(List<string> texts)
     {
         if (texts.Count < 2) return;
         for (int a = 0; a < 100; a++)
         {
             int id = Random.Range(1, texts.Count);
             string value1 = texts[0];
             string value2 = texts[id];
             texts[0] = value2;
             texts[id] = value1;
         }
     }
	public static int GetTimestamp()
	{
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
		return cur_time;
	}
	public static List<string> GetAllFilesIn(string path)
	{
		List<string> files = new List<string> ();
		foreach (string file in System.IO.Directory.GetFiles(path))
		{ 
			string s = file.Substring(file.Length - 5);
			if(s != ".meta")
				files.Add (file);
		}
		return files;
	}

 }
