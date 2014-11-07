using System;

namespace NPlant.MetaModel.ClassDiagraming
{
    public class ReflectedClassDescriptor : RootClassDescriptor
    {
        public ReflectedClassDescriptor(Type type) : base(type)
        {
            this.Level = 1;
        }

        internal override IDescriptorWriter GetWriter(ClassDiagram diagram)
        {
            return new ClassWriter(diagram, this);
        }

        internal void SetLevel(int level)
        {
            this.Level = level;
        }
    }
}