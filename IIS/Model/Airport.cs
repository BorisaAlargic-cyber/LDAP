using System;
namespace IIS.Model
{
    public class Airport : BaseModel
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Destination destination { get; set; }
    }
}
