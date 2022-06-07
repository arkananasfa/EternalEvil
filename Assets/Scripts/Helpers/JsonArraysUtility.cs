using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Helpers {
	
	public class JSONArraysUtility {

		public static T[] FromJson<T>(string json) {
			GenericArray<T> array = JsonUtility.FromJson<GenericArray<T>>(json);
			return array.Items;
		}

		public static string ToJson<T>(T[] array) {
			GenericArray<T> garray = new GenericArray<T>();
			garray.Items = array;
			return JsonUtility.ToJson(garray);
		}

		[Serializable]
		class GenericArray<T> {
			public T[] Items;
		}
	
	}
	
}