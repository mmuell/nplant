using System.Collections.Generic;

namespace NPlant.Samples.ClassDisplayOptions
{
    public class MemberLevelCustomization : ClassDiagram
    {
        public MemberLevelCustomization()
        {
            base.AddClass<Order>().ForMember(x => x.Id).Hide();
           
            Class<OrderItem>().ForMember(x => x.InternalField).Hide();
        }
    }
}
