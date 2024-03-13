using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Travelista.PayPalModels
{
	public static class SessionHelper
	{
		public static void SetObjectasJason(this ISession session , string key , object value)
		{
			session.SetString(key , JsonConvert.SerializeObject(value));
		}
		public static T GetObjectFromJason<T>(this ISession session , string key)
		{
			var value = session.GetString(key);
			return value == null ? default : JsonConvert.DeserializeObject<T>(value);
		}
	}
}
