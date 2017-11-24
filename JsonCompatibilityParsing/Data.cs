using Newtonsoft.Json;

namespace JsonCompatibilityParsing
{
    [JsonConverter(typeof(DataJsonConverter))]
    class Data
    {
        public string StringValue { set; get; }
        private string PrivateValue { set; get; }

        public Data(string stringValue, string privateValue)
        {
            StringValue = stringValue;
            PrivateValue = privateValue;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (Data)obj;
            return StringValue == other.StringValue && PrivateValue == other.PrivateValue;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return StringValue.GetHashCode() ^ PrivateValue.GetHashCode();
        }

        public static bool operator ==(Data current, object other)
        {
            return current.Equals(other);
        }

        public static bool operator !=(Data current, object other)
        {
            return !(current == other);
        }

        public override string ToString()
        {
            return $"Data: ({StringValue}, {PrivateValue})";
        }
    }
}
