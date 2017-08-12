namespace DataManipulation.DTO
{
    public class PointValue
    {
        public PointValue(int eid, string dataType, string value)
        {
            Eid = eid;
            DataType = dataType;
            Value = value;
        }

        public int Eid { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
    }
}
