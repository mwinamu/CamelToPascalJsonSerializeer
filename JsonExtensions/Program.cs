// See https://aka.ms/new-console-template for more information

using JsonExtensions;
using Newtonsoft.Json.Linq;

string jsonString =
    "{\"personName\":{\"firstName\":\"Emma\",\"lastName\":\"Watson\"}}";
var jObj = JObject.Parse(jsonString);
jObj.Capitalize();
Console.WriteLine(jObj.ToString()); //yay!
