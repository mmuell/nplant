using System;
using System.Collections.Generic;
using System.Linq;
using NPlant.MetaModel.ClassDiagraming;

namespace NPlant
{
    public class ClassDiagramPackage
    {
        private readonly ClassDiagram _diagram;
        private readonly string _name;
        private readonly List<Func<RootClassDescriptor, bool>> _matcher = new List<Func<RootClassDescriptor, bool>>();

        internal string Name { get { return _name; } }

        internal ClassDiagramPackage(string name, ClassDiagram diagram)
        {
            _diagram = diagram;
            _name = name;
        }

        public ClassDiagramPackage IncludeWhere(Func<RootClassDescriptor, bool> filter)
        {
            _matcher.Add(filter);

            return this;
        }

        public ClassDiagram IncludeAll()
        {
            IncludeWhere(descriptor => true);

            return _diagram;
        }

        public ClassDiagram Diagram { get { return _diagram; } }

        internal bool IsMatch(RootClassDescriptor classDescriptor)
        {
            return _matcher.Any(matcher => matcher(classDescriptor));
        }
    }
}