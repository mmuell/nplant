namespace NPlant.Samples.ClassDisplayOptions
{
    public class SquashInheritance : ClassDiagram
    {
        public SquashInheritance()
        {
            this.GenerationOptions.ForType<BaseEntity>().HideAsBase();
            AddClass<Order>();
        }
    }
}
