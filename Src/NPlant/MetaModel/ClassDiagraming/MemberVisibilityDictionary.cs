using System.Collections.Generic;

namespace NPlant.MetaModel.ClassDiagraming
{
    public class MemberVisibilityDictionary
    {
        private readonly IDictionary<RootClassDescriptor, IDictionary<string, bool>> _memberVisibility = new Dictionary<RootClassDescriptor, IDictionary<string, bool>>();

        public bool this[RootClassDescriptor descriptor, string name]
        {
            get
            {
                bool visibility;

                if (TryGetValue(descriptor, name, out visibility))
                    return visibility;

                return true;
            }
            set
            {
                IDictionary<string, bool> memberVisibility;

                if (!_memberVisibility.TryGetValue(descriptor, out memberVisibility))
                {
                    memberVisibility = new Dictionary<string, bool>();
                    _memberVisibility.Add(descriptor, memberVisibility);
                }

                memberVisibility[name] = value;
            }
        }

        private bool TryGetValue(RootClassDescriptor classDescriptor, string name, out bool visibility)
        {
            IDictionary<string, bool> memberVisibility;

            if (_memberVisibility.TryGetValue(classDescriptor, out memberVisibility))
            {
                if (memberVisibility.TryGetValue(name, out visibility))
                    return true;
            }

            visibility = true;

            return false;
        }
    }
}