using NPlant.Core;
using NPlant.Generation.ClassDiagraming;

namespace NPlant.MetaModel.ClassDiagraming
{
    public class SimulatedClassDiagramGenerator : ClassDiagramGenerator
    {
        private readonly ClassDiagram _definition;
        private readonly KeyedList<RootClassDescriptor> _classes = new KeyedList<RootClassDescriptor>();

        public SimulatedClassDiagramGenerator(ClassDiagram diagram) : base(diagram)
        {
            _definition = diagram;
        }

        protected override void OnRootClassVisited(RootClassDescriptor rootClass)
        {
            _classes.Add(rootClass);
        }

        public KeyedList<RootClassDescriptor> Classes
        {
            get { return _classes; }
        }

        public TypeMetaModelSet Types
        {
            get { return _definition.Types; }
        }

        protected override void Finalize(ClassDiagramVisitorContext current)
        {
            _classes.AddRange(current.VisitedRelatedClasses);
        }
    }
}
