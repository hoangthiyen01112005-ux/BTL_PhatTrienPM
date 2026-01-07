using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DAL.Helper
{
    public static class ConvertMessage
    {
        private static readonly JsonSerializerSettings _Setting;
        static ConvertMessage()
        {
            _Setting = new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
        }

        // Thêm public và this để thành Extension Method hợp lệ
        public static string SeriallizerObject(this object obj)
        {
            if (obj == null) return "";
            return JsonConvert.SerializeObject(obj, _Setting);
        }
    }
}