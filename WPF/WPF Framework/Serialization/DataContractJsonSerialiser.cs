namespace WpfFramework.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public static class DataContractJsonSerialiser
    {
        #region Methods

        public static object Deserialise(string json, Type type)
        {
            if (string.IsNullOrEmpty(json)) {
                throw new ArgumentNullException("json");
            }
            if (type == null) {
                throw new ArgumentNullException("type");
            }

            var js = new DataContractJsonSerializer(type);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json))) {
                return js.ReadObject(ms);
            }
        }

        public static T Deserialise<T>(string json) where T : new()
        {
            if (string.IsNullOrEmpty(json)) {
                throw new ArgumentNullException("json");
            }

            var result = default(T);

            var objResult = Deserialise(json, typeof (T));
            if (objResult != null) {
                result = (T) objResult;
            }
            return result;
        }

        public static string Serialise<T>(T instance)
        {
            return Serialise(instance.GetType(), instance);
        }

        public static string Serialise(Type type, object instance)
        {
            if (type == null) {
                throw new ArgumentNullException("type");
            }
            if (instance == null) {
                throw new ArgumentNullException("instance");
            }

            var jsonStream = new MemoryStream();
            string json;

            try {
                using (var ms = new MemoryStream()) {
                    var ser = new DataContractJsonSerializer(type);
                    ser.WriteObject(ms, instance);
                    var byteArray = ms.ToArray();

                    json = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                }
            }
            finally {
                jsonStream.Dispose();
            }

            return json;
        }

        #endregion
    }
}